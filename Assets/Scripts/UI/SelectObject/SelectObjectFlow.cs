using UnityEngine;

public class SelectObjectFlow : MonoBehaviour
{
    [SerializeField] LabController _labController;
    [SerializeField] SelectController _selectController;

    [SerializeField] SelectObjectInsertCanvas _selectObjectInsertCanvas;

    private string selectedId = null;

    public void WakeSelectObjectFlow(TMPro.TMP_Text _text)
    {
        //// �I�𒆂̃I�u�W�F�N�g���擾 & ��r
        //if (!_selectController.GetIsSelected(selectedId))
        //{
        //    return;
        //}

        _text.text += "get id\n";
        // id �Ɋ�Â����̎擾
        selectedId = _selectController.GetSelectedId();
        _text.text += "id" + selectedId + "\n";
        _text.text += "insert data\n";
        // ���̑}��
        _selectObjectInsertCanvas.InsertText(selectedId, _labController);
    }
}
