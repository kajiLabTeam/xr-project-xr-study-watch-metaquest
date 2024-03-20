using OVR.OpenVR;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LabImageFlow : MonoBehaviour
{
    [SerializeField] SelectController _selectController;
    [SerializeField] ArriveController _arriveController;
    [SerializeField] HttpClient _httpClient;

    [SerializeField] GetFollowPannelPosition _getFollowPannelPosition;

    [SerializeField] LabImageInsertTexture _labImageInsertTexture;
    [SerializeField] LabImagePannel _labImagePannel;

    public Texture texture = null;

    public IEnumerator WakeLabImageFlow(TMPro.TMP_Text _text)
    {
        // 選択したオブジェクトの取得
        string selectId = _selectController.GetSelectedId();

        // 画像URLの取得
        string imageURL =  _arriveController.GetImageURL(selectId);
        // 画像の取得
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageURL);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            try
            {
                texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                // マテリアルに適応
                _labImageInsertTexture.SetMaterial(texture);
                _text.text += texture.name + "\n";
                if (texture != null)
                {
                    _selectController.SetIsShowed(selectId);
                    _text.text += "request sucseccs\n";
                }
            }
            catch
            {
                Debug.LogError("request:" + request.ToString() + "\n");
            }
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
            _text.text = "Error fetching data: " + request.error + "\n";
        }

        // フォローした座標情報の取得
        Vector3 position = _getFollowPannelPosition.GetPosition();
        // 画像の配置転換
        _labImagePannel.SetLabImagePosition(position);
        // 画像をアクティブに
        _labImagePannel.EnableLabImage();
    }
}
