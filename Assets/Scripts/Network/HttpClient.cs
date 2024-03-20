using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    public IEnumerator GetLabs()
    {
        string rawData = null;
        ResponseData newResponseData = null;

        string url = "https://hono-test.kanakanho.workers.dev/labs/";

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            rawData = request.downloadHandler.text;
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

        yield return ( rawData , newResponseData );
    }
}
