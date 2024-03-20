using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] SelectController _selectController;
    [SerializeField] ChangePannelFlow _changePannelFlow;

    [SerializeField] TMPro.TMP_Text _textOdd;
    [SerializeField] TMPro.TMP_Text _textEven;

    public string showOddLabId;
    public string showEvenLabId;

    public void SetLabOdd()
    {
        _textOdd.text += "showOddLabId" + showOddLabId.ToString() + "\n";
        _textEven.text += "\n";
        _selectController.SetIsSelected(showOddLabId);
        _changePannelFlow.SetSelectPannel();
    }

    public void SetLabEven()
    {
        _textOdd.text += "\n";
        _textEven.text += "showEvenLabId" + showEvenLabId.ToString() + "\n";
        _selectController.SetIsSelected(showEvenLabId);
        _changePannelFlow.SetSelectPannel();
    }

    public void SetOddId(string id)
    {
        _textOdd.text += "SetOddId\n";
        _textEven.text += "showOddLabId" + showOddLabId.ToString() + "\n";
        showOddLabId = id;
    }

    public void SetEvenId(string id)
    {
        _textOdd.text += "SetEvenId\n";
        _textEven.text += "showEvenLabId" + showEvenLabId.ToString() + "\n";
        showEvenLabId = id;
    }
}