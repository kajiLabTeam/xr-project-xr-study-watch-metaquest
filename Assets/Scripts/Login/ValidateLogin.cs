using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class ValidateLogin : MonoBehaviour
{
    [SerializeField] TMP_Text errorMessageEmail;
    [SerializeField] TMP_Text errorMessagePassword;

    private const string errorInvalidInput = "無効な入力です";
    private const string errorNotMatchEmail = "メールアドレスが無効です";
    private const string errorShortPassword = "パスワードは8文字以上にしてください";
    private const string errorYouNotUseJapanese = "パスワードには日本語を含めることはできません";

    // 不適切な文字を含むかどうかをチェック
    private bool ContainsInvalidChars(string email)
    {
        string[] invalidChars = { "!", "#", "$", "%", "^", "&", "*", "(", ")", "[", "]", "{", "}", "|", "\\", "/", "<", ">", ",", ";", ":", "'", "\"", "?", "`", "~" };
        foreach (var invalidChar in invalidChars)
        {
            if (email.Contains(invalidChar))
            {
                return true;
            }
        }
        return false;
    }

    // IPアドレスを含むかどうかをチェック
    private bool IsIpAddress(string email)
    {
        string pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    // 特定の文字列を禁止
    private bool ContainsSpecialMeaning(string email)
    {
        string[] specialStrings = { "admin", "root", "superuser", "administrator", "system", "guest", "test", "password", "123456", "qwerty", "admin123", "root123" }; // 特殊な意味を持つ文字列のリスト
        foreach (var specialString in specialStrings)
        {
            if (email.ToLower().Contains(specialString))
            {
                return true;
            }
        }
        return false;
    }

    // 日本語を含むかどうかをチェック
    private bool ContainsJapanese(string password)
    {
        // 日本語を含むかどうかの正規表現パターン
        string pattern = @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(password);
    }

    // メールアドレスのバリデーション
    public bool ValidateEmail(string email)
    {
        string pattern = @"^([a-zA-Z0-9._%+-]+@)?[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);
        // メールアドレスの形式チェック
        if (!regex.IsMatch(email))
        {
            ValidateErrorEmail(errorNotMatchEmail);
            return false;
        }
        if (ContainsInvalidChars(email))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        //if (ContainsSpecialMeaning(email))
        //{
        //    ValidateErrorEmail(errorInvalidInput);
        //    return false;
        //}
        if (IsIpAddress(email))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        return true;
    }

    // パスワードのバリデーション
    public bool ValidatePassword(string password)
    {
        if (password.Length < 8)
        {
            ValidateErrorPassword(errorShortPassword);
            return false;
        }
        if (ContainsJapanese(password))
        {
            ValidateErrorEmail(errorYouNotUseJapanese);
            return false;
        }
        if (ContainsInvalidChars(password))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        //if (ContainsSpecialMeaning(password))
        //{
        //    ValidateErrorEmail(errorInvalidInput);
        //    return false;
        //}
        if (IsIpAddress(password))
        {
            ValidateErrorEmail(errorInvalidInput);
            return false;
        }
        return true;
    }

    public void ValidateErrorEmail(string errorText)
    {
        errorMessageEmail.text = errorText;
    }

    public void ValidateErrorPassword(string errorText)
    {
        errorMessagePassword.text = errorText;
    }
}
