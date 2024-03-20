using UnityEngine;

public class ChangePannelFlow : MonoBehaviour
{
    [SerializeField] ObjectListFlow _objectListFlow;
    [SerializeField] SelectObjectFlow _selectObjectFlow;
    [SerializeField] ChangePannelManager _changePannelManager;
    [SerializeField] ChangePannelButton _changePannelButton;
    [SerializeField] ScanPanelManager _scanPanelManager;

    [SerializeField] TMPro.TMP_Text _text;

    public void SetListPannel()
    {
        _text.text += "set button\n";
        // �{�^���̕ύX
        _changePannelButton.SetCloseButton();
        _text.text += "set list\n";
        // �\�����e���Z�b�g
        _objectListFlow.WakeObjectListFlow();
        _text.text += "close window\n";
        // ���Ă����E�B���h�E���J��
        _changePannelManager.EnableNearObject();
        _text.text += "open window\n";
        // �J���Ă���E�B���h�E�����
        _scanPanelManager.DisablePannel();
        _changePannelManager.DisableSelectObject();
    }

    public void SetSelectPannel()
    {
        _text.text += "set button\n";
        // �{�^���̕ύX
        _changePannelButton.SetStarButton();
        _text.text += "set list\n";
        // �\�����e���Z�b�g
        _selectObjectFlow.WakeSelectObjectFlow(_text);
        // ���Ă����E�B���h�E���J��
        _text.text += "close window\n";
        _changePannelManager.EnableSelectObject();
        _text.text += "open window\n";
        // �J���Ă���E�B���h�E�����
        _scanPanelManager.DisablePannel();
        _changePannelManager.DisableNearObject();
    }
}
