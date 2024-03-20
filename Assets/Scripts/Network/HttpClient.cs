using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text _text;
    public IEnumerator GetTexture(string viewUrl)
    {
        Texture texture = null;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(viewUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            try
            {
                texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            }
            catch
            {
                Debug.LogError("request:" + request.ToString() + "\n");
            }
            yield return texture;
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
        }
    }

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
                _text.text += "Error parsing JSON: " + ex.Message + "\n";
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
