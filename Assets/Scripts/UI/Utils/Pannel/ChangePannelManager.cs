using UnityEngine;

public class ChangePannelManager : MonoBehaviour
{
    [SerializeField] GameObject NearObject;
    [SerializeField] GameObject SelectObject;

    private void Awake()
    {
        DisableNearObject();
        DisableSelectObject();
    }

    public void EnableNearObject()
    {
        NearObject.SetActive(true);
    }

    public void DisableNearObject()
    {
        NearObject.SetActive(false);
    }

    public void EnableSelectObject()
    {
        SelectObject.SetActive(true);
    }

    public void DisableSelectObject()
    {
        SelectObject.SetActive(false); 
    }
}
