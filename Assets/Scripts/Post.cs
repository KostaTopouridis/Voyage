using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public string username;
    public DateTime published;
    public string message;
    public int likes;
    public int dislikes;
    public int comments;

    public void Start()
    {
        published = DateTime.Now;

        usernameText.text = RandomName.instance.GenerateRandomName();
        publishedText.text = published.ToShortTimeString() + " / " + published.ToShortDateString();
        messageText.text = message;
        likesText.text = likes.ToString();
        dislikesText.text = dislikes.ToString();
        commentsText.text = comments.ToString();
    }
}
