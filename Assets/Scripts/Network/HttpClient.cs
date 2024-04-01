using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    [SerializeField] EnvController _envController;
    [SerializeField] DataManager _dataManager;

    [SerializeField] TMPro.TMP_Text tMP_Text;

    public IEnumerator GetLabs()
    {
        tMP_Text.text = "start\n";
        ResponseData newResponseData = null;
        string url = _envController.GetUrl();
        url = url + "api/object/get";
        string headerAuth = _dataManager.LoadHeader();
        tMP_Text.text += headerAuth + "\n";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Authorization", headerAuth);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            tMP_Text.text = request.downloadHandler.text;
            try
            {
                newResponseData = JsonUtility.FromJson<ResponseData>(request.downloadHandler.text);
            }
            catch (Exception ex)
            {
                tMP_Text.text += "Error parsing JSON: " + ex.Message;
                Debug.LogError("Error parsing JSON: " + ex.Message);
                yield break;
            }
        }
        else
        {
            tMP_Text.text += "Error fetching data: " + request.error;
            Debug.LogError("Error fetching data: " + request.error);
        }

        yield return newResponseData;
    }
}
