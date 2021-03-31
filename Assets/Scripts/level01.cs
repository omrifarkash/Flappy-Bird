using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class level01 : MonoBehaviour
{
    private const float PIPE_WIDTH = 0.8f;
    private const float PIPE_MOVE_SPEED = 25;
    private List<Transform> pipeList;
    private float Timer;
    private float TimerMax;
    private float gapSize;
    private int gapCounter;
    private float gapMin;
    private static level01 instance;
    private int pipesCounter;
    private State state;
    private enum State
    {
        waitingToPlay,
        playing,
        dead,
    }



    private void Awake()
    {
        instance = this;
        pipeList = new List<Transform>();
        TimerMax = 1.5f;
        gapSize = 50;
        gapCounter = 2;
        gapMin = 24;
        pipesCounter = 0;
        state = State.waitingToPlay;
    }

    private void Update()
    {
        if (state == State.playing)
        {
            pipeMovment();
            pipeSpawn();
        }
    }

    public static level01 GetInstance()
    {
        return instance;
    }

    public int GetPipesCounter()
    {
        return pipesCounter; 
    }

    private void pipeSpawn()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            Timer += TimerMax;

            CreateGapPipes(UnityEngine.Random.Range(5+gapSize*0.5f ,78- gapSize*.05f), gapSize, 110);
            gapCounter--;
            if (gapCounter == 0)
            {
                gapCounter = 2;
               if(gapSize > gapMin) gapSize -= 1;
            }
        }
    }

    private void pipeMovment()
    {
        for(int i=0; i<pipeList.Count; i++)
        {
            Transform pipe = pipeList[i];
            bool isToTheRightOfBird = pipe.position.x > 0f;
            pipe.position += new Vector3(-1,0,0) * PIPE_MOVE_SPEED * Time.deltaTime;
            if (isToTheRightOfBird && pipe.position.x <= 0f && i % 2 == 0)
            {
                soundManager.playSound(soundManager.Sound.score);
                pipesCounter++;
            }
            if (pipe.position.x < -110) { pipeList.Remove(pipe); Destroy(pipe.gameObject); i--; }
        }
    }

    private void Start()
    {
        Bird.GetInstance().onDied += Bird_onDied;
        Bird.GetInstance().startedPlaying += Bird_startedPlaying;
    }

    private void Bird_startedPlaying(object sender, System.EventArgs e)
    {
        ScoreWindow.GetInstance().turnOfStartPlayingText();
        state = State.playing;
    }

    private void Bird_onDied(object sender, System.EventArgs e)
    {
        state = State.dead;
    }

    private void CreateGapPipes(float gapY, float gapSize, float x)
    {
        CreatePiPe(gapY - gapSize*0.5f, x, true);
        CreatePiPe(100 - gapY - gapSize * 0.5f, x, false);
    }

    private void CreatePiPe(float height, float x, bool bottom)
    {
        Transform Pipe = Instantiate(GameAssets.GetInstance().prePipe);
        if (bottom) Pipe.position = new Vector3(x, -50, 1);
        else {Pipe.position = new Vector3(x, 50, 1); }
        SpriteRenderer PipeSprite = Pipe.GetComponent<SpriteRenderer>();
        if (!bottom) PipeSprite.flipY = true;
        PipeSprite.size = new Vector2(PIPE_WIDTH, height);
        BoxCollider2D PipeBoxCollider = Pipe.GetComponent<BoxCollider2D>();
        PipeBoxCollider.size = new Vector2(PIPE_WIDTH, height);
        PipeBoxCollider.offset = new Vector2(0f, height*0.5f);
        if(!bottom) PipeBoxCollider.offset = new Vector2(0f, -height * 0.5f);
        pipeList.Add(Pipe);
    }

    private void setTimer(double inSeconds)
    {
        double current = Time.realtimeSinceStartup + inSeconds;
        while (Time.realtimeSinceStartup <= current) ;
    }

}
