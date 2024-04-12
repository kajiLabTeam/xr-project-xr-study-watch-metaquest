using UnityEngine;

[System.Serializable]
public class UserInfo
{
    public string id;
}

public class UserId : MonoBehaviour
{
    public UserInfo userInfo = new();
}
