using UnityEngine;

public class GetFollowPannelPosition : MonoBehaviour
{
    [SerializeField] GameObject FollowPannel;

    public Vector3 GetPosition()
    {
        return FollowPannel.transform.position;
    }
}
