using UnityEngine;

public class ChangePannelFlow : MonoBehaviour
{
    [SerializeField] ObjectListFlow _objectListFlow;
    [SerializeField] SelectObjectFlow _selectObjectFlow;
    [SerializeField] ChangePannelManager _changePannelManager;
    [SerializeField] ChangePannelButton _changePannelButton;
    [SerializeField] ScanPanelManager _scanPanelManager;

    public void SetListPannel()
    {
        // �{�^���̕ύX
        _changePannelButton.SetCloseButton();
        // �\�����e���Z�b�g
        _objectListFlow.WakeObjectListFlow();
        // ���Ă����E�B���h�E���J��
        _changePannelManager.EnableNearObject();
        // �J���Ă���E�B���h�E�����
        _scanPanelManager.DisablePannel();
        _changePannelManager.DisableSelectObject();
    }

    public void SetSelectPannel()
    {
        // �{�^���̕ύX
        _changePannelButton.SetStarButton();
        // �\�����e���Z�b�g
        if (!_selectObjectFlow.WakeSelectObjectFlow())
        {
            // �J���Ă���E�B���h�E�����
            _scanPanelManager.DisablePannel();
            _changePannelManager.DisableSelectObject();
            _changePannelManager.DisableNearObject();
            return;
        }
        // ���Ă����E�B���h�E���J��
        _changePannelManager.EnableSelectObject();
        // �J���Ă���E�B���h�E�����
        _scanPanelManager.DisablePannel();
        _changePannelManager.DisableNearObject();
    }
}
