using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPostColor : MonoBehaviour
{
    public List<Color> pastelColors = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = pastelColors[Random.Range(0,pastelColors.Count)];
    }
}
