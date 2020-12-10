using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HideReport : MonoBehaviour
{
    void OnValueChanged()
    {
        if (GetComponent<TMP_Dropdown>().value == 0)
        {
            Destroy(gameObject);
        } else
        {
            print("Post reported!");
        }
    }
}
