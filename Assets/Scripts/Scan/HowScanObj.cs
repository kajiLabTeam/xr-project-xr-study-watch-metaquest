using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class HowScanObj : MonoBehaviour
{
    [SerializeField] BlinkingCanvas m_BlinkingCanvas;
    [SerializeField] LabsState m_LabsState;

    [SerializeField] TMP_Text m_TextMeshPro;
    public int insertNum = 0;

    private string beforeText = "周辺に";
    private string afterText = "つのオブジェクトがあります";

    private string url = "https://hono-test.kanakanho.workers.dev";

    private void Start()
    {
        ScanLabData();
    }

    public void ScanLabData()
    {
        m_BlinkingCanvas.TrunOnBlinking();
        m_TextMeshPro.text = "近くのオブジェクトをスキャンしています";
        StartCoroutine(GetLabs());
    }

    private void MakeRetrunMessage(int dataNum)
    {
        m_TextMeshPro.text = beforeText + dataNum + afterText;
    }

    private IEnumerator GetLabs()
    {
        yield return new WaitForSeconds(2f);

        url = url + "/labs/";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        m_BlinkingCanvas.TrunOffBlinking();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            try
            {
                m_LabsState.labs = JsonUtility.FromJson<LabsData>(responseText);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error parsing JSON: " + ex.Message);
                m_TextMeshPro.text = "JSONデータのパースに失敗しました";
                yield break;
            }

            insertNum = m_LabsState.labs.objects.Length;
            MakeRetrunMessage(insertNum);
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
            m_TextMeshPro.text = request.error;
        }

        yield return new WaitForSeconds(10f);
        m_BlinkingCanvas.HideScanMessage();
    }
}
