using UnityEngine;
using System.Linq;
using TMPro;

public class SelectLab : MonoBehaviour
{
    [SerializeField] LabsState _labsState;
    [SerializeField] ArriveLab _arriveLab;
    [SerializeField] SwitchPanel _switchPanel;
    [SerializeField] SelectInsertText _selectInsertText;

    public string showOddLabId;
    public string showEvenLabId;
    public string selectLabId;
    public ObjectData selectLabObjectData;
    public int selectLabIndex;

    private void SetLabId(string labId)
    {
        _arriveLab.SetSelected(labId);
        selectLabId = labId;
        selectLabIndex = _labsState.labs.objects.FindIndex(x => x.id == selectLabId);
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
