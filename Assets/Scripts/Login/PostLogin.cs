using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class PostLogin : MonoBehaviour
{
    [SerializeField] EnvController envController;
    [SerializeField] LoginStateController loginStateController;
    [SerializeField] TMP_Text m_SendMessage;
    [SerializeField] Transition m_Transition;
    [SerializeField] DataManager m_DataManager;

    [SerializeField] TMPro.TMP_Text text;

    public ValidateLogin m_ValidateLogin;
    public UseKeyboard m_UseKeyboard;

    private string defaltMessage = "Send";

    private void Awake()
    {
        //if (m_DataManager.LoadHeader() != null)
        //{
        //    m_Transition.LoginToStudyWatch();
        //}
        m_ValidateLogin = FindObjectOfType<ValidateLogin>();
        m_UseKeyboard = FindObjectOfType<UseKeyboard>();
        m_SendMessage.text = defaltMessage;
    }


    public void Login()
    {
        string email = loginStateController.GetEmail();
        string password = loginStateController.GetPassword();
        if (email == "" && password == "")
        {
            return;
        }
        m_SendMessage.text = "ValidateEmail";
        if (!m_ValidateLogin.ValidateEmail(email))
        {
            m_UseKeyboard.CleanEmail();
            m_SendMessage.text = defaltMessage;
            return;
        }

        m_SendMessage.text = "ValidatePassword";
        if (!m_ValidateLogin.ValidatePassword(password))
        {
            m_UseKeyboard.CleanPassword();
            m_SendMessage.text = defaltMessage;
            return;
        }

        m_SendMessage.text = "Now Sending";
        StartCoroutine(GetDataWithHeader());
    }
    
    private IEnumerator GetDataWithHeader()
    {
        text.text = "start\n";
        string url = envController.GetUrl();
        url = url + "api/user/login";
        text.text += url + "\n";

        LoginInfo loginInfo = loginStateController.GetLoginInfo();
        string loginInfoStr = JsonUtility.ToJson(loginInfo);
        text.text += loginInfoStr + "\n";
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(loginInfoStr);

        var request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        text.text += "SetRequestHeader" + "\n";
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            text.text += "Success\n";
            UserInfo userInfo = JsonUtility.FromJson<UserInfo>(request.downloadHandler.text);
            text.text += userInfo.id;
            m_DataManager.SaveHeader(userInfo.id);
            m_Transition.LoginToStudyWatch();
        }
        else
        {
            text.text += request.error;
            m_SendMessage.text = request.error;
        }
    }
}
