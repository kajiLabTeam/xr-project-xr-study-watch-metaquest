using UnityEngine;

[System.Serializable]
public class EnvInfo
{
    public string email;
    public string password;
    public string url;
}

[System.Serializable]
public enum EnvType
{
    test,
    production
}

public class EnvState : MonoBehaviour
{
    [SerializeField] Env _env;
    [SerializeField] TMPro.TMP_Text _Text;

    public EnvInfo envInfo;

    private void Awake()
    {
        envInfo = _env.GetEnvInfo();
    }
}
