using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config param
    [SerializeField] int amountToBreak = 3;
    [SerializeField] AudioClip breakSound;

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
        countCollisions++;
        if (countCollisions == amountToBreak)
        {
            level.CountDestroyedBlocks();
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
