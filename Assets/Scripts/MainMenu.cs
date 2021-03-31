using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        scoreManager.ResetScore();
        transform.Find("Start").GetComponent<Button>().onClick.AddListener(() => { Loader.Load(Loader.Scene.GameScene); });
        transform.Find("Quit").GetComponent<Button>().onClick.AddListener(() => { Application.Quit(); });
    }
}
