using UnityEngine;

public class DataManager : MonoBehaviour
{
    MyBase64str base64 = new MyBase64str("UTF-8");

    public void SaveHeader(string address)
    {
        address = base64.Encode(address + ":");
        address = "Basic " + address;
        PlayerPrefs.SetString("Address", address);
        PlayerPrefs.Save();
    }

    public string LoadHeader()
    {
        return PlayerPrefs.GetString("Address", "");
    }
}