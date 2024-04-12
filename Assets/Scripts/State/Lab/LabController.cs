using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LabController : MonoBehaviour
{
    [SerializeField] LabState _labState;

    public bool AddLabData(LabObjectData objectData)
    {
        if (_labState.aroundObjects.Any(s => s.id == objectData.id))
        {
            return false;
        }
        _labState.aroundObjects.Add(objectData);
        return true;
    }

    public int GetLength()
    {
        return _labState.aroundObjects.Count;
    }

    public List<string> GetLabIds()
    {
        var labIds = new List<string>();
        foreach (var lab in _labState.aroundObjects)
        {
            labIds.Add(lab.id);
        }
        return labIds;
    }

    private LabObjectData GetObjectData(string id)
    {
        return _labState.aroundObjects.FirstOrDefault(lab => lab.id == id);
    }

    public string GetLabName(string id)
    {
        return GetObjectData(id).laboratory.name;
    }

    public string GetLabLocationRoomNum(string id)
    {
        LabObjectData objectData = GetObjectData(id);
        return objectData.laboratory.location + objectData.laboratory.roomNum;
    }

    public string GetUniversityName(string id)
    {
        return GetObjectData(id).university.name;
    }

    public string GetUniversityMoreMajor(string id)
    {
        LabObjectData objectData = GetObjectData(id);
        return objectData.university.undergraduate + objectData.university.department + objectData.university.major;
    }
}
