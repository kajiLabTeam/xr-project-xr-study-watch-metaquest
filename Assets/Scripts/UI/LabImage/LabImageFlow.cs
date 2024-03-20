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
        // たどり着いたオブジェクトの取得
        arriveIds = _arriveController.GetArriveIds();
        // 選択したオブジェクトの取得
        selectId = _selectController.GetSelectedId();

        // 一致していない場合は表示しない
        if (!arriveIds.Contains(selectId))
        {
            yield break;
        }

        // 画像URLの取得
        imageURL=  _arriveController.GetImageURL(selectId);
        // 画像の取得
        var GetTextureContinue = _httpClient.GetTexture(imageURL);
        yield return StartCoroutine(GetTextureContinue);
        texture = (Texture)GetTextureContinue.Current;
        // アスペクト比の取得

        // マテリアルに適応
        _labImageInsertTexture.SetMaterial(texture);
        // フォローした座標情報の取得
        position = _getFollowPannelPosition.GetPosition();
        // 画像の配置転換
        _labImagePannel.SetLabImagePosition(position);
        // 画像をアクティブに
        _labImagePannel.EnableLabImage();
    }
}
