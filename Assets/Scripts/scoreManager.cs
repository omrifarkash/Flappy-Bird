using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class scoreManager 
{

    

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("highscore");
    }

    public static void setNewHighScore(int score)
    {
        int current = PlayerPrefs.GetInt("highscore");
        if(current < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
        }
    }

    public static void ResetScore()
    {
        PlayerPrefs.SetInt("highscore", 0);
        PlayerPrefs.Save();
    }
}
