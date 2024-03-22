using UnityEngine;

public class LoginState : MonoBehaviour
{
    [SerializeField] EnvController _envController;
    public string email;
    public string password;

    private void Start()
    {
        email = _envController.GetEmail();
        password = _envController.GetPassword();
    }
}
