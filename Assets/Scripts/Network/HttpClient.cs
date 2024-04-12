using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    [SerializeField] EnvController _envController;
    [SerializeField] DataManager _dataManager;
    [SerializeField] TMPro.TMP_Text _Text;

    public IEnumerator GetLabs()
    {
        ResponseData newResponseData = null;
        string url = _envController.GetUrl();
        url = url + "api/object/get";
        _Text.text += url + "\n";
        string headerAuth = _dataManager.LoadHeader();

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Authorization", headerAuth);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            try
            {
                newResponseData = JsonUtility.FromJson<ResponseData>(request.downloadHandler.text);
                _Text.text += request.downloadHandler.text + "\n";
            }
            catch (Exception ex)
            {
                Debug.LogError("Error parsing JSON: " + ex.Message);
                _Text.text += "Error parsing JSON: " + ex.Message + "\n";
                yield break;
            }
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
            _Text.text += "Error fetching data: " + request.error + "\n";
        }

        yield return newResponseData;
    }
}
