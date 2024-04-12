using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResponseData
{
    public List<ArriveInfo> arrivingObjects;
    public List<LabObjectData> aroundObjects;
}

public class SetStateFlow : MonoBehaviour
{
    [SerializeField] HttpClient _httpClient;
    [SerializeField] LabController _labController;
    [SerializeField] SelectController _selectController;
    [SerializeField] ArriveController _arriveController;

    [SerializeField] ScanFlow _scanFlow;
    [SerializeField] LabImageFlow _labImageFlow;

    [SerializeField] TMPro.TMP_Text _Text;

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
        _Text.text += "start" + "\n";
        // ?T?[?o?[?????????????????????s??
        // ?K?v???v?f????????
        ResponseData newResponseData = null;
        // ???M???J?n
        _Text.text += "request" + "\n";
        labsCoroutine = _httpClient.GetLabs();
        yield return StartCoroutine(labsCoroutine);
        newResponseData = (ResponseData)labsCoroutine.Current;

        _Text.text += "request end" + "\n";
        // ???????????????X?????m
        bool isChangeLabData = false;
        foreach (LabObjectData labObjectData in newResponseData.aroundObjects)
        {
            // LabState ???C???T?[?g
            isChangeLabData |= _labController.AddLabData(labObjectData);
            // SelectState ???C???T?[?g
            _selectController.AddSelectInfo(labObjectData.id);
        }

        // ???B?????????X?????m
        bool isChangeArriveData = false;
        foreach (ArriveInfo arriveInfo in newResponseData.arrivingObjects)
        {
            // ArriveState ???C???T?[?g
            isChangeArriveData |= _arriveController.AddArriveInfo(arriveInfo);
        }

        // ?I???????????X?????m
        bool isChangeSelectedId = false;
        string newSelectedId = _selectController.GetSelectedId();
        if (selectedId != newSelectedId)
        {
            selectedId = newSelectedId;
            isChangeSelectedId = true;
        }

        // ???X?????? && ?????p??????
        if (isChangeLabData)
        {
            // ScanPannel???A?N?e?B?u??
            // yield return _scanFlow.WakeScanFlow();
        }

        // ?V???????B?????????????A?I???????? ID ?????X??????????
        bool isChangedArriveOrSelectData = isChangeArriveData || isChangeSelectedId;

        // ???????\???????????????A?I???????? ID ?? null ??????????
        bool isImageToShow = !_selectController.GetIsShowed(selectedId) && selectedId != null;

        // ?????????????????????????????????????`?F?b?N
        if (isChangedArriveOrSelectData && isImageToShow)
        {
            // ???????\??
            yield return StartCoroutine(_labImageFlow.WakeLabImageFlow());
        }
        _Text.text += "wait";
        yield return new WaitForSeconds(10);
        _Text.text += "wait end" + "\n";
    }
}
