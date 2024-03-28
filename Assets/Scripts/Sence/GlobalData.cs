using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalDataScriptableObject", menuName = "GlobalDataScriptableObject", order = 0)]
public class GlobalDataScriptableObject : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private string initText = default;
    [NonSerialized] public string email;
    [NonSerialized] public string password;

    public void OnAfterDeserialize()
    {
        email = initText;
        password = initText;
    }

    public void OnBeforeSerialize()
    {
        /* do nothing */
    }
}

public class GlobalData : MonoBehaviour
{
    [SerializeField] private GlobalDataScriptableObject globalDataScriptableObject = default;

    private void Awake()
    {
        if (globalDataScriptableObject == null)
        {
            globalDataScriptableObject = ScriptableObject.CreateInstance<GlobalDataScriptableObject>(); 
        }
    }

    public bool SetGlobalData(string email,string password)
    {
        if (globalDataScriptableObject == null) return false;
        if (email == null || password == null) return false;
        globalDataScriptableObject.email = email;
        globalDataScriptableObject.password = password;
        return true;
    }

    public string GetEmail()
    {
        return globalDataScriptableObject.email;
    }

    public string GetPassword() 
    {
        return globalDataScriptableObject.password;
    }
}
