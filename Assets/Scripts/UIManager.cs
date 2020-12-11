using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	public GameObject appPanel;
	public GameObject loginPanel;

	public GameObject emptyChannel;
	[Header("Scores")]
	public TMP_Text postsText;
	public TMP_Text likesText;
	public TMP_Text dislikesText;
	[Header("Posts")]
	public GameObject homePanel;
	public GameObject searchPanel;
	public GameObject newpostPanel;
	public GameObject profilePanel;
	public GameObject activityPanel;
	public GameObject dmPanel;
	[Header("Navigations")]
	public List<Toggle> navigations = new List<Toggle>();

    void Awake()
    {
		instance = this;
    }
    void Start()
    {
		Screen.fullScreen = false;
    }
    // Update is called once per frame
    void Update()
    {
		if (DBManager.LoggedIn)
        {
			postsText.text = DBManager.posts.ToString();
			likesText.text = DBManager.likes.ToString();
			dislikesText.text = DBManager.dislikes.ToString();
		}

		foreach (Toggle t in navigations)
	    {
	    	if (t.isOn)
	    	{
	    		t.interactable = false;
	    	}
		    else
		    {
		    	t.interactable = true;
		    }
	    }
    }

	public void InstantiatePost(Transform panel, GameObject postGameObject, int id, string username, string date, string message, int likes, int dislikes, int comments)
	{
		GameObject newPost = Instantiate(postGameObject);
		newPost.transform.SetParent(panel, false);
		newPost.transform.SetSiblingIndex(0);
		Post postScript = newPost.GetComponent<Post>();

		postScript.id = id;
		postScript.username = username;
		postScript.published = date;
		postScript.message = message;
		postScript.likes = likes;
		postScript.dislikes = dislikes;
		postScript.comments = comments;
		postScript.generated = true;

		postScript.ChangeAttributes(id, username, date, message, likes, dislikes, comments);
		postScript.RefreshPost();
	}

	public void ShowApp()
    {
		appPanel.SetActive(true);
		loginPanel.SetActive(false);
    }
}
