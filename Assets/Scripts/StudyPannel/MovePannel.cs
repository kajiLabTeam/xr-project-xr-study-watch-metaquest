using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


public class MovePannel : MonoBehaviour
{
    [SerializeField] LabsState _labsState;
    [SerializeField] ArriveLab _arriveLab;
    [SerializeField] GameObject FollowPannel;
    [SerializeField] GameObject _labImage;
    [SerializeField] RawImage _rawImage;
    [SerializeField] TMP_Text _debug;

    private Texture assetImage;

    public IEnumerator SetLabImage()
    {
        _debug.text = "Called\n";
        yield return GetImage();
        _debug.text += "finish\n";
        _labImage.transform.position = FollowPannel.transform.position;
    }

    private IEnumerator GetImage()
    {
        _debug.text += "start\n";
        string id = _arriveLab.SelectedId();
        if (id ==null)
        {
            _debug.text += "id is null\n";
        }
        _debug.text += "getid" + id + "\n";
        ObjectData objectData = _labsState.labs.objects.FirstOrDefault(x => x.id == id);
        if (objectData == null)
        {
            _debug.text += "objectData is null\n";
        }
        _debug.text += "objectData" + objectData.lab.name + "\n";
        _debug.text += objectData.lab.image + "\n";
        //yield return new WaitForSeconds(1);
        _debug.text += "RequestStart\n";
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(objectData.lab.image);
        yield return request.SendWebRequest();
        _debug.text += "RequestEnd\n";
        if (request.result == UnityWebRequest.Result.Success)
        {
            _debug.text += "requestComp\n";
            try
            {
                assetImage = ((DownloadHandlerTexture)request.downloadHandler).texture;
                try
                {
                    SetImage();
                    _debug.text += "request:" + request.ToString();
                }
                catch
                {
                    _debug.text += "イメージをセットできませんでした\n";
                }
            }
            catch
            {
                _debug.text += "処理できませんでした\n";
                _debug.text += "request:" + request.ToString() + "\n";
            }
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
            _debug.text += "Error fetching data: " + request.error;
        }
    }

    private void SetImage()
    {
        _rawImage.texture = assetImage;
    }

    public Texture GetTexture()
    {
        return assetImage;
    }
}
