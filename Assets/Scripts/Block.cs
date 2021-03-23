using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config param
    [SerializeField] int amountToBreak = 3;
    [SerializeField] AudioClip breakSound;
    [SerializeField] int pointValue = 10;

    //Cached component reference
    int countCollisions = 0;
    Level level;

    // Start is called before the first frame update
    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        countCollisions++;
        if (countCollisions == amountToBreak)
        {
            FindObjectOfType<GameState>().IncreaseScore(pointValue);
            level.CountDestroyedBlocks();
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
