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
    public string image;
    public string location;
    public string roomNum;
}

[System.Serializable]
public class ObjectData
{
    public string id; 
    public UniversityInfo university;
    public LabInfo lab;
}

[System.Serializable]
public class LabsData
{
    public List<ObjectData> objects = new List<ObjectData>();
}

public class LabsState : MonoBehaviour
{
    public LabsData labs;

    private void Awake()
    {
        labs = new LabsData();
    }
}
