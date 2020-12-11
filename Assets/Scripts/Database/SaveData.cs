using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    public void Awake()
    {
        instance = this;
    }
    public void CallSave()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", DBManager.email);
        form.AddField("posts", DBManager.posts);
        form.AddField("likes", DBManager.likes);
        form.AddField("dislikes", DBManager.dislikes);

        WWW www = new WWW("https://atk-company.nl/sqlconnect/savedata.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Data Saved!");
        }
        else
        {
            Debug.Log("Save Failed! Error #" + www.text);
        }
    }
}
