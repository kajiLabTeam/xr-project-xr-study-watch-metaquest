using UnityEngine;

public class ObjectListButton : MonoBehaviour
{
    [SerializeField] GameObject _arrowUp;
    [SerializeField] GameObject _arrowDown;

    public void SetUpButton(int pageNum)
    {
        if (pageNum == 0)
        {
            _arrowUp.SetActive(false);
        }
        else
        {
            _arrowUp.SetActive(true);
        }
    }

    public void SetDownButton(int pageNum,int pageLastNum)
    {
        if (pageNum == pageLastNum)
        {
            _arrowDown.SetActive(false);
        }
        else
        {
            _arrowDown.SetActive(true);
        }
    }
}
