using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour
{
    [SerializeField] int hearts;
    BallStart ballPosition;
    SceneLoader myScene;

    private void Start()
    {
        hearts = GameObject.FindGameObjectsWithTag("Heart").Length;
        ballPosition = FindObjectOfType<BallStart>();
        myScene = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            HeartsGameOver();
        } else if (collision.gameObject.name == "Animal")
        {
            FindObjectOfType<GameSession>().MultiplyScoreBy2();
        }        
    }

    private void HeartsGameOver()
    {
        if (hearts > 1)
        {
            hearts--;
            Destroy(GameObject.FindWithTag("Heart"));                                
            FindObjectOfType<BallStart>().HasNotStarted();   
        }
        else
        {
            myScene.DelayedGameOver();
        }
    }

}
