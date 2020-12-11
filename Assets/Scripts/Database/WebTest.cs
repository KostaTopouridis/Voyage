using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour
{
    IEnumerator Start()
    {
        WWW request = new WWW("https://atk-company.nl/sqlconnect/webtest.php");
        yield return request;
        string[] webResults = request.text.Split('\t');
        foreach(string s in webResults)
        {
            Debug.Log(s);
        }
    }
}
