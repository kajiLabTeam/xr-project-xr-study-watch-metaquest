using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;


public class MovePannel : MonoBehaviour
{
    [SerializeField] LabsState _labsState;
    [SerializeField] ArriveLab _arriveLab;
    [SerializeField] GameObject FollowPannel;
    [SerializeField] GameObject _labImage;
    [SerializeField] ChangetextureToMateril _changetextureToMateril;

    private Texture assetImage;

    public IEnumerator SetLabImage()
    {
        yield return GetImage();
        _labImage.transform.position = FollowPannel.transform.position;
    }

    private IEnumerator GetImage()
    {
        string id = _arriveLab.SelectedId();
        if (id ==null)
        {
            Debug.LogError("id is null\n");
        }
        ObjectData objectData = _labsState.labs.objects.FirstOrDefault(x => x.id == id);
        if (objectData == null)
        {
            Debug.LogError("onjectdata is null");
        }
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(objectData.lab.image);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            try
            {
                assetImage = ((DownloadHandlerTexture)request.downloadHandler).texture;
                _changetextureToMateril.SetMaterial(assetImage);
            }
            catch
            {
                Debug.LogError("request:" + request.ToString() + "\n");
            }
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
        }
    }
}
