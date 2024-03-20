using UnityEngine;

public class SelectObjectFlow : MonoBehaviour
{
    [SerializeField] LabController _labController;
    [SerializeField] SelectController _selectController;

    [SerializeField] SelectObjectInsertCanvas _selectObjectInsertCanvas;

    private string selectedId = null;

    public bool WakeSelectObjectFlow()
    {
        // id ‚ÉŠî‚Ã‚­î•ñ‚Ìæ“¾
        selectedId = _selectController.GetSelectedId();
        if (selectedId == null) return false;
        // î•ñ‚Ì‘}“ü
        _selectObjectInsertCanvas.InsertText(selectedId, _labController);
        return true;
    }
}
