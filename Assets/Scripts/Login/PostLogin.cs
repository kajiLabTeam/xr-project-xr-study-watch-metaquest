using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class PostLogin : MonoBehaviour
{
    [SerializeField] TMP_Text m_SendMessage;
    [SerializeField] Transition m_Transition;
    [SerializeField] DataManager m_DataManager;

    private string url = "https://hono-test.kanakanho.workers.dev";


    public ValidateLogin m_ValidateLogin;
    public LoginState m_LoginState;
    public UseKeyboard m_UseKeyboard;

    MyBase64str base64 = new MyBase64str("UTF-8");

    private string defaltMessage = "送信";

    private void Awake()
    {
        if (m_DataManager.LoadHeader() != null)
        {
            m_Transition.LoginToStudyWatch();
        }
        m_ValidateLogin = FindObjectOfType<ValidateLogin>();
        m_LoginState = FindObjectOfType<LoginState>();
        m_UseKeyboard = FindObjectOfType<UseKeyboard>();
        m_SendMessage.text = defaltMessage;
    }


    public void Login()
    {
        if (m_LoginState.email == "" && m_LoginState.password == "")
        {
            return;
        }
        m_SendMessage.text = "メールアドレスを検証中";
        if (!m_ValidateLogin.ValidateEmail(m_LoginState.email))
        {
            m_UseKeyboard.CleanEmail();
            m_SendMessage.text = defaltMessage;
            return;
        }

        m_SendMessage.text = "パスワードを検証中";
        if (!m_ValidateLogin.ValidatePassword(m_LoginState.password))
        {
            m_UseKeyboard.CleanPassword();
            m_SendMessage.text = defaltMessage;
            return;
        }

        m_SendMessage.text = "送信中";
        StartCoroutine(GetDataWithHeader(url, m_LoginState.email, m_LoginState.password));
    }

    private IEnumerator GetDataWithHeader(string URL,string email,string password)
    {
        url = URL + "/head/";
        string headerAuth = "Basic ";
        string cnvStr = base64.Encode(email + ":" +  password);
        headerAuth += cnvStr;
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("authorization", headerAuth);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            m_DataManager.SaveHeader(headerAuth);
            m_Transition.LoginToStudyWatch();
        }
        else
        {
            m_SendMessage.text = request.error;
        }
    }
}
