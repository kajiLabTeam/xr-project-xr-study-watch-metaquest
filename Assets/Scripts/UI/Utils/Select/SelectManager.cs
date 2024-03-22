using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] SelectController _selectController;
    [SerializeField] ChangePannelFlow _changePannelFlow;

    public string showOddLabId;
    public string showEvenLabId;

    // Pokeの入力を受ける関数
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

    // ページ送りされた場合に新しい id をセットする
    public void SetOddId(string id)
    {
        showOddLabId = id;
    }

    public void SetEvenId(string id)
    {
        showEvenLabId = id;
    }
}