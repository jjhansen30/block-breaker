using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
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
        //Singleton Pattern
        int gameStateCount = FindObjectsOfType<GameSession>().Length;
        if (gameStateCount > 1)
        {
            gameObject.SetActive(false); //Ensures Destroy method is called on awake
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGameScore()
    {
        Destroy(gameObject);
    }
}
