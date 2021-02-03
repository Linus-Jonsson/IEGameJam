using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateDialogueTrees : MonoBehaviour
{
    internal string[] firstLine = new string[4];
    internal List<string> dateQuestionsPositive = new List<string>();
    internal List<string> dateQuestionsNegative = new List<string>();
    internal List<string> dateAngryResponse = new List<string>();
    internal List<string> datePositiveResponse = new List<string>();
    internal List<string> dateNegativeResponse = new List<string>();
    internal string lastLineWin;
    internal string lastLineLose;

    internal void FillDialogueTrees()
    {
        //Even numbers are questions where a positive reply is rewarded
        firstLine[0] = "Hello! We finally meet, are you also happy to be here?";
        firstLine[1] = "Hola! You seem VERY exciting. Would you call yourself a dangerous person?";
        firstLine[2] = "Hi! What a great day. Have you also been longing for this day?";
        firstLine[3] = "Hiya! I'm a little nervous. Do you regret coming here?";
        
        //Questions where a positive reply from the player is rewarded
        dateQuestionsPositive.Add("Do you think it's important to be kind?");
        dateQuestionsPositive.Add("Do you enjoy walking in forests?");
        dateQuestionsPositive.Add("Is there a meaning to life?");
        dateQuestionsPositive.Add("Do you care about animals?");
        dateQuestionsPositive.Add("Can you cook?");
        dateQuestionsPositive.Add("Are you a fan of the old tv show Lost?");
        dateQuestionsPositive.Add("Do you care about the environment?");
        dateQuestionsPositive.Add("Is TOOL probably the best band in the world?");
        
        //Questions where a negative reply from the player is rewarded
        dateQuestionsNegative.Add("Is personal greed important to you?");
        dateQuestionsNegative.Add("Are you pursuing a career in game development?");
        dateQuestionsNegative.Add("Do you read comic books?");
        dateQuestionsNegative.Add("Did you kill small animals when you were young?");
        dateQuestionsNegative.Add("Are you passionate about war?");
        dateQuestionsNegative.Add("Is Christer Sandelin your favorite artist?");
        dateQuestionsNegative.Add("Have you ever killed anyone?");
        dateQuestionsNegative.Add("Will you ever grow up?");
        
        //Response when the player doesn't give a reply within set time limit
        dateAngryResponse.Add("Hello, are you listening?!");
        dateAngryResponse.Add("This is so frustrating!");
        dateAngryResponse.Add("What a sad date!");
        dateAngryResponse.Add("Feels like I'm talking to myself!");
        dateAngryResponse.Add("Wow, silence is such a profound answer... NOT!");
        
        //Response when the player gives a reply that is rewarded
        datePositiveResponse.Add("Wow, that's great!");
        datePositiveResponse.Add("Amazing! I think I like you even more now.");
        datePositiveResponse.Add("Cool, you seem to be a good person.");
        datePositiveResponse.Add("I was hoping you'd say that!");
        datePositiveResponse.Add("That's terrific!");
        datePositiveResponse.Add("You are just perfect!");
        datePositiveResponse.Add("Really..? I LOVE it!");
        
        //Response when the player gives a reply that is not rewarded
        dateNegativeResponse.Add("That's too bad...");
        dateNegativeResponse.Add("Oh, really? Not great.");
        dateNegativeResponse.Add("What? How old are you?!");
        dateNegativeResponse.Add("Ok, sorry to hear that...");
        dateNegativeResponse.Add("Not exactly what I was hoping for.");
        dateNegativeResponse.Add("Maybe you're not the one I'm looking for...");
        
        //Final line from date if date's affection is high enough
        lastLineWin = "You know what? If we're still alive tomorrow I would LOOOVE another date!!";
        
        //Final line from date if date's affection is to low
        lastLineLose = "You know what!?! I'm tired of this shit, just stay away from me!!";
    }
}
