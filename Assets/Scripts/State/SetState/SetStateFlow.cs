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

    [SerializeField] TMPro.TMP_Text _text;

    private IEnumerator labsCoroutine;

    private string rawData;
    private string selectedId;

    private void Awake()
    {
        labsCoroutine = _httpClient.GetLabs();
    }

    public IEnumerator Start()
    {
        _text.text = "start\n";
        yield return Loop();
    }

    public IEnumerator Loop()
    {
        int number = 0;
        while (true)
        {
            yield return WakeSetStateFlow(number);
            number++;
        }
    }

    public IEnumerator WakeSetStateFlow(int number)
    {
        _text.text += "loop" + number.ToString() + "\n";

        // �T�[�o�[�ƌ��������̓������s��
        // �K�v�ȗv�f�̏�����
        ResponseData newResponseData = null;
        // �ʐM�̊J�n
        yield return StartCoroutine(labsCoroutine);
        var result = (ValueTuple<string, ResponseData>)labsCoroutine.Current;
        rawData = result.Item1;
        newResponseData = result.Item2;

        // ���������̕ύX�̌��m
        bool isChangeLabData = false;
        foreach (LabObjectData labObjectData in newResponseData.arroundObjects)
        {
            // LabState �ɃC���T�[�g
            isChangeLabData |= _labController.AddLabData(labObjectData);
            // SelectState �ɃC���T�[�g
            _selectController.AddSelectInfo(labObjectData.id);
        }

        // ���B���̕ύX�̌��m
        bool isChangeArriveData = false;
        foreach (ArriveInfo arriveInfo in newResponseData.arrivingObjects)
        {
            // ArriveState �ɃC���T�[�g
            isChangeArriveData |= _arriveController.AddArriveInfo(arriveInfo);
        }

        // �I�����̕ύX�̌��m
        bool isChangeSelectedId = false;
        string newSelectedId = _selectController.GetSelectedId();
        if (selectedId != newSelectedId)
        {
            selectedId = newSelectedId;
            isChangeSelectedId = true;
        }

        // �ύX���擾 && ����p�̔���
        if (isChangeLabData)
        {
            _text.text += "�����������X�V\n";
            // ScanPannel���A�N�e�B�u��
            _scanFlow.WakeScanFlow();
        }
        else
        {
            _text.text += "���������͍X�V����Ă��܂���\n";
        }

        // �V�������B��񂪂��邩�A�I�����ꂽ ID ���ύX���ꂽ�ꍇ
        bool isChangedData = isChangeArriveData || isChangeSelectedId;

        // �摜���\������Ă��炸�A�I�����ꂽ ID �� null �łȂ��ꍇ
        bool isImageToShow = !_selectController.GetIsShowed(selectedId) && selectedId != null;

        // ���������ׂĖ�������Ă��邩�ǂ������`�F�b�N
        if (isChangedData && isImageToShow)
        {
            _text.text += "�摜��\��\n";
            // �摜�̕\��
            yield return StartCoroutine(_labImageFlow.WakeLabImageFlow(_text));
        }
        else
        {
            _text.text += "�摜��\�����܂���\n";
        }

        _text.text += "wait for seconds";
        yield return new WaitForSeconds(5);
    }
}
