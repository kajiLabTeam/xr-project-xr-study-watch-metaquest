using System.Collections;
using UnityEngine;

public class ScanFlow : MonoBehaviour
{
    [SerializeField] LabController _labController;

    [SerializeField] ScanInsertCanvas _InsertCanvas;
    [SerializeField] ScanPanelManager _scanPanelManager;

    public IEnumerator WakeScanFlow()
    {
        // データの取得
        int number = _labController.GetLength();

        // データの挿入
        _InsertCanvas.SetText(number);

        // ウィンドウの表示
        _scanPanelManager.EnablePannel();

        yield return new WaitForSeconds(4);

        // ウィンドウの終了
        _scanPanelManager.DisablePannel();
    }
}
