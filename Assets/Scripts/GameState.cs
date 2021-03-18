using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [Range(0, 10f)] [SerializeField] float gameSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
