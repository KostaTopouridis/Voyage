using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Post : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text publishedText;
    public TMP_Text messageText;
    public TMP_Text likesText;
    public TMP_Text dislikesText;
    public TMP_Text commentsText;
    [Space(10)]
    public int id;
    public string username;
    public string published;
    public string message;
    public int likes;
    public int dislikes;
    public int comments;
    public bool generated;

    public void Start()
    {
        if (!generated)
        {
            published = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            id = UnityEngine.Random.Range(100000, 9999999);
            username = RandomName.instance.GenerateRandomName();
            usernameText.text = username;
            publishedText.text = published;
            messageText.text = message;
            likesText.text = likes.ToString();
            dislikesText.text = dislikes.ToString();
            commentsText.text = comments.ToString();
            StartCoroutine(Upload(usernameText.text, publishedText.text, messageText.text));
        }
    }

    public void ChangeAttributes(int idDB, string usernameDB, string dateDB, string messageDB, int likesDB, int dislikesDB, int commentsDB)
    {
        id = idDB;
        username = usernameDB;
        published = dateDB;
        message = messageDB;
        likes = likesDB;
        dislikes = dislikesDB;
        comments = commentsDB;
    }

    public void RefreshPost()
    {
        usernameText.text = username;
        publishedText.text = published;
        messageText.text = message;
        likesText.text = likes.ToString();
        dislikesText.text = dislikes.ToString();
        commentsText.text = comments.ToString();
    }

    public void CallLike(bool isOn)
    {
        if (isOn)
            likes++;
        else
            likes--;
        likesText.text = likes.ToString();
        StartCoroutine(Like(isOn));
    }

    public void CallDislike(bool isOn)
    {
        if (isOn)
            dislikes++;
        else
            dislikes--;

        dislikesText.text = dislikes.ToString();
        StartCoroutine(Dislike(isOn));
    }
    
    IEnumerator Like(bool increment)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("increment", increment.ToString());

        WWW www = new WWW("https://atk-company.nl/sqlconnect/likepost.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Post Successfully saved in the database");
        }
    }

    IEnumerator Dislike(bool increment)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("increment", increment.ToString());

        WWW www = new WWW("https://atk-company.nl/sqlconnect/dislikepost.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Post Successfully saved in the database");
        }
    }

    IEnumerator Upload(string username, string date, string message)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("email", DBManager.email);
        form.AddField("username", username);
        form.AddField("date", date);
        form.AddField("message", message);

        WWW www = new WWW("https://atk-company.nl/sqlconnect/uploadpost.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Post Successfully saved in the database");
        }
    }
}
