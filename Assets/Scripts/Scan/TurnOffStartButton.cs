using UnityEngine;

public class TurnOffStartButton : MonoBehaviour
{
    [SerializeField] CanvasGroup _CanvasGroup;

    private void Start()
    {
        _CanvasGroup.alpha = 0.8f;
    }
    public void TurnOffCanvas()
    {
        _CanvasGroup.gameObject.SetActive(false);
    }
}
