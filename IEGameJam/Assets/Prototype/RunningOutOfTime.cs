using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class RunningOutOfTime : MonoBehaviour
{
    
    private float timer;
    [SerializeField] private float timerSpeed;
    private float resetTimer;
    [SerializeField] private Text timeUI;
    [SerializeField] private Text gameOverUI;


    private void Start() {
        resetTimer = 100;
        timer = resetTimer;
        gameOverUI.gameObject.SetActive(false);
    }

    private void Update() {
        timer -= Time.deltaTime * timerSpeed;
        timeUI.text = string.Format(timer.ToString());
        if (timer <= 0) {
            Debug.Log("Game over");
            gameOverUI.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResetTimer() {
        timer = resetTimer;
    }

}
