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
        //Handle lose stuff
    }
    
    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
