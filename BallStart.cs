using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour
{
    
    [SerializeField] Paddle paddle1 = null;
    [SerializeField] float velocityX = 3f;
    [SerializeField] float velocityY = 17f;
    [SerializeField] AudioClip[] ballSounds=null; 
    [Range(0.1f, 2f)] [SerializeField] float randomFactor = 1f; 

    bool hasStarted = false;

    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    Vector2 paddleToBallVector;
    
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;

        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }         
    }
    

    public void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);        
        transform.position = (paddlePosition + paddleToBallVector);
    }

    public void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);            
        }
    }

    public void HasNotStarted()
    {
        hasStarted = false;
        LaunchBallOnClick();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f,randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            PlaySoundCollisionBall();

            if (myRigidBody2D.velocity.magnitude > 14)
            {
                myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x * 0.8f, myRigidBody2D.velocity.y * 0.8f);
            } else if (myRigidBody2D.velocity.magnitude <= 10)
            {
                myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x*1.5f, myRigidBody2D.velocity.y*1.5f);
            } else
            {
                myRigidBody2D.velocity += velocityTweak;
            }                       
        }        
    }

    private void PlaySoundCollisionBall()
    {
        AudioClip randomClip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
        myAudioSource.PlayOneShot(randomClip);
    }   

}
