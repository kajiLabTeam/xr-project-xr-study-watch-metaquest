using UnityEngine;

public class LoginStateController : MonoBehaviour
{
    [SerializeField] EnvController _envController;
    [SerializeField] LoginState _loginState;

    private void Start()
    {
        SetEmail(_envController.GetEmail());
        SetPassword(_envController.GetPassword());
    }

    public void SetEmail(string email)
    {
        _loginState.loginInfo.email = email;
    }

    public void SetPassword(string password)
    {
        _loginState.loginInfo.password = password;
    }

    public string GetEmail()
    {
        return _loginState.loginInfo.email;
    }

    public string GetPassword()
    {
        return _loginState.loginInfo.password;
    }

    public LoginInfo GetLoginInfo()
    {
        return _loginState.loginInfo;
    }
}
