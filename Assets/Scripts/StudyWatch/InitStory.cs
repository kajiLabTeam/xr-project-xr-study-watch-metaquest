using System.Collections;
using UnityEngine;

public class InitStory : MonoBehaviour
{
    [SerializeField] HowScanObj _howScanObj;
    [SerializeField] GameObject _pokelistButton;
    [SerializeField] SwitchPanel _switchPanel;

    private IEnumerator Start()
    {
        // オブジェクトのウィンドウは非表示
        _switchPanel.CloseNearList();
        _pokelistButton.gameObject.SetActive(false);
        // 最初のスキャン
        yield return StartCoroutine(_howScanObj.ScanLabData());
        // 表示ウィンドウの切り替え
        _switchPanel.CloseScanPanel();
        _switchPanel.OpenNearList();
    }
}
