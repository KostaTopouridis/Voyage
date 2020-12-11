using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Registration : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_Text errorDisplayText;
    public string connectionFailedError;
    public string usedEmailError;

    public Toggle agree;
    public Button submitButton;

    public void CallRegister()
    {
        if (agree.isOn)
            StartCoroutine(Register());
        else
        {
            errorDisplayText.text = "You need to agree to the Terms of Use in order to create an account.";
            errorDisplayText.gameObject.SetActive(true);
        }
    }

    public IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", emailField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("https://atk-company.nl/sqlconnect/register.php", form);
        yield return www;
        if (www.text=="0")
        {
            Debug.Log("User Created Succefully!");
            UIManager.instance.ShowApp();
        }
        else
        {
            Debug.Log("User Creation Failed. Error #" + www.text);

            if (www.text.Contains("1"))
            {
                errorDisplayText.text = connectionFailedError;
            }
            if (www.text.Contains("3"))
            {
                errorDisplayText.text = usedEmailError;
            }
            errorDisplayText.gameObject.SetActive(true);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (emailField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
