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
    [SerializeField] ImagePannelController _imagePannelController;

    public Texture texture = null;

    public IEnumerator WakeLabImageFlow()
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
                // テクスチャを取得
                texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                // マテリアルに適応
                _labImageInsertTexture.SetMaterial(texture);
                if (texture != null)
                {
                    _selectController.SetIsShowed(selectId);
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
        }

        // サイズを変更
        Vector3 vector3 = _arriveController.GetImageAspect(selectId);
        _imagePannelController.SetImageSize(vector3);

        // フォローした座標情報の取得
        Vector3 position = _getFollowPannelPosition.GetPosition();
        // 画像の配置転換
        _labImagePannel.SetLabImagePosition(position);
        // 画像をアクティブに
        _labImagePannel.EnableLabImage();
    }
}
