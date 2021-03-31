using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private Text scoreText;
    private Text highScoreText;
    private Text newHighScoreText;
    void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highScoreText = transform.Find("highScoreText").GetComponent<Text>();
        newHighScoreText = transform.Find("newHighScore").GetComponent<Text>();
        transform.Find("reStartButton").GetComponent<Button>().onClick.AddListener( () => { Loader.Load(Loader.Scene.GameScene); });
        transform.Find("toMainMenu").GetComponent<Button>().onClick.AddListener(() => { Loader.Load(Loader.Scene.MainMenu); });
    }

    private void Start()
    {
        Bird.GetInstance().onDied += Bird_onDied;
        newHighScoreText.text = "";
        gameObject.SetActive(false);
    }

    private void Bird_onDied(object sender, System.EventArgs e)
    {
        if(level01.GetInstance().GetPipesCounter() > scoreManager.GetHighScore()) newHighScoreText.text = "You did a new high score!!!";
        scoreManager.setNewHighScore(level01.GetInstance().GetPipesCounter());
        scoreText.text = level01.GetInstance().GetPipesCounter().ToString();
        highScoreText.text = "HIGHSCORE: " + scoreManager.GetHighScore().ToString();
        gameObject.SetActive(true);
    }

   
}
