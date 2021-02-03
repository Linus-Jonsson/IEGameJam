using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopController : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen = null;
    [SerializeField] GameObject stateScreens = null;
    [SerializeField] GameObject winText = null;
    [SerializeField] GameObject loseText = null;
    [SerializeField] GameObject deathText = null;

    bool gameInEndScreens = false;

    void Update()
    {
        if (gameInEndScreens) return;
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }

    public void HandleWinState()
    {
        gameInEndScreens = true;
        stateScreens.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        winText.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void HandleLoseState()
    {
        gameInEndScreens = true;
        stateScreens.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        loseText.SetActive(true);
        Time.timeScale = 0f;
    }
    
    private void PauseGame()
    {
        pauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        pauseScreen.SetActive(false);
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
