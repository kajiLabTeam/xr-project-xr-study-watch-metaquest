using UnityEngine;
using TMPro;

public class SetCardItem : MonoBehaviour
{
    [SerializeField] LabsState _labsState;

    [SerializeField] GameObject _objectCardOdd;
    [SerializeField] InsertText _insertTextOdd;
    [SerializeField] GameObject _objectCardEven;
    [SerializeField] InsertText _insertTextEven;
    [SerializeField] GameObject _arrowUp;
    [SerializeField] GameObject _arrowDown;

    private int labNum = 0;
    private int pageNum = 0;
    private int pageLastNum = 0;

    public void SetLabData()
    {
        labNum = _labsState.labs.objects.Count;
        pageLastNum = labNum / 2;

        SetButton();
        SetCard();
    }

    public void PageCountUp()
    {
        pageNum ++;
        SetButton();
        SetCard();
    }

    public void PageCountDown()
    {
        pageNum --;
        SetButton();
        SetCard();
    }

    private void SetButton()
    {
        if (pageNum == 0)
        {
            _arrowUp.gameObject.SetActive(false);
        }
        else
        {
            _arrowUp.gameObject.SetActive(true);
        }

        if (pageNum == pageLastNum)
        {
            _arrowDown.gameObject.SetActive(false);
        }
        else
        {
            _arrowDown.gameObject.SetActive(true);
        }
    }

    private void SetCard()
    {
        _insertTextOdd.SetText(pageNum * 2,true);
        if (pageNum != pageLastNum || labNum % 2 == 0)
        {
            _objectCardEven.gameObject.SetActive(true);
            _insertTextEven.SetText(pageNum * 2 + 1,false);
        }
        else
        {
            _objectCardEven.gameObject.SetActive(false);
        }
    }
}
