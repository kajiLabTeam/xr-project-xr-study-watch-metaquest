using UnityEngine;

public class LabImagePannel : MonoBehaviour
{
    [SerializeField] GameObject labimage;

    private void Awake()
    {
        EnableLabImage();
        DisableLabImage();
    }

    public void SetLabImagePosition(Vector3 position)
    {
        labimage.transform.position = position;
    }

    public void EnableLabImage()
    {
        labimage.SetActive(true);
    }

    public void DisableLabImage()
    {
        labimage.SetActive(false);
    }
}
