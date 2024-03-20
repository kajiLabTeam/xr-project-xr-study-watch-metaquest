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
        // �ϐ��̏�����
        isChangeLabData = false;
        isChangeArriveData = false;

        _text.text += "request\n";
        // �ʐM�̊J�n
        yield return StartCoroutine(labsCoroutine);
        _text.text += "http end\n";
        try
        {
            var result = (ValueTuple<string, ResponseData>)labsCoroutine.Current;
            rawData = result.Item1;
            newResponseData = result.Item2;
        }
        catch { _text.text += "�擾�ł��܂���\n"; }
        _text.text += "request comp\n";
        int labinsert = 0;
        foreach (LabObjectData labObjectData in newResponseData.arroundObjects)
        {
            _text.text += labinsert.ToString() + "time";
            labinsert++;
            // LabState �ɃC���T�[�g
            isChangeLabData |= _labController.AddLabData(labObjectData);
            // SelectState �ɃC���T�[�g
            _selectController.AddSelectInfo(labObjectData.id);
        }
        _text.text += "\nLab insert end\n";
        labinsert = 0;
        foreach (ArriveInfo arriveInfo in newResponseData.arriveInfos)
        {
            _text.text += labinsert.ToString();
            labinsert++;
            // ArriveState �ɃC���T�[�g
            isChangeArriveData |= _arriveController.AddArriveInfo(arriveInfo);
        }
        _text.text += "Arrive insert end\n";

        // �ύX���擾 && ����p�̔���
        //if (isChangeLabData)
        //{
        //    _text.text += "�����������X�V\n";
        //    // ScanPannel���A�N�e�B�u��
        //    yield return _scanFlow.WakeScanFlow();
        //}
        //else
        //{
        //    _text.text += "���������͍X�V����Ă��܂���\n";
        //}
        //if (isChangeArriveData)
        //{
        //    _text.text += "�摜��\��\n";
        //    // �摜�̕\��
        //    yield return _labImageFlow.WakeLabImageFlow();
        //}

        _text.text += "wait for seconds\n";
        yield return new WaitForSeconds(5);
        number ++;
    }
}
