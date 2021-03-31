using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config Parameters
    [SerializeField] float screenWidthInUnits;
    [SerializeField] float[] constraints;

    //Cached Component References
    float mousePosInUnits;
    GameSession gameSession;
    Ball ball;
    Vector2 paddlePos;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameSession.IsAutoPlayEnabled())
        {
            LetPlayerControlPaddle();
        }
        else
        {
            EnterAutoPlayMode();
        }
    }

    private void EnterAutoPlayMode()
    {
        Vector2 ballPos = ball.transform.position;
        Vector2 paddlePos = new Vector2(ballPos.x, transform.position.y);
        transform.position = paddlePos;
    }

    private void LetPlayerControlPaddle()
    {
        //Takes the vector of the paddle and follows the mouse
        //but is constrained within the width of the screen
        mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, constraints[0], constraints[1]);
        transform.position = paddlePos;
    }
}
