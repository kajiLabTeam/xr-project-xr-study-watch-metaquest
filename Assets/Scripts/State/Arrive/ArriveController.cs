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
        return GetArriveInfo(id).viewUrl;
    }
}
