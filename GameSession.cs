using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    [Range(0.1f,10f)] [SerializeField] float gameSpeed=1f; 
    [SerializeField] int pointsPerBlockDestroyed = 73;
    [SerializeField] TextMeshProUGUI text=null;
    [SerializeField] TextMeshProUGUI multiplyText;
    [SerializeField] TextMeshProUGUI goodJobText;
    [SerializeField] bool autoPlayEnabled;

    [SerializeField] int currentScore = 0;    
  
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1) 
        {
            gameObject.SetActive(false); 
            Destroy(gameObject); 
        }
        else
        {
            DontDestroyOnLoad(gameObject);                                            
        }
    }

    void Start()
    {
        text.text = currentScore.ToString();        
    }

    void Update()
    {
        Time.timeScale = gameSpeed;   
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        ShowTextScore();
    }

    private void ShowTextScore()
    {
        text.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }

    public void MultiplyScoreBy2()
    {
        currentScore = currentScore * 2;
        ShowTextScore();
        StartCoroutine(ShowMessage("SCORE X 2!", 1));
    }

    public void GoodJob()
    {
        StartCoroutine(ShowGoodJob("GOOD JOB!", 1));
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        multiplyText.text = message;
        multiplyText.enabled = true;
        yield return new WaitForSeconds(delay);
        multiplyText.enabled = false;
    }

    IEnumerator ShowGoodJob(string message, float delay)
    {
        goodJobText.text = message;
        goodJobText.enabled = true;
        yield return new WaitForSeconds(delay);
        goodJobText.enabled = false;
    }

    public bool IsAutoPlayEnabled()
    {
        return autoPlayEnabled;
    }
    
}


