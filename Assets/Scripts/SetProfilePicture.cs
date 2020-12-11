using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetProfilePicture : MonoBehaviour
{
    public RandomAvatar randomAvatar;

    void Start()
    {
        GetComponent<Image>().sprite = randomAvatar.avatar;
    }
}
