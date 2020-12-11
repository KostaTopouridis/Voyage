using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_Text errorDisplayText;
    public string connectionFailedError;
    public string noEmailError;
    public string incorrectPasswordError;
    public string wrongEmailFormatError;

    public Button submitButton;

    public void CallLogin()
    {
        if (emailField.text.Contains("@"))
        {
            StartCoroutine(LoginPlayer());
        }
        else
        {
            errorDisplayText.text = wrongEmailFormatError;
            errorDisplayText.gameObject.SetActive(true);
        }
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", emailField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("https://atk-company.nl/sqlconnect/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.email = emailField.text;
            DBManager.posts = int.Parse(www.text.Split('\t')[1]);
            DBManager.likes = int.Parse(www.text.Split('\t')[2]);
            DBManager.dislikes = int.Parse(www.text.Split('\t')[3]);

            Debug.Log(DBManager.email + " " + DBManager.posts + " " + DBManager.likes + " " + DBManager.dislikes);
            UIManager.instance.ShowApp();
        } 
        else
        {
            Debug.Log("User login failed. Error #" + www.text);

            if (www.text.Contains("1"))
            {
                errorDisplayText.text = connectionFailedError;
            }
            if (www.text.Contains("5"))
            {
                errorDisplayText.text = noEmailError;
            }
            if (www.text.Contains("6"))
            {
                errorDisplayText.text = incorrectPasswordError;
            }
            errorDisplayText.gameObject.SetActive(true);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (emailField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
