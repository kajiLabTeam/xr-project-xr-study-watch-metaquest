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
        // �T�[�o�[�ƌ��������̓������s��
        // �K�v�ȗv�f�̏�����
        ResponseData newResponseData = null;
        // �ʐM�̊J�n
        yield return StartCoroutine(labsCoroutine);
        newResponseData = (ResponseData)labsCoroutine.Current;

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
            // ScanPannel���A�N�e�B�u��
            // yield return _scanFlow.WakeScanFlow();
        }

        // �V�������B��񂪂��邩�A�I�����ꂽ ID ���ύX���ꂽ�ꍇ
        bool isChangedArriveOrSelectData = isChangeArriveData || isChangeSelectedId;

        // �摜���\������Ă��炸�A�I�����ꂽ ID �� null �łȂ��ꍇ
        bool isImageToShow = !_selectController.GetIsShowed(selectedId) && selectedId != null;

        // ���������ׂĖ�������Ă��邩�ǂ������`�F�b�N
        if (isChangedArriveOrSelectData && isImageToShow)
        {
            // �摜�̕\��
            yield return StartCoroutine(_labImageFlow.WakeLabImageFlow());
        }
        yield return new WaitForSeconds(20);
    }
}
