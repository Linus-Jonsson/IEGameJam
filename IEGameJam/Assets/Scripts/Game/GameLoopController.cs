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

    bool gameInEndScreens;

    PlayerDatingController playerDatingController;

    void Awake()
    {
        playerDatingController = FindObjectOfType<PlayerDatingController>();
    }
    void Update()
    {
        if (gameInEndScreens) return;
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }

    public void HandleWinState()
    {
        playerDatingController.playerCanReply = false;
        gameInEndScreens = true;
        stateScreens.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        winText.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void HandleLoseState()
    {
        playerDatingController.playerCanReply = false;
        gameInEndScreens = true;
        stateScreens.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        loseText.SetActive(true);
        Time.timeScale = 0f;
    }
    
    private void PauseGame()
    {
        playerDatingController.playerCanReply = false;
        pauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        if (playerDatingController.playerReplySymbols.activeSelf)
            playerDatingController.playerCanReply = true;
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
