using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class HowScanObj : MonoBehaviour
{
    [SerializeField] LabsState m_LabsState;
    [SerializeField] BlinkingCanvas m_BlinkingCanvas;

    [SerializeField] TMP_Text m_TextMeshPro;

    public int insertNum = 0;

    private string beforeText = "周辺に";
    private string afterText = "つのオブジェクトがあります";

    private string url = "https://hono-test.kanakanho.workers.dev";

    public IEnumerator ScanLabData()
    {
        m_BlinkingCanvas.TrunOnBlinking();
        m_TextMeshPro.text = "近くのオブジェクトをスキャンしています";
        yield return StartCoroutine(GetLabs());
    }

    private void MakeRetrunMessage(int dataNum)
    {
        m_TextMeshPro.text = beforeText + dataNum + afterText;
    }

    private IEnumerator GetLabs()
    {
        yield return new WaitForSeconds(1f);

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

            insertNum = m_LabsState.labs.objects.Count;
            MakeRetrunMessage(insertNum);
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
            m_TextMeshPro.text = request.error;
        }

        yield return new WaitForSeconds(2f);
    }
}
