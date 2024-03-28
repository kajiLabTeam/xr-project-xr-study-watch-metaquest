using UnityEngine;
using UnityEngine.UI;

public class ImagePannelController : MonoBehaviour
{
    [SerializeField] GameObject LabImageQuad;
    public void SetImageSize(Vector3 vector3)
    {
        LabImageQuad.transform.localScale = vector3;
    }
}
