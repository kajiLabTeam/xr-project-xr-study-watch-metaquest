using System.Collections;
using UnityEngine;

public class InitStory : MonoBehaviour
{
    [SerializeField] HowScanObj _howScanObj;
    [SerializeField] GameObject _pokelistButton;
    [SerializeField] SwitchPanel _switchPanel;

    private IEnumerator Start()
    {
        // �I�u�W�F�N�g�̃E�B���h�E�͔�\��
        _switchPanel.CloseNearList();
        _pokelistButton.gameObject.SetActive(false);
        // �ŏ��̃X�L����
        yield return StartCoroutine(_howScanObj.ScanLabData());
        // �\���E�B���h�E�̐؂�ւ�
        _switchPanel.CloseScanPanel();
        _switchPanel.OpenNearList();
    }
}
