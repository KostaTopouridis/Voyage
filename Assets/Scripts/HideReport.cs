using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HideReport : MonoBehaviour
{
	public GameObject dropdown;
	public void OnValueChanged()
    {
	    if (GetComponent<TMP_Dropdown>().value == 0)
        {
            Destroy(dropdown);
        } else
        {
            print("Post reported!");
        }
    }
}
