using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRestart : MonoBehaviour
{
    public GameObject[] music;
    public AudioSource corneria;

    private void Start()
    {
        music = GameObject.FindGameObjectsWithTag("GameMusic");
        if(music.Length == 1)
        {
            corneria.Play();
        }
        else
        {
            for (int i = 1; i < music.Length; i++)
            {
                Destroy(music[1]);
            }
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
