using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDatingController : MonoBehaviour
{
    [SerializeField] float replyDuration = 5.0f;

    public int playerResponse = 0; //0 = None, 1 = Good, 2 = Bad (Remake into Enums later?)
    public int dateInterest = 0;

    DateDialogueController dateDialogueController;

    void Awake()
    {
        dateDialogueController = GetComponent<DateDialogueController>();
    }

    public IEnumerator GetReply()
    {
        playerResponse = 0;
        float timeToReply = 0;
        while (playerResponse == 0 && timeToReply < replyDuration)
        {
            timeToReply += Time.deltaTime;
            yield return null;
        }
        if (playerResponse == 0)
            dateInterest -= 1;
        else if (playerResponse == 1)
            dateInterest += 1;
    }

    public void PlayerRepliesYes()
    {
        playerResponse = dateDialogueController.positiveReplyIsRewarded ? 1 : 2;
    }
    
    public void PlayerRepliesNo()
    {
        playerResponse = dateDialogueController.positiveReplyIsRewarded ? 2 : 1;
    }
}
