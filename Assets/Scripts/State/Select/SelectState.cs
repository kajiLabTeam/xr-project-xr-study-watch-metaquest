using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectInfo
{
    public string id;
    public bool isSelected;
}

public class SelectState : MonoBehaviour
{
    public List<SelectInfo> selectInfos = new();
}
