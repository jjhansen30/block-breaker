using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private void Awake()
    {
        int textCount = FindObjectsOfType<Canvas>().Length;
        Debug.Log("textCount is " + textCount);
        if (textCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("Logging Start()");
        Debug.Log("number of canvas'" + FindObjectsOfType<Canvas>().Length);
    }
}
