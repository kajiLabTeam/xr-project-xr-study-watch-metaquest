using TMPro;
using UnityEngine;

public class UseKeyboard : MonoBehaviour
{
    [SerializeField] LoginStateController loginStateController;
    // ?O??????InputField???????o??
    [SerializeField] private TMP_InputField inputEmailField;

    // ?O??????InputField???????o??
    [SerializeField] private TMP_InputField inputPasswordField;

    public LoginState m_LoginState;
    public ValidateLogin m_ValidateLogin;

    public bool isPassword = false;
    public bool isEmail = false;

    // ?L?[?{?[?h??????
    private TouchScreenKeyboard _overlayKeyboard;

    private void Start()
    {
        m_ValidateLogin = FindObjectOfType<ValidateLogin>();
    }

    // ?L?[?{?[?h?????X????????
    private void Update()
    {
        if (_overlayKeyboard.text == "") return;

        // email
        if (isEmail)
        {
            inputEmailField.text = _overlayKeyboard.text;
            loginStateController.SetEmail(inputEmailField.text);
            m_ValidateLogin.ValidateErrorEmail(string.Empty);
        }

        // pass
        if (isPassword)
        {
            inputPasswordField.text = _overlayKeyboard.text;
            loginStateController.SetPassword(inputPasswordField.text);
            m_ValidateLogin.ValidateErrorPassword(string.Empty);
        }
    }

    // Email?p???L?[?{?[?h???????o??????
    public void SetEmailKeyboard()
    {
        _overlayKeyboard = TouchScreenKeyboard.Open(loginStateController.GetEmail(), TouchScreenKeyboardType.URL);
        isPassword = false;
        isEmail = true;
    }

    // Pass?p???L?[?{?[?h???????o??????
    public void SetPassKeyboard()
    {
        _overlayKeyboard = TouchScreenKeyboard.Open(loginStateController.GetPassword(), TouchScreenKeyboardType.URL);
        isPassword = true;
        isEmail = false;
    }

    public void CleanEmail()
    {
        inputEmailField.text = "";
    }

    public void CleanPassword()
    {
        inputPasswordField.text = " ";
    }
}
