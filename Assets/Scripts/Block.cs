using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config param
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] Sprite[] hitSprite;
    [SerializeField] int maxHits = 3;
    [SerializeField] int pointValue = 10;
    [SerializeField] float destroyAfterDelay = 2f;
    [SerializeField] float[] timesHitBeforeDestroyed = {0.4f, 0.59f, 0.6f, 0.85f};

    //Cached component reference
    Level level;

    //State
    int timesHit = 0;

    // Start is called before the first frame update
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable Block")
        {
            HandlHits();
        }
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable Block")
        {
            level.CountBlocks();
        }
    }

    private void HandlHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        float lessThanHalfTimesHit = maxHits * timesHitBeforeDestroyed[0];
        float aboutHalfTimesHit = (maxHits * timesHitBeforeDestroyed[1]);
        float greaterThanQuaterTimesHit = maxHits * timesHitBeforeDestroyed[2];
        float lessThanTimesHit = (maxHits * timesHitBeforeDestroyed[3]);

        if (timesHit >= lessThanHalfTimesHit && timesHit <= aboutHalfTimesHit)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[0];
            Debug.Log("Hit sprite one rendered for " + gameObject.name);
        }
        else if (timesHit >= greaterThanQuaterTimesHit && timesHit <= lessThanTimesHit)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[1];
            Debug.Log("Hit sprite two rendered for " + gameObject.name);
        }        
    }

    private void DestroyBlock()
    {
        TriggerAllFX();
        FindObjectOfType<GameSession>().IncreaseScore(pointValue);
        level.CountDestroyedBlocks();
        Destroy(gameObject);
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
