using UnityEngine;

public class SelectObjectFlow : MonoBehaviour
{
    [SerializeField] LabController _labController;
    [SerializeField] SelectController _selectController;

    [SerializeField] SelectObjectInsertCanvas _selectObjectInsertCanvas;

    private string selectedId = null;

    public bool WakeSelectObjectFlow()
    {
        // id に基づく情報の取得
        selectedId = _selectController.GetSelectedId();
        if (selectedId == null) return false;
        // 情報の挿入
        _selectObjectInsertCanvas.InsertText(selectedId, _labController);
        return true;
    }
}
