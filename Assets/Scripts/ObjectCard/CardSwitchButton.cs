using UnityEngine;

public class CardSwitchButton : MonoBehaviour
{
    [SerializeField] private Canvas _searchCanvas;
    [SerializeField] private Canvas _walkCanvas;

    public bool isSearch = true;
    public bool isWalk = false;

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
    }

    private void SetSearch()
    {
        isSearch = true;
        isWalk = false;
        SetIcons();
    }

    private void SetWalk()
    {
        isSearch = false;
        isWalk = true;
        SetIcons();
    }
}
