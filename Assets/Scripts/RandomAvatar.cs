using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAvatar : MonoBehaviour
{
    public List<Sprite> avatars = new List<Sprite>();
    public Sprite avatar;
    public void Start()
    {
        avatar = avatars[Random.Range(0, avatars.Count)];
        GetComponent<Image>().sprite = avatar;        
    }
}
