using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointsText;
   public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "" + score;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("BYEEEEE");
    }
}
