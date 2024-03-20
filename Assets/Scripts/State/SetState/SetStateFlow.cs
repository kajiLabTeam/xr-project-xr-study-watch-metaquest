using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResponseData
{
    public List<ArriveInfo> arrivingObjects;
    public List<LabObjectData> arroundObjects;
}

public class SetStateFlow : MonoBehaviour
{
    [SerializeField] HttpClient _httpClient;
    [SerializeField] LabController _labController;
    [SerializeField] SelectController _selectController;
    [SerializeField] ArriveController _arriveController;

    [SerializeField] ScanFlow _scanFlow;
    [SerializeField] LabImageFlow _labImageFlow;

    private IEnumerator labsCoroutine;

    private string selectedId;

    private void Awake()
    {
        labsCoroutine = _httpClient.GetLabs();
    }

    public IEnumerator Start()
    {
        yield return Loop();
    }

    public IEnumerator Loop()
    {
        while (true)
        {
            yield return WakeSetStateFlow();
        }
    }

    public IEnumerator WakeSetStateFlow()
    {
        // サーバーと研究室情報の同期を行う
        // 必要な要素の初期化
        ResponseData newResponseData = null;
        // 通信の開始
        yield return StartCoroutine(labsCoroutine);
        newResponseData = (ResponseData)labsCoroutine.Current;

        // 研究室情報の変更の検知
        bool isChangeLabData = false;
        foreach (LabObjectData labObjectData in newResponseData.arroundObjects)
        {
            // LabState にインサート
            isChangeLabData |= _labController.AddLabData(labObjectData);
            // SelectState にインサート
            _selectController.AddSelectInfo(labObjectData.id);
        }

        // 到達情報の変更の検知
        bool isChangeArriveData = false;
        foreach (ArriveInfo arriveInfo in newResponseData.arrivingObjects)
        {
            // ArriveState にインサート
            isChangeArriveData |= _arriveController.AddArriveInfo(arriveInfo);
        }

        // 選択情報の変更の検知
        bool isChangeSelectedId = false;
        string newSelectedId = _selectController.GetSelectedId();
        if (selectedId != newSelectedId)
        {
            selectedId = newSelectedId;
            isChangeSelectedId = true;
        }

        // 変更を取得 && 副作用の発火
        if (isChangeLabData)
        {
            // ScanPannelをアクティブに
            // yield return _scanFlow.WakeScanFlow();
        }

        // 新しい到達情報があるか、選択された ID が変更された場合
        bool isChangedArriveOrSelectData = isChangeArriveData || isChangeSelectedId;

        // 画像が表示されておらず、選択された ID が null でない場合
        bool isImageToShow = !_selectController.GetIsShowed(selectedId) && selectedId != null;

        // 条件がすべて満たされているかどうかをチェック
        if (isChangedArriveOrSelectData && isImageToShow)
        {
            // 画像の表示
            yield return StartCoroutine(_labImageFlow.WakeLabImageFlow());
        }
        yield return new WaitForSeconds(20);
    }
}
