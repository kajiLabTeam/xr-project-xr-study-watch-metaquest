using UnityEngine;
using TMPro;

public class SelectInsertText : MonoBehaviour
{
    [SerializeField] public LabsState _labsState;

    [SerializeField] public TMP_Text _universityName;
    [SerializeField] public TMP_Text _major;
    [SerializeField] public TMP_Text _location;
    [SerializeField] public TMP_Text _labName;

    public void SetText(int n)
    {
        _universityName.text = _labsState.labs.objects[n].university.name;
        _major.text = _labsState.labs.objects[n].university.undergraduate + _labsState.labs.objects[n].university.department + _labsState.labs.objects[n].university.major;
        _location.text = _labsState.labs.objects[n].lab.location + _labsState.labs.objects[n].lab.roomNum;
        _labName.text = _labsState.labs.objects[n].lab.name;
    }
}
