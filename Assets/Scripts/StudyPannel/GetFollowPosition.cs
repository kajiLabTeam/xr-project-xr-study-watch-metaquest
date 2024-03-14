using UnityEngine;

public class GetFollowPosition : MonoBehaviour
{
    public GameObject FollowPannel;

    Vector3 position;

    private void Start()
    {
        FollowPannel = GetComponent<GameObject>();
    }

    private void Update()
    {
        UpdateFollowPannelPosition();
    }

    private void UpdateFollowPannelPosition()
    {
        if (FollowPannel != null)
        {
            position = FollowPannel.transform.position;
        }
    }

    public Vector3 GetNowPosition()
    {
        return position;
    }
}
