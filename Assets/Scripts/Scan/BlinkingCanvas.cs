using UnityEngine;

public class BlinkingCanvas : MonoBehaviour
{
    [SerializeField] CanvasGroup _CanvasGroup;
    [SerializeField] bool isBlinking;

    private float Opacity = 0.8f;
    private float timer = 0.0f;
    private float interval = 0.4f;


    void Start()
    {
        _CanvasGroup.alpha = 0.0f;
    }

    void Update()
    {
        if (isBlinking)
        _CanvasGroup.alpha = Opacity;

        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0.0f;
            SwitchOpacity();
        }
    }

    private void SwitchOpacity()
    {
        if (Opacity == 0.8f)
        {
            Opacity = 0.4f;
        }
        else if (Opacity < 0.8f)
        {
            Opacity += 0.2f;
        }
    }

    public void TrunOnBlinking()
    {
        isBlinking = true;
        _CanvasGroup.alpha = 0.8f;
    }

    public void TrunOffBlinking()
    {
        isBlinking = false;
        _CanvasGroup.alpha = 0.8f;
    }
}