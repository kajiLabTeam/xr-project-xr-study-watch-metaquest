using UnityEngine;

[System.Serializable]
public class LoginInfo
{
    public string email;
    public string password;
}

public class LoginState : MonoBehaviour
{
    public LoginInfo loginInfo = new();
}
