using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; 

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>(); 
    }

    public void CountBlocks() 
    {
        breakableBlocks++; 
    }
    public void BrokenBlock()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            FindObjectOfType<GameSession>().GoodJob();
            sceneLoader.DelayedNextScene();            
        }
    }              

}
