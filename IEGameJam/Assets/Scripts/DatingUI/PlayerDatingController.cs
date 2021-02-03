using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDatingController : MonoBehaviour
{
    [SerializeField] GameObject playerReplySymbols = null;
    [SerializeField] float replyTimeLimit = 5.0f;

    public int playerResponse = 0; //0 = Bad, 1 = Good, 2 = Neutral
    public int dateInterest = 0;

    bool playerCanReply;
    
    DateDialogueController dateDialogueController;

    void Awake()
    {
        dateDialogueController = GetComponent<DateDialogueController>();
    }

    void Update()
    {
        if (!playerCanReply) return;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PlayerRepliesYes();
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            PlayerRepliesNo();
    }

    public IEnumerator GetReply()
    {
        playerReplySymbols.SetActive(true);
        playerCanReply = true;
        playerResponse = 0;
        float replyDuration = 0;
        while (playerResponse == 0 && replyDuration < replyTimeLimit)
        {
            replyDuration += Time.deltaTime;
            yield return null;
        }
        if (playerResponse == 0)
            dateInterest -= 1;
        else if (playerResponse == 1)
            dateInterest += 1;
        playerCanReply = false;
        playerReplySymbols.SetActive(false);
    }

    void PlayerRepliesYes()
    {
        playerResponse = dateDialogueController.positiveReplyIsRewarded ? 1 : 2;
    }

    void PlayerRepliesNo()
    {
        playerResponse = dateDialogueController.positiveReplyIsRewarded ? 2 : 1;
    }
}
