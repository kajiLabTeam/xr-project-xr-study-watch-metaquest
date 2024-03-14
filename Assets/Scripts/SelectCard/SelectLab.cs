using UnityEngine;
using System.Linq;

public class SelectLab : MonoBehaviour
{
    [SerializeField] LabsState _labsState;
    [SerializeField] SwitchPanel _switchPanel;
    [SerializeField] SelectInsertText _selectInsertText;

    public string showOddLabId;
    public string showEvenLabId;
    public string selectLabId;
    public ObjectData selectLabObjectData;
    public int selectLabIndex;

    private void SetLabId(string labId)
    {
        selectLabId = labId;
        selectLabObjectData = _labsState.labs.objects.FirstOrDefault(x => x.id == labId);
        selectLabIndex = _labsState.labs.objects.IndexOf(selectLabObjectData);
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
