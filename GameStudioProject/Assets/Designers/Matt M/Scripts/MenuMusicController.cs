using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour
{

    private static MenuMusicController instance = null;
    public static MenuMusicController Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // any other methods you need
}