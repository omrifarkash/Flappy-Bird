using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System;

public class Bird : MonoBehaviour
{
    public event EventHandler onDied;
    public event EventHandler startedPlaying;
    private static Bird instance;
    private State state;
    private enum State
    {
        waitingForPlay,
        playing,
        dead,
    }


    public static Bird GetInstance()
    {
        return instance;
    }
    private const float JUMP = 90f;
    private Rigidbody2D rigidBody;
    private void Awake() {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Static;
    }
    private void Update() {
        switch (state)
        {
            case State.waitingForPlay:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    state = State.playing;
                    rigidBody.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                    if (onDied != null) startedPlaying(this, EventArgs.Empty);
                }
                break;
            case State.playing:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Jump();
                }
                transform.eulerAngles = new Vector3(0, 0, rigidBody.velocity.y * 0.15f);
                break;
            case State.dead:
                break;
        }
    }

    private void Jump() {
        rigidBody.velocity = Vector2.up * JUMP;
        soundManager.playSound(soundManager.Sound.jump);
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        rigidBody.bodyType = RigidbodyType2D.Static;
        soundManager.playSound(soundManager.Sound.die);
        if (onDied != null) onDied(this, EventArgs.Empty);
    }
}
