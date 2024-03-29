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
        // �I�������I�u�W�F�N�g�̎擾
        string selectId = _selectController.GetSelectedId();

        // �摜URL�̎擾
        string imageURL =  _arriveController.GetImageURL(selectId);
        // �摜�̎擾
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageURL);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            try
            {
                // �e�N�X�`�����擾
                texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                // �}�e���A���ɓK��
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

        // �T�C�Y��ύX
        Vector3 vector3 = _arriveController.GetImageAspect(selectId);
        _imagePannelController.SetImageSize(vector3);

        // �t�H���[�������W���̎擾
        Vector3 position = _getFollowPannelPosition.GetPosition();
        // �摜�̔z�u�]��
        _labImagePannel.SetLabImagePosition(position);
        // �摜���A�N�e�B�u��
        _labImagePannel.EnableLabImage();
    }
}
