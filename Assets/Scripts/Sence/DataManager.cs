using UnityEngine;

public class DataManager : MonoBehaviour
{
    public void SaveHeader(string address)
    {
        PlayerPrefs.SetString("Address", address);
        PlayerPrefs.Save();
    }

    public string LoadHeader()
    {
        return PlayerPrefs.GetString("Address", "");
    }
}
