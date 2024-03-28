using UnityEngine;

public class LabImagePannel : MonoBehaviour
{
    [SerializeField] GameObject labimage;

    private void Awake()
    {
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

    public void SetImageSize(Vector3 vector3)
    {
        labimage.transform.localScale = vector3;
    }
}
