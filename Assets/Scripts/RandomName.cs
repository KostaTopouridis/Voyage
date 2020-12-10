using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomName : MonoBehaviour
{
    public static RandomName instance;
    public List<string> adjectives = new List<string>();
    public List<string> nouns = new List<string>();

    public void Awake()
    {
        instance = this;
    }

    public string GenerateRandomName()
    {
        string randomName;
        randomName = adjectives[Random.Range(0, adjectives.Count)] + nouns[Random.Range(0, nouns.Count)];
        return randomName;
    }
}
