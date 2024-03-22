using UnityEngine;

public class SelectObjectFlow : MonoBehaviour
{
    [SerializeField] LabController _labController;
    [SerializeField] SelectController _selectController;

    [SerializeField] SelectObjectInsertCanvas _selectObjectInsertCanvas;

    private string selectedId = null;

    public bool WakeSelectObjectFlow()
    {
        // id �Ɋ�Â����̎擾
        selectedId = _selectController.GetSelectedId();
        if (selectedId == null) return false;
        // ���̑}��
        _selectObjectInsertCanvas.InsertText(selectedId, _labController);
        return true;
    }
}
