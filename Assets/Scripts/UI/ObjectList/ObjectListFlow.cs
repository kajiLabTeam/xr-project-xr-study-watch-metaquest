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

    [SerializeField] TMPro.TMP_Text _textOdd;
    [SerializeField] TMPro.TMP_Text _textEven;

    public List<string> ids;

    public int labNum = 0;
    public int pageNum = 0;
    public int pageLastNum = 0;

    public void PageCountUp()
    {
        if (pageNum > pageLastNum) return;
        pageNum--;
        _textOdd.text += "pageNum" + pageNum.ToString() + "\n";
        _textEven.text += "pageLastNum" + pageLastNum.ToString() + "\n";
        _objectListButton.SetUpButton(pageNum);
        _objectListButton.SetDownButton(pageNum, pageLastNum);
        SetCard();
    }

    public void PageCountDown()
    {
        if (pageNum < 0) return;
        pageNum++;
        _textOdd.text += "pageNum" + pageNum.ToString() + "\n";
        _textEven.text += "pageLastNum" + pageLastNum.ToString() + "\n";
        _objectListButton.SetUpButton(pageNum);
        _objectListButton.SetDownButton(pageNum, pageLastNum);
        SetCard();
    }

    private void SetCard()
    {
        _insertTextOdd.InsertText(
            ids[pageNum * 2],
            _labController
            ) ;
        _selectManager.SetOddId(ids[pageNum * 2]);
        if (pageNum != pageLastNum && labNum % 2 != 0)
        {
            _objectCardEven.gameObject.SetActive(true);
            _insertTextEven.InsertText(
                ids[pageNum * 2 + 1],
                _labController
            );
            _selectManager.SetEvenId(ids[pageNum * 2 + 1]);
        }
        else
        {
            _objectCardEven.gameObject.SetActive(false);
        }
    }

    public void WakeObjectListFlow()
    {
        // id 一覧 と selectId に変更がないか調べる
        if (ids != _labController.GetLabIds())
        {
            // id を全て取得
            ids = _labController.GetLabIds();
            labNum = _labController.GetLength();
            pageLastNum = labNum / 2;
        }
        pageNum = 0;
        _textOdd.text += "pageNum" + pageNum.ToString() + "\n";
        _textEven.text += "pageLastNum" + pageLastNum.ToString() + "\n";

        // 表示内容を決定
        _objectListButton.SetUpButton(pageNum);
        _objectListButton.SetDownButton(pageNum, pageLastNum);
        SetCard();


    }
}