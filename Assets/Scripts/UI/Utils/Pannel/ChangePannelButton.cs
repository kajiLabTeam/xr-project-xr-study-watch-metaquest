using UnityEngine;

public class ChangePannelButton : MonoBehaviour
{
    [SerializeField] GameObject _closeButton;
    [SerializeField] GameObject _starButton;

    private void Awake()
    {
        SetStarButton();
    }

    public void SetCloseButton()
    {
        _closeButton.gameObject.SetActive(true);
        _starButton.gameObject.SetActive(false);
    }

    public void SetStarButton()
    {
        _closeButton.gameObject.SetActive(false);
        _starButton.gameObject.SetActive(true);
    }
}
