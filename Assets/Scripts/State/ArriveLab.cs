using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ArriveStatus
{
    Searching,
    Arrived,
    Leaved
}

public class ArriveLab : MonoBehaviour
{
    private class ArriveLabState
    {
        public string id;
        public string status = ArriveStatus.Searching.ToString();
    }


    private List<ArriveLabState> arriveLabStates = new List<ArriveLabState>();

    public void SetLabs(string[] labIds)
    {
        foreach (string id in labIds)
        {
            if (!HasLab(id)) // 既に存在する ID でないかを確認
            {
                ArriveLabState newState = new ArriveLabState();
                newState.id = id;
                arriveLabStates.Add(newState); // リストに追加
            }
        }
    }

    private bool HasLab(string id)
    {
        foreach (ArriveLabState state in arriveLabStates)
        {
            if (state.id == id)
            {
                return true; // ID がすでに存在する場合は true を返す
            }
        }
        return false;
    }

    private void SetStatus(string id, ArriveStatus statusCode)
    {
        ArriveLabState state = arriveLabStates.FirstOrDefault(s => s.id == id);
        if (state != null)
        {
            state.status = statusCode.ToString();
        }
    }

    public void SetArrived(string id)
    {
        SetStatus(id, ArriveStatus.Arrived);
    }

    public void SetLeaved(string id)
    {
        SetStatus(id, ArriveStatus.Leaved);
    }
}