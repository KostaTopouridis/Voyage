using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    public static string email;
    public static int posts;
    public static int likes;
    public static int dislikes;

    public static bool LoggedIn { get { return email != null; } }

    public static void LogOut()
    {
        email = null;
    }
}
