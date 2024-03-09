using System.Collections;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    [SerializeField] GameObject _scanObject;
    [SerializeField] HowScanObj _howScanObj;
    [SerializeField] GameObject _nearObject;
    [SerializeField] SetCardItem _setCardItem;
    [SerializeField] GameObject _pokelistButton;

    [SerializeField] GameObject _closeButton;
    [SerializeField] GameObject _starButton;

    public bool isClose = false;
    public bool isStar = true;

    private IEnumerator Start()
    {
        // オブジェクトのウィンドウは非表示
        _nearObject.gameObject.SetActive(false);
        _pokelistButton.gameObject.SetActive(false);
        // 最初のスキャン
        yield return StartCoroutine(_howScanObj.ScanLabData());
        // 表示ウィンドウの切り替え
        _scanObject.gameObject.SetActive(false);
        _nearObject.gameObject.SetActive(true);
        _pokelistButton.gameObject.SetActive(true);
        SetCloseButton();
        // オブジェクトの表示を決定
        _setCardItem.SetLabData();
    }


    public void ChangeListButton()
    {
        if (isClose)
        {
            SetStarButton();
            CloseList();
        }
        else
        {
            SetCloseButton();
            OpenList();
        }
    }

    public void SetCloseButton()
    {
        isClose = true;
        isStar = false;
        SetButton();
    }

    public void SetStarButton()
    {
        isClose = false;
        isStar = true;
        SetButton();
    }

    private void SetButton()
    {
        _closeButton.SetActive(isClose);
        _starButton.SetActive(isStar);
    }

    public void OpenList()
    {
        _nearObject.gameObject.SetActive(true);
    }

    public void CloseList()
    {
        _nearObject.gameObject.SetActive(false);
    }
}
