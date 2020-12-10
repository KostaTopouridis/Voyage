using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowHidePassword : MonoBehaviour
{
    public TMP_InputField password;

    public void ShowHide(bool isOn)
    {
        if (GetComponent<Toggle>().isOn)
        {
            password.contentType = TMP_InputField.ContentType.Standard;
            password.DeactivateInputField();
            password.ActivateInputField();
        } else
        {
            password.contentType = TMP_InputField.ContentType.Password;
            password.DeactivateInputField();
            password.ActivateInputField();
        }
    }
}
