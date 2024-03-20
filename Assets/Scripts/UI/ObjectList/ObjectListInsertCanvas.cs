using TMPro;
using UnityEngine;

public class ObjectListInsertCanvas : MonoBehaviour
{
    [SerializeField] public TMP_Text _universityName;
    [SerializeField] public TMP_Text _major;
    [SerializeField] public TMP_Text _location;
    [SerializeField] public TMP_Text _labName;

    public void InsertText(string id,LabController _labController)
    {
        _universityName.text = _labController.GetUniversityName(id);
        _major.text = _labController.GetUniversityMoreMajor(id);
        _location.text = _labController.GetLabLocationRoomNum(id);
        _labName.text = _labController.GetLabName(id);
    }
}
