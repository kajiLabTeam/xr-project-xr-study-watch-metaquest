using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArriveController : MonoBehaviour
{
    [SerializeField] ArriveState _arriveState;

    public bool AddArriveInfo(ArriveInfo arriveInfo)
    {
        if(_arriveState.arrivingObjects.Contains(arriveInfo))
        {
            return false;
        }
        _arriveState.arrivingObjects.Add(arriveInfo);
        return true;
    }

    public List<string> GetArriveIds()
    {
        var arriveIds = new List<string>();
        foreach(var lab in _arriveState.arrivingObjects)
        {
            arriveIds.Add(lab.id);
        }
        return arriveIds;
    }

    private ArriveInfo GetArriveInfo(string id)
    {
        return _arriveState.arrivingObjects.FirstOrDefault(x => x.id == id);
    }

    public string GetImageURL(string id)
    {
        string url = GetArriveInfo(id).viewUrl;
        if (url == null) return null;
        return url;
    }

    public Vector3 GetImageAspect(string id)
    {
        float width = float.Parse(GetArriveInfo(id).width);
        float height = float.Parse(GetArriveInfo(id).height);
        if (width <= 0 || height <= 0) return Vector3.zero;
        Vector3 vector3 = new Vector3(width,height,1);
        return vector3;
    }
}
