using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = System.Random;

public class DateDialogueController : DateDialogueTrees
{
    [SerializeField] TMP_Text dateText = null;
    [SerializeField] float dateTextSpeed = 2.0f;
    [SerializeField] float timeBetweenDateLines = 1.0f;
    
    [SerializeField] RawImage dateSplash = null;
    [SerializeField] GameObject playerButtons = null;
    
    [SerializeField] int questionLimit = 5;
    [SerializeField] int dateInterestWinState = 3;
    
    [SerializeField] GameObject brokenHeartFX = null;
    [SerializeField] GameObject heartFX = null;

    public bool positiveReplyIsRewarded;
    int amountOfQuestionsAsked = 0;
    
    PlayerDatingController playerDatingController;
    GameLoopController gameLoopController;

    void Awake()
    {
        playerDatingController = GetComponent<PlayerDatingController>();
        gameLoopController = FindObjectOfType<GameLoopController>();
        FillDialogueTrees();
    }

    IEnumerator Start()
    {
        dateSplash.enabled = false;
        dateText.maxVisibleCharacters = 0;
        int randomNumber = new Random().Next(firstLine.Length);
        dateText.text = firstLine[randomNumber];
        if (randomNumber % 2 == 0)
            positiveReplyIsRewarded = true;
        yield return new WaitForSeconds(2f);
        while (amountOfQuestionsAsked < questionLimit)
        {
            yield return StartCoroutine(DateLine(dateText));
            playerButtons.SetActive(true);
            yield return StartCoroutine(playerDatingController.GetReply());
            playerButtons.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            dateSplash.enabled = false;
            dateText.maxVisibleCharacters = 0;
            dateText.text = DateReplyGenerator();
            yield return new WaitForSeconds(timeBetweenDateLines);
            DateReactionFX();
            yield return StartCoroutine(DateLine(dateText));
            dateSplash.enabled = false;
            dateText.maxVisibleCharacters = 0;
            if (playerDatingController.dateInterest >= dateInterestWinState)
            {
                dateText.text = lastLineWin;
                yield return new WaitForSeconds(timeBetweenDateLines);
                yield return StartCoroutine(DateLine(dateText));
                gameLoopController.HandleWinState();
            }
            dateText.text = DateQuestionGenerator();
            yield return new WaitForSeconds(timeBetweenDateLines * 2);
            amountOfQuestionsAsked += 1;
        }
        
        Debug.Log("THE END!");
    }

    private IEnumerator DateLine(TMP_Text text)
    {
        dateSplash.enabled = true;
        yield return new WaitForSeconds(0.2f);
        int totalVisibleCharacters = text.textInfo.characterCount;
        int counter = 0;
        while (counter < totalVisibleCharacters + 1)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            text.maxVisibleCharacters = visibleCount;
            counter += 1;
            yield return new WaitForSeconds(0.1f / dateTextSpeed);
        }
        yield return new WaitForSeconds(timeBetweenDateLines);
    }
    
    string DateQuestionGenerator()
    {
        string dateQuestion = "...";
        int randomIndex = new Random().Next(dateQuestionsPositive.Count + dateQuestionsNegative.Count - 1);
        if (randomIndex < dateQuestionsPositive.Count)
        {
            dateQuestion = dateQuestionsPositive[randomIndex];
            dateQuestionsPositive.RemoveAt(randomIndex);
            positiveReplyIsRewarded = true;
        }
        else
        {
            dateQuestion = dateQuestionsNegative[randomIndex % dateQuestionsNegative.Count];
            dateQuestionsNegative.RemoveAt(randomIndex % dateQuestionsNegative.Count); 
            positiveReplyIsRewarded = false;
        }
        return dateQuestion;
    }
    
    string DateReplyGenerator()
    {
        string dateReply = "...";
        int randomIndex;
        switch (playerDatingController.playerResponse)
        {
            case 0:
                randomIndex = new Random().Next(dateAngryResponse.Count - 1);
                dateReply = dateAngryResponse[randomIndex];
                dateAngryResponse.RemoveAt(randomIndex);
                break; 
            case 1:
                randomIndex = new Random().Next(datePositiveResponse.Count - 1);
                dateReply = datePositiveResponse[randomIndex];
                datePositiveResponse.RemoveAt(randomIndex);
                break;
            case 2:
                randomIndex = new Random().Next(dateNegativeResponse.Count - 1);
                dateReply = dateNegativeResponse[randomIndex];
                dateNegativeResponse.RemoveAt(randomIndex);
                break;
        }
        return dateReply;
    }

    private void DateReactionFX()
    {
        Vector3 offset = new Vector3(-2, 0, 0);
        if (playerDatingController.playerResponse == 0)
            Instantiate(brokenHeartFX, transform.position + offset, Quaternion.identity);
        else if (playerDatingController.playerResponse == 1)
            Instantiate(heartFX, transform.position + offset, Quaternion.identity);
    }
}