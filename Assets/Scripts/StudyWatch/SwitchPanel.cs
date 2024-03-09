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
        // �I�u�W�F�N�g�̃E�B���h�E�͔�\��
        _nearObject.gameObject.SetActive(false);
        _pokelistButton.gameObject.SetActive(false);
        // �ŏ��̃X�L����
        yield return StartCoroutine(_howScanObj.ScanLabData());
        // �\���E�B���h�E�̐؂�ւ�
        _scanObject.gameObject.SetActive(false);
        _nearObject.gameObject.SetActive(true);
        _pokelistButton.gameObject.SetActive(true);
        SetCloseButton();
        // �I�u�W�F�N�g�̕\��������
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
