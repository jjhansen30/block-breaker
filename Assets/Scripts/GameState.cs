using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    //Config Params
    [Range(0, 10f)] [SerializeField] float gameSpeed;
    [SerializeField] Text scoreText;

    //Cached component references
    [SerializeField] int currentScore; //serialized for debuging purposes only

    private void Awake()
    {
        CarryScoreToNextScene();
    }

    //Start is called before the first frame update
    private void Start()
    {
        gameSpeed = 1f;
        UpdateScoreText();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        UpdateScoreText();
    }

    //Public Methods
    public void IncreaseScore(int stationaryBlockPoints)
    {
        currentScore = stationaryBlockPoints + currentScore;
        UpdateScoreText();
    }

    //Private Methods
    private void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    private void CarryScoreToNextScene()
    {
        /*
        Allows the score to persist across scenes
        by destroying new Game State objects and keeping
        the original Game State object
        */
        int gameStateCount = FindObjectsOfType<GameState>().Length;
        Debug.Log("gameStateCount is " + gameStateCount);
        if (gameStateCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
