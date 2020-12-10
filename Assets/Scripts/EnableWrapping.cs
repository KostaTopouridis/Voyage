using UnityEngine;
using TMPro;

public class EnableWrapping : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().enableWordWrapping = true;
    }
}
