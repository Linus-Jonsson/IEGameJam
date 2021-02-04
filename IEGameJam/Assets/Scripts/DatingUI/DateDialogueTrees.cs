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
        firstLine[0] = "Hello! We finally meet, are you also excited to be here?";
        firstLine[1] = "Hey, we're here, our first date. I hope you're not an axe murderer! Haha... Eh... Are you?";
        firstLine[2] = "Hi! I have a great feeling about this. Have you also been longing for this day?";
        firstLine[3] = "Ok, I'm actually a little nervous now that we're here. Be honest, do you regret coming here?";
        
        //Questions where a positive reply from the player is rewarded
        dateQuestionsPositive.Add("Do you think it's important to be kind?");
        dateQuestionsPositive.Add("Do you enjoy walking in forests?");
        dateQuestionsPositive.Add("Is there a meaning to life?");
        dateQuestionsPositive.Add("Do you care about animals?");
        dateQuestionsPositive.Add("Can you cook?");
        dateQuestionsPositive.Add("Are you a fan of the old tv show Lost?");
        dateQuestionsPositive.Add("Do you care about the environment?");
        dateQuestionsPositive.Add("Is Tool probably the best band in the world?");
        dateQuestionsPositive.Add("Would you kiss on the first date?");
        dateQuestionsPositive.Add("Have you ever made someone breakfast in bed??");
        dateQuestionsPositive.Add("Have you ever written someone a love poem?");
        dateQuestionsPositive.Add("Is lying to keep from hurting someone's feeling okay?");
        dateQuestionsPositive.Add("Are you known for keeping your word?");
        
        //Questions where a negative reply from the player is rewarded
        dateQuestionsNegative.Add("Is personal greed important to you?");
        dateQuestionsNegative.Add("Are you pursuing a career in game development?");
        dateQuestionsNegative.Add("Do you read comic books?");
        dateQuestionsNegative.Add("Did you kill small animals when you were young?");
        dateQuestionsNegative.Add("Are you passionate about war?");
        dateQuestionsNegative.Add("Is Christer Sandelin your favorite artist?");
        dateQuestionsNegative.Add("Have you ever killed anyone?");
        dateQuestionsNegative.Add("Will you ever grow up?");
        dateQuestionsNegative.Add("Have you ever told someone you love them even though you don't?");
        dateQuestionsNegative.Add("Have you ever dumped someone over text message?");
        dateQuestionsNegative.Add("Is your arm bigger than your thigh?");
        dateQuestionsNegative.Add("Some kind of flu seems to be spreading. Have you had any symptoms?");
        dateQuestionsNegative.Add("Do you think that Citizen Kane is an overrated movie?");
        dateQuestionsNegative.Add("If your mother looked through your texts right, would you be ashamed?");

        //Response when the player doesn't give a reply within set time limit
        dateAngryResponse.Add("Hello, are you listening?!");
        dateAngryResponse.Add("This is so frustrating!");
        dateAngryResponse.Add("What a sad date!");
        dateAngryResponse.Add("Feels like I'm talking to myself!");
        dateAngryResponse.Add("Wow, silence is such a profound answer... NOT!");
        dateAngryResponse.Add("I don't know how much longer I will take this!");
        dateAngryResponse.Add("Really!? You're just gonna sit there?!?");
        
        //Response when the player gives a reply that is rewarded
        datePositiveResponse.Add("Wow, that's great!");
        datePositiveResponse.Add("Amazing! I think I like you even more now.");
        datePositiveResponse.Add("Cool, you seem to be a good person.");
        datePositiveResponse.Add("I was hoping you'd say that!");
        datePositiveResponse.Add("That's just terrific!");
        datePositiveResponse.Add("You are simply perfect!");
        datePositiveResponse.Add("Really..? I LOVE it!");
        
        //Response when the player gives a reply that is not rewarded
        dateNegativeResponse.Add("Hm, that's too bad...");
        dateNegativeResponse.Add("Oh, really? That's just... sad.");
        dateNegativeResponse.Add("What? How old are you?!");
        dateNegativeResponse.Add("Ok, sorry to hear that...");
        dateNegativeResponse.Add("Not exactly what I was hoping for.");
        dateNegativeResponse.Add("Maybe you're not the one I'm looking for...");
        dateNegativeResponse.Add("You do know that you can lie sometimes? Might help you.");
        
        //Final line from date if date's affection is high enough
        lastLineWin = "You know what? If we're still alive tomorrow I would LOOOVE another date!!";
        
        //Final line from date if date's affection is to low
        lastLineLose = "You know what!?! I'm tired of this shit, just STAY AWAY from me!!";
    }
}
