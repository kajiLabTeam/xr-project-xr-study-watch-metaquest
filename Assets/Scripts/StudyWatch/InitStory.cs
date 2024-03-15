using System.Collections;
using UnityEngine;

public class InitStory : MonoBehaviour
{
    [SerializeField] HowScanObj _howScanObj;
    [SerializeField] GameObject _pokelistButton;
    [SerializeField] SwitchPanel _switchPanel;

    [SerializeField] MovePannel _movePannel;
    [SerializeField] LabsState _labsState;
    [SerializeField] ArriveLab _arriveLab;

    private IEnumerator Start()
    {
        // 研究室画像は非表示
        _switchPanel.CloseLabImage();

        // オブジェクトのウィンドウは非表示
        _switchPanel.CloseNearList();
        _switchPanel.CloseSelectObjectCard();
        _pokelistButton.gameObject.SetActive(false);
        // 最初のスキャン
        yield return StartCoroutine(_howScanObj.ScanLabData());
        // 表示ウィンドウの切り替え
        _switchPanel.CloseScanPanel();
        _switchPanel.OpenNearList();

        yield return new WaitForSeconds(10);
        // 研究室画像をセット
        yield return _movePannel.SetLabImage();
        // 研究室画像を表示
        _switchPanel.OpenLabImage();
    }
}
