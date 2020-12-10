using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostManager : MonoBehaviour
{
    public RectTransform postPanel;
    public GameObject post;
    public TMP_InputField message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPost()
    {
        GameObject newPost = Instantiate(post);
        newPost.transform.SetParent(postPanel, false);
        newPost.GetComponent<Post>().message = message.text;
    }
}
