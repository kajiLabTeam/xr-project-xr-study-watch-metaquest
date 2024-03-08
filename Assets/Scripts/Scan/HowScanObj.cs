using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using TMPro;

public class HowScanObj : MonoBehaviour
{
    [SerializeField] BlinkingCanvas m_BlinkingCanvas;

    [SerializeField] TMP_Text m_TextMeshPro;
    [SerializeField] int insertNum = 0;

    private string beforeText = "周辺に";
    private string afterText = "つのオブジェクトがあります";

    private string url = "https://hono-test.kanakanho.workers.dev";

    public class NumberData
    {
        public int number;
    }

    private void Awake()
    {
        m_BlinkingCanvas = FindObjectOfType<BlinkingCanvas>();
    }

    public void FetchNewData()
    {
        m_BlinkingCanvas.TrunOnBlinking();
        m_TextMeshPro.text = "近くのオブジェクトをスキャンしています";
        StartCoroutine(GetNewNumber());
    }

    private IEnumerator GetNewNumber()
    {
        yield return new WaitForSeconds(10f);

        url = url + "/number/";
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        m_BlinkingCanvas.TrunOffBlinking();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            NumberData data = JsonUtility.FromJson<NumberData>(responseText);
            m_TextMeshPro.text = beforeText + data.number + afterText;
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
            m_TextMeshPro.text = request.error;
        }
    }
}
