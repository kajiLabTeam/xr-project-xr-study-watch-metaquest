using UnityEngine;

public class UnSelectObjectPannel : MonoBehaviour
{
    [SerializeField] ChangePannelManager _changePannelManager;
    [SerializeField] SelectController _selectController;

    public void WakeUnselectObjectPannel()
    {
        // remove selectId
        _selectController.SetDisableSelect();
        // disable object pannel
        _changePannelManager.DisableSelectObject();
    }    
}
