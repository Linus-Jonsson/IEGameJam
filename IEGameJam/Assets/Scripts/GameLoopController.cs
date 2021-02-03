using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopController : MonoBehaviour
{
    [SerializeField] GameObject stateScreens = null;
    [SerializeField] GameObject winText = null;
    [SerializeField] GameObject loseText = null;
    [SerializeField] GameObject deathText = null;
    
    public void HandleWinState()
    {
        stateScreens.SetActive(true);
        winText.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void HandleLoseState()
    {
        stateScreens.SetActive(true);
        loseText.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void ReloadCurrentScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
