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
    [SerializeField] TMPro.TMP_Text _text;

    private class ArriveLabState
    {
        public string id;
        public bool selected;
        public string status;
    }

    private List<ArriveLabState> arriveLabStates = new List<ArriveLabState>();

    public void SetLabs(List<string> labIds)
    {
        _text.text = "";
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
                _text.text += newState.id + newState.selected.ToString() + newState.status.ToString() + "\n";
                arriveLabStates.Add(newState);
            }
        }
    }

    private bool HasLab(string id)
    {
        //_text.text += "id:" +id + "then" + arriveLabStates.Any(state => state.id == id).ToString() +"\n";
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
        _text.text += "setArrived" + id +"\n";
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
            _text.text += "setSelected" + state.id + "\n";
            state.selected = true;
        }
    }

    public string SelectedId()
    {
        _text.text += "startgetSelectedId" + "\n";
       ArriveLabState state = GetSelected();
        _text.text += "setSelected" + state.id + "\n";
        if (state != null) return state.id;
        return null;
    }
}