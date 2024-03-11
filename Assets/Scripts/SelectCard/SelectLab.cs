using System;
using UnityEngine;
using TMPro;

public class SelectLab : MonoBehaviour
{
    [SerializeField] LabsState _labsState;
    [SerializeField] SwitchPanel _switchPanel;
    [SerializeField] SelectInsertText _selectInsertText;

    public string showOddLabId;
    public string showEvenLabId;
    public string selectLabId;
    public int selectLabIndex;

    private void SetLabId(string labId)
    {
        selectLabId = labId;
        selectLabIndex = Array.FindIndex(_labsState.labs.objects, obj => obj.id == labId);

        _selectInsertText.SetText(selectLabIndex);
    }

    public void SetLabOdd()
    {
        SetLabId(showOddLabId);
        _switchPanel.CloseNearList();
    }

    public void SetLabEven()
    {
        SetLabId(showEvenLabId);
        _switchPanel.CloseNearList();
    }


    public void SetOddId(string id)
    {
        showOddLabId = id;
    }

    public void SetEvenId(string id)
    {
        showEvenLabId = id;
    }
}
