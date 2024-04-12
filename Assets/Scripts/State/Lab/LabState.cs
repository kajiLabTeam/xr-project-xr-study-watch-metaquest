using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UniversityInfo
{
    public string name;
    public string undergraduate;
    public string department;
    public string major;
}

[System.Serializable]
public class LabInfo
{
    public string name;
    public string location;
    public string roomNum;
}

[System.Serializable]
public class LabObjectData
{
    public string id;
    public LabInfo laboratory;
    public UniversityInfo university;
}

public class LabState : MonoBehaviour
{
    public List<LabObjectData> aroundObjects = new();
}