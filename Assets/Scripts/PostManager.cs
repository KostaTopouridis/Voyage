using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostManager : MonoBehaviour
{
    public RectTransform postPanel;
    public GameObject post;
    public TMP_InputField message;

    public void NewPost()
    {
        if (message.text == string.Empty)
        {
            print("Nothing has been written");
        } else
        {
            GameObject newPost = Instantiate(post);
            newPost.transform.SetParent(postPanel, false);
            newPost.GetComponent<Post>().message = message.text;
        }
    }
}
