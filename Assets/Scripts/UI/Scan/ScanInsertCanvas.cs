using TMPro;
using UnityEngine;

public class ScanInsertCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private string beforeText = "���ӂ�";
    private string afterText = "�̃I�u�W�F�N�g������܂�";

    public void SetText(int number)
    {
        _text.text = beforeText + number.ToString() + afterText;
    }
}
