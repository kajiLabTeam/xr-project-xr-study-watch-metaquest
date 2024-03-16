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
        public bool selected;
        public string status;
    }

    private List<ArriveLabState> arriveLabStates = new List<ArriveLabState>();

    public void SetLabs(List<string> labIds)
    {
        foreach (string id in labIds)
        {
            if (!HasLab(id))
            {
                ArriveLabState newState = new ArriveLabState()
                {
                    id = id,
                    selected = false,
                    status = ArriveStatus.Searching.ToString()
                };
                arriveLabStates.Add(newState);
            }
        }
    }

    private bool HasLab(string id)
    {
        return arriveLabStates.Any(state => state.id == id);
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

    private ArriveLabState GetSelected()
    {
        return arriveLabStates.FirstOrDefault(s => s.selected);
    }

    public void SetSelected(string id)
    {
        ArriveLabState state = GetSelected();
        if (state != null)
        {
            state.selected = false;
        }

        state = arriveLabStates.FirstOrDefault(s => s.id == id);
        if (state != null)
        {
            state.selected = true;
        }
    }

    public string SelectedId()
    {
        ArriveLabState state = GetSelected();
        if (state != null) return state.id;
        return null;
    }
}