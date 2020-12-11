using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using PullToRefresh;

public class PostManager : MonoBehaviour
{
    [SerializeField] private UIRefreshControl m_UIRefreshControl;
    public RectTransform postPanel;
    public GameObject post;
    public TMP_InputField message;

    public void Start()
    {
        LoadLatestPosts();
        m_UIRefreshControl.OnRefresh.AddListener(RefreshItems);
    }

    private void RefreshItems()
    {
        StartCoroutine(FetchDataDemo());
    }

    private IEnumerator FetchDataDemo()
    {
        for (int i = postPanel.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = postPanel.transform.GetChild(i);

            if (!child.gameObject.name.Contains("Loading"))
            {
                Destroy(child.gameObject);
            }

        }

        LoadLatestPosts();

        // Instead of data acquisition.
        yield return new WaitForEndOfFrame();

        // Call EndRefreshing() when refresh is over.
        m_UIRefreshControl.EndRefreshing();
    }

    // Register the callback you want to call to OnRefresh when refresh starts.
    public void OnRefreshCallback()
    {
        Debug.Log("OnRefresh called.");
    }

    public void LoadLatestPosts()
    {
        StartCoroutine(LoadPosts());
    }

    public IEnumerator LoadPosts()
    {
        WWWForm form = new WWWForm();
        WWW www = new WWW("https://atk-company.nl/sqlconnect/loadposts.php", form);
        yield return www;
        string[] webResults = www.text.Split('\t');

        if (postPanel.Find("EmptyChannel"))
        {
            postPanel.Find("EmptyChannel").GetComponent<DestroyThis>().enabled = true;
        }


        if (www.text.Contains("0"))
        {
            foreach (string s in webResults)
            {
                if (s.Length>5)
                {
                    string[] postAttributes = s.Split(','); // 0 = id, 2 = username, 3 = date, 4 = message, 5 = likes, 6 = dislikes, 7 = comments

                    UIManager.instance.InstantiatePost(postPanel, post, int.Parse(postAttributes[0]), postAttributes[2], postAttributes[3], postAttributes[4], 
                        int.Parse(postAttributes[5]), int.Parse(postAttributes[6]), int.Parse(postAttributes[7]));
                }
            }
            Debug.Log("Posts loaded successfully!");
        } else
        {
            Debug.Log("Failed to load. Error#" + www.text);
        }

        GameObject newPost = Instantiate(UIManager.instance.emptyChannel);
        newPost.transform.SetParent(postPanel, false);
    }

    public void NewPost()
    {
        if (message.text == string.Empty)
        {
            print("Nothing has been written");
        } else
        {
            if (postPanel.Find("EmptyChannel"))
            {
                postPanel.Find("EmptyChannel").GetComponent<DestroyThis>().enabled = true;
            }
            GameObject newPost = Instantiate(post);
            newPost.transform.SetParent(postPanel, false);
            newPost.transform.SetSiblingIndex(0);
            newPost.GetComponent<Post>().message = message.text;

            DBManager.posts++;
            SaveData.instance.CallSave();

            Debug.Log(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
        }
    }
}
