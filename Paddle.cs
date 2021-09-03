using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits =16f; 
    [SerializeField] float maximumPositionX = 15f;
    [SerializeField] float minimumPositionX = 1f;

    GameSession myGameSession;
    BallStart myBall;

    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<BallStart>();
    }

    void Update()
    {  
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPosition(), minimumPositionX, maximumPositionX);

        transform.position = paddlePosition;
    }

    
    private float GetXPosition()
    {
        if (myGameSession.IsAutoPlayEnabled())
        {
            return myBall.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * screenWidthInUnits);
        }
    }
    
}
