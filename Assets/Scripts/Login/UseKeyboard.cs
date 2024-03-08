using TMPro;
using UnityEngine;

public class UseKeyboard : MonoBehaviour
{
    // 外部からInputFieldの呼び出し
    [SerializeField] private TMP_InputField inputEmailField;

    // 外部からInputFieldの呼び出し
    [SerializeField] private TMP_InputField inputPasswordField;

    public LoginState m_LoginState;
    public ValidateLogin m_ValidateLogin;

    public bool isPassword = false;
    public bool isEmail = false;

    // キーボードの宣言
    private TouchScreenKeyboard _overlayKeyboard;

    private void Start()
    {
        m_LoginState = FindObjectOfType<LoginState>();
        m_ValidateLogin = FindObjectOfType<ValidateLogin>();
    }

    // キーボードの変更時に動く
    private void Update()
    {
        if (_overlayKeyboard.text == "") return;

        // email
        if (isEmail)
        {
            inputEmailField.text = _overlayKeyboard.text;
            m_LoginState.email = inputEmailField.text;
            m_ValidateLogin.ValidateErrorEmail(string.Empty);
        }

        // pass
        if (isPassword)
        {
            inputPasswordField.text = _overlayKeyboard.text;
            m_LoginState.password = inputPasswordField.text;
            m_ValidateLogin.ValidateErrorPassword(string.Empty);
        }
    }

    // Email用のキーボードを呼び出す関数
    public void SetEmailKeyboard()
    {
        _overlayKeyboard = TouchScreenKeyboard.Open(m_LoginState.email, TouchScreenKeyboardType.URL);
        isPassword = false;
        isEmail = true;
    }

    // Pass用のキーボードを呼び出す関数
    public void SetPassKeyboard()
    {
        _overlayKeyboard = TouchScreenKeyboard.Open(m_LoginState.password, TouchScreenKeyboardType.URL);
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
