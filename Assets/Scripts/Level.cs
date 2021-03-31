using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockCount; //serialized for debug puproses only
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        blockCount++;
    }

    public void CountDestroyedBlocks()
    {
        blockCount--;
        if (blockCount == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
