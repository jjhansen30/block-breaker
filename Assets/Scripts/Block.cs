using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config param
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int pointValue = 10;
    [SerializeField] int amountToBreak = 3;
    [SerializeField] float destroyAfterDelay = 2f;

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
            TriggerAllFX();
            FindObjectOfType<GameSession>().IncreaseScore(pointValue);
            level.CountDestroyedBlocks();
            Destroy(gameObject);
        }
    }

    private void TriggerAllFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        var sparkle = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, destroyAfterDelay);
    }
}
