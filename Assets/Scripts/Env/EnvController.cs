using UnityEngine;

public class EnvController : MonoBehaviour
{
    [SerializeField] EnvState _envState;

    public string GetEmail()
    {
        return _envState.envInfo.email;
    }

    public string GetPassword()
    {
        return _envState.envInfo.password;
    }

    public string GetUrl()
    {
        return _envState.envInfo.url;
    }
}
