using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRestart : MonoBehaviour
{
    public AudioSource corneria;

    private void Awake()
    {
        GameObject currentBGM = GameObject.FindGameObjectWithTag("GameMusic");
        if(currentBGM == null)
        {
            corneria.Play();
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
}
