using UnityEngine;

public class SelectObjectFlow : MonoBehaviour
{
    [SerializeField] LabController _labController;
    [SerializeField] SelectController _selectController;

    [SerializeField] SelectObjectInsertCanvas _selectObjectInsertCanvas;

    private string selectedId = null;

    public void WakeSelectObjectFlow(TMPro.TMP_Text _text)
    {
        //// 選択中のオブジェクトを取得 & 比較
        //if (!_selectController.GetIsSelected(selectedId))
        //{
        //    return;
        //}

        _text.text += "get id\n";
        // id に基づく情報の取得
        selectedId = _selectController.GetSelectedId();
        _text.text += "id" + selectedId + "\n";
        _text.text += "insert data\n";
        // 情報の挿入
        _selectObjectInsertCanvas.InsertText(selectedId, _labController);
    }
}
