using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text scoreText;
    private Text highScoreText;
    private Text startPlayText;
    private static ScoreWindow instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highScoreText = transform.Find("highScoreText").GetComponent<Text>();
        startPlayText = transform.Find("startPlayText").GetComponent<Text>();
    }

    public static ScoreWindow GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        highScoreText.text = "HIGHSCORE: " + scoreManager.GetHighScore().ToString();
        startPlayText.text = "CLICK \"SPACE\" TO START GAME";
    }

    private void Update()
    {
        scoreText.text = level01.GetInstance().GetPipesCounter().ToString();
        highScoreText.text = "HIGHSCORE: " + scoreManager.GetHighScore().ToString();
    }

    public void turnOfStartPlayingText()
    {
        startPlayText.text = "";
    }
}
