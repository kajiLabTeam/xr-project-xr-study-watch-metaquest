using UnityEngine;

public class ScanPanelManager : MonoBehaviour
{
    [SerializeField] GameObject _pannel;

    private void Awake()
    {
        DisablePannel();
    }

    public void EnablePannel()
    {
        _pannel.SetActive(true);
    }

    public void DisablePannel()
    {
        _pannel.SetActive(false);
    }
}
