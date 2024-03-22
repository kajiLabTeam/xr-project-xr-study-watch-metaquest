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
        // 表示範囲外の場合無視する
        if (pageNum > pageLastNum) return;

        // ページを前に戻す
        pageNum--;
        // 表示をセット
        _objectListButton.SetUpButton(pageNum);
        _objectListButton.SetDownButton(pageNum, pageLastNum);
        SetCard();
    }

    public void PageCountDown()
    {
        // 表示範囲外の場合無視する
        if (pageNum < 0) return;
        // ページを前に戻す
        pageNum++;

        // 表示をセット
        _objectListButton.SetUpButton(pageNum);
        _objectListButton.SetDownButton(pageNum, pageLastNum);
        SetCard();
    }

    private void SetCard()
    {
        // 奇数（上のカードの場合）
        // テキストをセット
        _insertTextOdd.InsertText(
            ids[pageNum * 2],
            _labController
            ) ;
        // 表示中の id を渡す
        _selectManager.SetOddId(ids[pageNum * 2]);
        
        // 偶数（下のカードの場合）
        // データが無い場合は表示しない
        if (pageNum != pageLastNum && labNum % 2 != 0)
        {
            // カードを表示
            _objectCardEven.gameObject.SetActive(true);
            // テキストをセット
            _insertTextEven.InsertText(
                ids[pageNum * 2 + 1],
                _labController
            );
            // 表示中の id を渡す
            _selectManager.SetEvenId(ids[pageNum * 2 + 1]);
        }
        else
        {
            // 表示をやめる
            _objectCardEven.gameObject.SetActive(false);
            // id を初期化
            _selectManager.SetEvenId("");
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
            pageNum = 0;
            pageLastNum = labNum / 2;
        }

        // 表示内容を決定
        _objectListButton.SetUpButton(pageNum);
        _objectListButton.SetDownButton(pageNum, pageLastNum);
        SetCard();
    }
}