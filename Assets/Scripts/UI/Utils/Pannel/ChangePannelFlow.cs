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
        // ボタンの変更
        _changePannelButton.SetCloseButton();
        // 表示内容をセット
        _objectListFlow.WakeObjectListFlow();
        // 閉じていたウィンドウを開く
        _changePannelManager.EnableNearObject();
        // 開いているウィンドウを閉じる
        _scanPanelManager.DisablePannel();
        _changePannelManager.DisableSelectObject();
    }

    public void SetSelectPannel()
    {
        // ボタンの変更
        _changePannelButton.SetStarButton();
        // 表示内容をセット
        if (!_selectObjectFlow.WakeSelectObjectFlow())
        {
            // 開いているウィンドウを閉じる
            _scanPanelManager.DisablePannel();
            _changePannelManager.DisableSelectObject();
            _changePannelManager.DisableNearObject();
            return;
        }
        // 閉じていたウィンドウを開く
        _changePannelManager.EnableSelectObject();
        // 開いているウィンドウを閉じる
        _scanPanelManager.DisablePannel();
        _changePannelManager.DisableNearObject();
    }
}
