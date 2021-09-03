using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{  
    public void LoadNextScene() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetScore(); 
    }    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void DelayedNextScene()
    {
        Invoke("LoadNextScene", 1f);
    }

    public void DelayedGameOver()
    {
        Invoke("LoadGameOver", 1f);
    }

}
