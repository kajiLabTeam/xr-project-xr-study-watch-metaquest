using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    
    [SerializeField] GameObject _scanObject;
    [SerializeField] GameObject _nearObject;
    [SerializeField] GameObject _openButton;
    [SerializeField] GameObject _closeButton;
    [SerializeField] GameObject _selectObjectCard;
    [SerializeField] GameObject _labImage;

    [SerializeField] SetCardItem _setCardItem;
    [SerializeField] SelectLab _selectLab;

    public void OpenNearList()
    {
        _setCardItem.SetLabData();
        _nearObject.gameObject.SetActive(true);
        _openButton.gameObject.SetActive(false);
        _closeButton.gameObject.SetActive(true);
        if (_selectLab.selectLabId != "")
        {
            CloseSelectObjectCard();
        }
    }

    public void CloseNearList()
    {
        _nearObject.gameObject.SetActive(false);
        _openButton.gameObject.SetActive(true);
        _closeButton.gameObject.SetActive(false);
        if (_selectLab.selectLabId != "")
        {
            OpenSelectObjectCard();
        }
    }

    public void OpenScanPanel()
    {
        _scanObject.gameObject.SetActive(true);
    }

    public void CloseScanPanel()
    {
        _scanObject.gameObject.SetActive(false);
    }

    public void OpenSelectObjectCard()
    {
        _selectObjectCard.gameObject.SetActive(true);
    }

    public void CloseSelectObjectCard()
    {
        _selectObjectCard.gameObject.SetActive(false);
    }

    public void OpenLabImage()
    {
        _labImage.gameObject.SetActive(true);
    }
    public void CloseLabImage()
    {
        _labImage.gameObject.SetActive(false);
    }
}
