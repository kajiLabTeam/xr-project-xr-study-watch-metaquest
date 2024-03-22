using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] SelectController _selectController;
    [SerializeField] ChangePannelFlow _changePannelFlow;

    public string showOddLabId;
    public string showEvenLabId;

    // Poke�̓��͂��󂯂�֐�
    public void SetLabOdd()
    {
        _selectController.SetIsSelected(showOddLabId);
        _changePannelFlow.SetSelectPannel();
    }

    public void SetLabEven()
    {
        _selectController.SetIsSelected(showEvenLabId);
        _changePannelFlow.SetSelectPannel();
    }

    // �y�[�W���肳�ꂽ�ꍇ�ɐV���� id ���Z�b�g����
    public void SetOddId(string id)
    {
        showOddLabId = id;
    }

    public void SetEvenId(string id)
    {
        showEvenLabId = id;
    }
}