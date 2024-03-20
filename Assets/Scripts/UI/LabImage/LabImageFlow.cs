using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabImageFlow : MonoBehaviour
{
    [SerializeField] SelectController _selectController;
    [SerializeField] ArriveController _arriveController;
    [SerializeField] HttpClient _httpClient;

    [SerializeField] GetFollowPannelPosition _getFollowPannelPosition;

    [SerializeField] LabImageInsertTexture _labImageInsertTexture;
    [SerializeField] LabImagePannel _labImagePannel;

    private List<string> arriveIds;
    private string selectId;
    private string imageURL;
    private Texture texture;
    private Vector3 position;

    public IEnumerator WakeLabImageFlow()
    {
        // ���ǂ蒅�����I�u�W�F�N�g�̎擾
        arriveIds = _arriveController.GetArriveIds();
        // �I�������I�u�W�F�N�g�̎擾
        selectId = _selectController.GetSelectedId();

        // ��v���Ă��Ȃ��ꍇ�͕\�����Ȃ�
        if (!arriveIds.Contains(selectId))
        {
            yield break;
        }

        // �摜URL�̎擾
        imageURL=  _arriveController.GetImageURL(selectId);
        // �摜�̎擾
        var GetTextureContinue = _httpClient.GetTexture(imageURL);
        yield return StartCoroutine(GetTextureContinue);
        texture = (Texture)GetTextureContinue.Current;
        // �A�X�y�N�g��̎擾

        // �}�e���A���ɓK��
        _labImageInsertTexture.SetMaterial(texture);
        // �t�H���[�������W���̎擾
        position = _getFollowPannelPosition.GetPosition();
        // �摜�̔z�u�]��
        _labImagePannel.SetLabImagePosition(position);
        // �摜���A�N�e�B�u��
        _labImagePannel.EnableLabImage();
    }
}
