using System.Collections;
using UnityEngine;

public class ScanFlow : MonoBehaviour
{
    [SerializeField] LabController _labController;

    [SerializeField] ScanInsertCanvas _InsertCanvas;
    [SerializeField] ScanPanelManager _scanPanelManager;

    public IEnumerator WakeScanFlow()
    {
        // �f�[�^�̎擾
        int number = _labController.GetLength();

        // �f�[�^�̑}��
        _InsertCanvas.SetText(number);

        // �E�B���h�E�̕\��
        _scanPanelManager.EnablePannel();

        yield return new WaitForSeconds(4);

        // �E�B���h�E�̏I��
        _scanPanelManager.DisablePannel();
    }
}
