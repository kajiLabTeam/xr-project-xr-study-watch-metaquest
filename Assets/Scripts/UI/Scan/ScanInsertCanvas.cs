using TMPro;
using UnityEngine;

public class ScanInsertCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private string beforeText = "周辺に";
    private string afterText = "つのオブジェクトがあります";

    public void SetText(int number)
    {
        _text.text = beforeText + number.ToString() + afterText;
    }
}
