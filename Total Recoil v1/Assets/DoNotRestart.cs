using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRestart : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("GameMusic");
        if(music.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
