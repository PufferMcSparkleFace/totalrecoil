using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public float health = 100f;

    private void Update()
    {
        if(health <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {

    }
}
