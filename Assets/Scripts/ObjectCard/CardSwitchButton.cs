using UnityEngine;

public class CardSwitchButton : MonoBehaviour
{
    [SerializeField] private Canvas _searchCanvas;
    [SerializeField] private Canvas _walkCanvas;
    [SerializeField] private Canvas _visibilityCanvas;
    [SerializeField] private Canvas _visibilityOffCanvas;

    public bool isSearch = true;
    public bool isWalk = false;
    public bool isVisibility = false;
    public bool isVisibilityOff = false;

    private void Start()
    {
        SetIcons();
    }

    public void SetButtonIcon(string icon)
    {
        switch (icon)
        {
            case ("search"):
                {
                    if (isSearch) return;
                    SetSearch();
                    break;
                }
            case ("walk"):
                {
                    if (isWalk) return;
                    SetWalk();
                    break;
                }
            case ("visibility"):
                {
                    if (isVisibility) return;
                    SetVisibility();
                    break;
                }
            case ("visibilityOff"):
                {
                    if (isVisibilityOff) return;
                    SetVisibilityOff();
                    break;
                }
            default:
                {
                    if (isSearch) return;
                    SetSearch();
                    break;
                }
        }
    }

    private void SetIcons()
    {
        _searchCanvas.enabled = isSearch;
        _walkCanvas.enabled = isWalk;
        _visibilityCanvas.enabled = isVisibility;
        _visibilityOffCanvas.enabled = isVisibilityOff;
    }

    private void SetSearch()
    {
        isSearch = true;
        isWalk = false;
        isVisibility = false;
        isVisibilityOff = false;
        SetIcons();
    }

    private void SetWalk()
    {
        isSearch = false;
        isWalk = true;
        isVisibility = false;
        isVisibilityOff = false;
        SetIcons();
    }

    private void SetVisibility()
    {
        isSearch = false;
        isWalk = false;
        isVisibility = true;
        isVisibilityOff = false;
        SetIcons();
    }

    private void SetVisibilityOff()
    {
        isSearch = false;
        isWalk = false;
        isVisibility = false;
        isVisibilityOff = true;
        SetIcons();
    }
}
