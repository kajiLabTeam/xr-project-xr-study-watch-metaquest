using System.Linq;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField] SelectState _selectState;

    public bool AddSelectInfo(string id)
    {
        if (_selectState.selectInfos.Any(info => info.id == id))
        {
            return false;
        }
        _selectState.selectInfos.Add(new SelectInfo
        {
            id = id,
            isSelected = false,
        });
        return true;
    }

    private bool SetDisableSelect()
    {
        SelectInfo info = _selectState.selectInfos.FirstOrDefault(info => info.isSelected == true);
        
        // info が取得できたか確認
        if (info == null) return true;
        int index = _selectState.selectInfos.IndexOf(info);

        // index が取得できたか確認
        if (index == -1) return false;
        _selectState.selectInfos[index].isSelected = false;
        return true;
    }

    public bool SetIsSelected(string id)
    {
        if (!SetDisableSelect()) return false;
        SelectInfo info = _selectState.selectInfos.FirstOrDefault(info => info.id == id);

        // info が取得できたか確認
        if (info == null) return false;
        int index = _selectState.selectInfos.IndexOf(info);

        // index が取得できたか確認
        if (index == -1) return false;
        _selectState.selectInfos[index].isSelected = true;
        return true;
    }

    public bool GetIsSelected(string id)
    {
        return _selectState.selectInfos.Any(info => info.id == id && info.isSelected);
    }

    public string GetSelectedId()
    {
        SelectInfo info = _selectState.selectInfos.FirstOrDefault(info => info.isSelected);
        if (info == null) return null;
        return info.id;
    }
}
