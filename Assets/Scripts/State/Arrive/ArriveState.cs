using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArriveInfo
{
    public string id;
    public float width;
    public float height;
    public int size;
    public string viewUrl;
    public Texture texture;
}

public class ArriveState : MonoBehaviour
{
    public List<ArriveInfo> arrivingObjects = new();
}
