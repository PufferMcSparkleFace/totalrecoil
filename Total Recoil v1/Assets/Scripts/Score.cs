using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public float combo = 1;
    public Text scoreText;
    public Text comboText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(combo <= 1)
        {
            comboText.enabled = false;
        }
        else
        {
            comboText.enabled = true;
        }
        comboText.text = "x" + combo;
    }

    public void UpdateScore(int newScore)
    {
        //StartCoroutine(Combo());
        float f = newScore * combo * 0.5f;
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
