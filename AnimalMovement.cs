using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] float velocityX=1;
    [SerializeField] float velocityY=1;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
    }
        
}
