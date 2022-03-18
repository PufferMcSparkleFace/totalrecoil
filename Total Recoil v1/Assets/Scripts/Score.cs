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
    }

    public void UpdateScore(int newScore)
    {
        //StartCoroutine(Combo());
        float f = newScore * ((combo + 1)*0.1f);
        score = (int)(score + Mathf.Round(f));
        scoreText.text = "" + score;
    }

    /*IEnumerator Combo()
    {
        combo = combo ++;
        yield return new WaitForSeconds(10);
        combo = 1;

    }*/
}
