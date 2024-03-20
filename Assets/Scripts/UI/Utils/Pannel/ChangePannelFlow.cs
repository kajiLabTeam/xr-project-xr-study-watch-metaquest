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
        // ボタンの変更
        _changePannelButton.SetCloseButton();
        _text.text += "set list\n";
        // 表示内容をセット
        _objectListFlow.WakeObjectListFlow();
        _text.text += "close window\n";
        // 閉じていたウィンドウを開く
        _changePannelManager.EnableNearObject();
        _text.text += "open window\n";
        // 開いているウィンドウを閉じる
        _scanPanelManager.DisablePannel();
        _changePannelManager.DisableSelectObject();
    }

    public void SetSelectPannel()
    {
        _text.text += "set button\n";
        // ボタンの変更
        _changePannelButton.SetStarButton();
        _text.text += "set list\n";
        // 表示内容をセット
        _selectObjectFlow.WakeSelectObjectFlow(_text);
        // 閉じていたウィンドウを開く
        _text.text += "close window\n";
        _changePannelManager.EnableSelectObject();
        _text.text += "open window\n";
        // 開いているウィンドウを閉じる
        _scanPanelManager.DisablePannel();
        _changePannelManager.DisableNearObject();
    }
}
