using System.Collections.Generic;
using UnityEngine;

public class ObjectListFlow : MonoBehaviour
{
    [SerializeField] LabController _labController;
    [SerializeField] SelectManager _selectManager;
    [SerializeField] ObjectListButton _objectListButton;

    [SerializeField] GameObject _objectCardOdd;
    [SerializeField] ObjectListInsertCanvas _insertTextOdd;
    [SerializeField] GameObject _objectCardEven;
    [SerializeField] ObjectListInsertCanvas _insertTextEven;

    public List<string> ids;

    public int labNum = 0;
    public int pageNum = 0;
    public int pageLastNum = 0;

    public void PageCountUp()
    {
        // �\���͈͊O�̏ꍇ��������
        if (pageNum > pageLastNum) return;

        // �y�[�W��O�ɖ߂�
        pageNum--;
        // �\�����Z�b�g
        _objectListButton.SetUpButton(pageNum);
        _objectListButton.SetDownButton(pageNum, pageLastNum);
        SetCard();
    }

    public void PageCountDown()
    {
        // �\���͈͊O�̏ꍇ��������
        if (pageNum < 0) return;
        // �y�[�W��O�ɖ߂�
        pageNum++;

        // �\�����Z�b�g
        _objectListButton.SetUpButton(pageNum);
        _objectListButton.SetDownButton(pageNum, pageLastNum);
        SetCard();
    }

    private void SetCard()
    {
        // ��i��̃J�[�h�̏ꍇ�j
        // �e�L�X�g���Z�b�g
        _insertTextOdd.InsertText(
            ids[pageNum * 2],
            _labController
            ) ;
        // �\������ id ��n��
        _selectManager.SetOddId(ids[pageNum * 2]);
        
        // �����i���̃J�[�h�̏ꍇ�j
        // �f�[�^�������ꍇ�͕\�����Ȃ�
        if (pageNum != pageLastNum && labNum % 2 != 0)
        {
            // �J�[�h��\��
            _objectCardEven.gameObject.SetActive(true);
            // �e�L�X�g���Z�b�g
            _insertTextEven.InsertText(
                ids[pageNum * 2 + 1],
                _labController
            );
            // �\������ id ��n��
            _selectManager.SetEvenId(ids[pageNum * 2 + 1]);
        }
        else
        {
            // �\������߂�
            _objectCardEven.gameObject.SetActive(false);
            // id ��������
            _selectManager.SetEvenId("");
        }
    }

    public void WakeObjectListFlow()
    {
        // id �ꗗ �� selectId �ɕύX���Ȃ������ׂ�
        if (ids != _labController.GetLabIds())
        {
            // id ��S�Ď擾
            ids = _labController.GetLabIds();
            labNum = _labController.GetLength();
            pageNum = 0;
            pageLastNum = labNum / 2;
        }

        // �\�����e������
        _objectListButton.SetUpButton(pageNum);
        _objectListButton.SetDownButton(pageNum, pageLastNum);
        SetCard();
    }
}