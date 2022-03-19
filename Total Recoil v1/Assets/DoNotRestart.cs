using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRestart : MonoBehaviour
{
    private GameObject[] music;

    private void Start()
    {
        music = GameObject.FindGameObjectsWithTag("GameMusic");
        Destroy(music[1]);
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
