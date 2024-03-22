using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    [SerializeField] EnvController _envController;

    public IEnumerator GetLabs()
    {
        ResponseData newResponseData = null;
        string url = _envController.GetUrl();

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            try
            {
                newResponseData = JsonUtility.FromJson<ResponseData>(request.downloadHandler.text);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error parsing JSON: " + ex.Message);
                yield break;
            }
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
        }

        yield return newResponseData;
    }
}
