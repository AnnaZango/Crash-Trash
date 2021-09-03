using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] AudioClip breakSound; 
    [SerializeField] GameObject blockParticlesVFX; 
    
    [SerializeField] Sprite[] hitSprites; 
    
    Level level;

    [SerializeField] int numHits; 

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") 
        {
            level.CountBlocks(); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            if (tag == "Breakable")
            {
                HandleHit();
            }
        }       
    }

    private void HandleHit()
    {
        numHits++; 
        int maxHits = (hitSprites.Length) + 1; 
        if (numHits >= maxHits)
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
        int indexHitSprites = numHits - 1;

        if (hitSprites[indexHitSprites] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[indexHitSprites];
        }
        else
        {
            Debug.LogError("Block Sprite missing from array! Drag and drop it! GO: "+ gameObject.name);
        }        
    }

    private void DestroyBlock()
    {
        SoundAndParticleEffects();
        
        level.BrokenBlock();

        FindObjectOfType<GameSession>().AddToScore();

        Destroy(gameObject);
    }

    private void SoundAndParticleEffects()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        TriggerParticleVFX();        
    }

    private void TriggerParticleVFX()
    {
        GameObject particles = Instantiate(blockParticlesVFX, transform.position, transform.rotation);
        Destroy(particles, 2f);         
    }
}
