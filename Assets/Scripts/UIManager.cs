using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public GameObject emptyChannel;
	[Header("Posts")]
	public GameObject homePanel;
	public GameObject searchPanel;
	public GameObject newpostPanel;
	public GameObject profilePanel;
	public GameObject activityPanel;
	public GameObject dmPanel;
	[Header("Navigations")]
	public List<Toggle> navigations = new List<Toggle>();
	
    // Update is called once per frame
    void Update()
    {
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
}
