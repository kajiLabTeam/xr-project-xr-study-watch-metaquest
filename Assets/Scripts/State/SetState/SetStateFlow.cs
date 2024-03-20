using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResponseData
{
    public List<ArriveInfo> arriveInfos;
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

    [SerializeField] TMPro.TMP_Text _text;

    private string rawData;
    private ResponseData newResponseData;
    private bool isChangeLabData = false;
    private bool isChangeArriveData = false;


    public IEnumerator Start()
    {
        _text.text = "start\n";
        var labsCoroutine = _httpClient.GetLabs();
        yield return WakeSetStateFlow(labsCoroutine);
    }

    private int number = 0;

    public IEnumerator WakeSetStateFlow(IEnumerator labsCoroutine)
    {
        _text.text += "loop" + number.ToString() + "\n";
        // 変数の初期化
        isChangeLabData = false;
        isChangeArriveData = false;

        _text.text += "request\n";
        // 通信の開始
        yield return StartCoroutine(labsCoroutine);
        _text.text += "http end\n";
        try
        {
            var result = (ValueTuple<string, ResponseData>)labsCoroutine.Current;
            rawData = result.Item1;
            newResponseData = result.Item2;
        }
        catch { _text.text += "取得できません\n"; }
        _text.text += "request comp\n";
        int labinsert = 0;
        foreach (LabObjectData labObjectData in newResponseData.arroundObjects)
        {
            _text.text += labinsert.ToString() + "time";
            labinsert++;
            // LabState にインサート
            isChangeLabData |= _labController.AddLabData(labObjectData);
            // SelectState にインサート
            _selectController.AddSelectInfo(labObjectData.id);
        }
        _text.text += "\nLab insert end\n";
        labinsert = 0;
        foreach (ArriveInfo arriveInfo in newResponseData.arriveInfos)
        {
            _text.text += labinsert.ToString();
            labinsert++;
            // ArriveState にインサート
            isChangeArriveData |= _arriveController.AddArriveInfo(arriveInfo);
        }
        _text.text += "Arrive insert end\n";

        // 変更を取得 && 副作用の発火
        //if (isChangeLabData)
        //{
        //    _text.text += "研究室情報を更新\n";
        //    // ScanPannelをアクティブに
        //    yield return _scanFlow.WakeScanFlow();
        //}
        //else
        //{
        //    _text.text += "研究室情報は更新されていません\n";
        //}
        //if (isChangeArriveData)
        //{
        //    _text.text += "画像を表示\n";
        //    // 画像の表示
        //    yield return _labImageFlow.WakeLabImageFlow();
        //}

        _text.text += "wait for seconds\n";
        yield return new WaitForSeconds(5);
        number ++;
    }
}
