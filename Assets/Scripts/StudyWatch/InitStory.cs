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
        // �������摜�͔�\��
        _switchPanel.CloseLabImage();

        // �I�u�W�F�N�g�̃E�B���h�E�͔�\��
        _switchPanel.CloseNearList();
        _switchPanel.CloseSelectObjectCard();
        _pokelistButton.gameObject.SetActive(false);
        // �ŏ��̃X�L����
        yield return StartCoroutine(_howScanObj.ScanLabData());
        // �\���E�B���h�E�̐؂�ւ�
        _switchPanel.CloseScanPanel();
        _switchPanel.OpenNearList();

        yield return new WaitForSeconds(10);
        // �������摜���Z�b�g
        yield return _movePannel.SetLabImage();
        // �������摜��\��
        _switchPanel.OpenLabImage();
    }
}
