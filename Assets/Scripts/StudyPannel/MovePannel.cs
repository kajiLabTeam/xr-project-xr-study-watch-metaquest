using UnityEngine;

public class MovePannel : MonoBehaviour
{
    [SerializeField] GetFollowPosition _getFollowPosition;

    void SetStudyWatchPannel()
    {
        transform.position = _getFollowPosition.GetNowPosition();
    }
}
