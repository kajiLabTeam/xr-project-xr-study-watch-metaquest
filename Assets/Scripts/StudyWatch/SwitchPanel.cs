using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    [SerializeField] GameObject _scanObject;
    [SerializeField] GameObject _nearObject;
    [SerializeField] GameObject _openButton;
    [SerializeField] GameObject _closeButton;

    [SerializeField] SetCardItem _setCardItem;

    public void OpenNearList()
    {
        _setCardItem.SetLabData();
        _nearObject.gameObject.SetActive(true);
        _openButton.gameObject.SetActive(false);
        _closeButton.gameObject.SetActive(true);
    }

    public void CloseNearList()
    {
        _nearObject.gameObject.SetActive(false);
        _openButton.gameObject.SetActive(true);
        _closeButton.gameObject.SetActive(false);
    }

    public void OpenScanPanel()
    {
        _scanObject.gameObject.SetActive(true);
    }

    public void CloseScanPanel()
    {
        _scanObject.gameObject.SetActive(false);
    }
}
