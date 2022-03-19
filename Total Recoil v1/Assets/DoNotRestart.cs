using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRestart : MonoBehaviour
{
    public AudioSource bgm;

    private void Awake()
    {
        GameObject currentBGM = GameObject.FindGameObjectWithTag("GameMusic");
        if(currentBGM == null)
        {
            AudioSource spawned = Instantiate(bgm);
            spawned.Play();
            DontDestroyOnLoad(spawned);
        }
    }
}
