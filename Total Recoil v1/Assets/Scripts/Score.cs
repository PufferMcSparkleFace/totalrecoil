using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public float combo = 0;
    public Text scoreText;
    public Text comboText;
    public Text comboTextRed;
    public float comboTimer = 100;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(combo <= 0)
        {
            comboText.enabled = false;
            comboTextRed.enabled = false;
        }
        else
        {
            comboText.enabled = true;
        }
        if(combo >= 20)
        {
            combo = 20;
        }
        comboText.text = "x" + combo;
        comboTextRed.text = "x" + combo;
    }

    private void FixedUpdate()
    {
        if(comboTimer > 0)
        {
            comboTimer = comboTimer - 1;
        }
        if(comboTimer > 50 && combo > 0)
        {
            comboText.enabled = true;
            comboTextRed.enabled = false;
        }
        if(comboTimer <= 50 && combo > 0)
        {
            comboText.enabled = false;
            comboTextRed.enabled = true;
        }
        if(comboTimer == 0)
        {
            combo = 0;
        }
    }

    public void UpdateScore(int newScore)
    {
        if (gameOver.activeInHierarchy == false)
        {
            float f = newScore * ((combo + 1) * 0.1f);
            score = (int)(score + Mathf.Round(f));
            comboTimer = 100;
            scoreText.text = "" + score;
        }
        
        
    }
}
