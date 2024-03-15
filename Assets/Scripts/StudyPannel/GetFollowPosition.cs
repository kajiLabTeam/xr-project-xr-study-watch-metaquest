using UnityEngine;
using TMPro;

public class GetFollowPosition : MonoBehaviour
{
    [SerializeField] GameObject FollowPannel;

    public Vector3 GetNowPosition()
    {
        return FollowPannel.transform.position;
    }
}
