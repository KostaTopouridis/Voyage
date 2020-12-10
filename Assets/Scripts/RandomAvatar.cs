using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAvatar : MonoBehaviour
{
    public List<Sprite> avatars = new List<Sprite>();

    public void Start()
    {
        GetComponent<Image>().sprite = avatars[Random.Range(0, avatars.Count)];
    }
}
