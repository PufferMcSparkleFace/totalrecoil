using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRestart : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject[] other;
    private bool notFirst = false;
    private void Awake()
    {
        other = GameObject.FindGameObjectsWithTag("GameMusic");

        foreach(GameObject oneOther in other)
        {
            if(oneOther.scene.buildIndex == -1)
            {
                notFirst = true;
            }
        }
        if(notFirst == true)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
    }
}
