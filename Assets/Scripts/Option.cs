using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public struct EndItemInfo
{
    public EndItemInfo(string inName, Sprite inImage)
    {
        this.name = inName;
        this.image = inImage;
    }
    public string name;
    public Sprite image;
}

public class Option
{
	public string buttonText;
	public string resultText;
	public int num;




	public Option(string b, int n){
		buttonText = b;
		num = n;

	}


	public string getButtonText(){
		return buttonText;
	}
	public string getResultText(){
		return resultText;
	}
	public int getOpNum(){
		return num;
	}

	public void executeResult(ResourceBar inResourceBar){
		//ChallengeManager cm = GameObject.Find ("Challenge Manager").GetComponent <ChallengeManager>();
		if (num == 1) {
			resultText = "The other elves angrily leave, but the troll is safe and is thankful for your help and joins you.";
            inResourceBar.addResource("sprites/spr_troll");
            GameManager.AddSurvivedCharacter(new EndItemInfo("Troll", Resources.Load<Sprite>("sprites/spr_troll")));
			ChallengeManager.setNext (2);
		}
		if (num == 2) {
			resultText = "The troll is captured under a net and the other elves thank you for taking their side.";
			ChallengeManager.setNext (2);
		}
		if (num == 3) {
            if (inResourceBar.checkResource("sprites/spr_troll"))
            {
				resultText = "You make it through the gate and the troll is reunited with his family.";
                inResourceBar.useResource("sprites/spr_troll");
			}
			else
				resultText = "Hmmm doesn't look like you have a troll here to help you. Maybe you should see if you can find one...";
		}
		if (num == 4) {
			int rand = Random.Range (1, 2);
			if(rand == 1){
				resultText = "You unintentionally offend them and they whack you with their club. You lose 5 health points.";
                inResourceBar.incrementHealth(-5);
			}
			else if(rand == 2){
				resultText = "You got lucky! The trolls let you through the gate.";
			}
		}
		if (num == 5) {
				resultText = "The pixie is grateful and asks if he can hang out with you for a bit. You let him tag along, why not?";
                inResourceBar.addResource("sprites/spr_pixie");
				ChallengeManager.setNext (4);
		}
		if (num == 6) {
			resultText = "You leave the pixie laying on the ground with it’s torn wing and continue on your journey.";
			ChallengeManager.setNext (4);
		}
		if (num == 7) {
			resultText = "You lost some time going around.";
			GameManager.changeTime (20);
		}
		if (num == 8) {
            if (inResourceBar.checkResource("sprites/spr_pixie"))
            {
				resultText = "You make it through the wall.";
                inResourceBar.useResource("sprites/spr_pixie");
			}
			else{
				resultText = "Hmmm doesn't look like you have a pixie here to help you. Maybe you should see if you can find one...";
			}
		}
		if (num == 9) {
			resultText = "The unicorn refuses to join based on your team’s negative response towards it. Some of your team is furious and insult you for it, which makes you feel bad.";
            inResourceBar.incrementHealth(-10);
		}
		if (num == 10) {
			resultText = "Your team is happy, but the unicorn blocks your path.";
				GameManager.changeTime (20);
		}

		if (num == 11) {
			resultText = "A unicorn set this pot of gold as a test. By not stealing it, you gained its trust and he offers to split the pot with you in exchange for some food.";
            inResourceBar.addResource("sprites/PotofGold");
			
		}
		if (num == 12) {
			int rand = Random.Range (1, 2);
			if(rand == 1){
				resultText = "You now have loads of coins.";
                inResourceBar.addResource("sprites/PotofGold");
			}
			if(rand == 2){
				resultText = "A unicorn placed the pot as a trick and you fell for it. He takes the gold back and pokes you with his horn.";
                inResourceBar.incrementHealth(-5);
			}
		}
		if (num == 13) {
			resultText = "You lost a lot of time making fun of this creature.";
			GameManager.changeTime (10);
		}
		if (num == 14) {
			resultText = "You continue on your journey.";
		}
		if(num == 15){
			int rand = Random.Range (1, 2);
			if(rand == 1){
				resultText = "The elves get mad and continue teasing the pixie anyway. They also insult you! You decide to move on and continue on your journey.";
			}
			if(rand == 2){
				resultText = "You save the pixie! As a token of appreciation it gives you 5 health points and joins your team!";
                inResourceBar.incrementHealth(5);
			}
		}
		if(num == 16){ //come back to this one
            inResourceBar.checkResource("sprites/potion");
			resultText = "You are now a wolf! The other wolves let you pass. But now you are stuck as a wolf for an unknown amount of time.";
            inResourceBar.useResource("sprites/potion");

			
		}
		if(num == 17){ 
			int rand = Random.Range (1, 2);
			if(rand == 1){
				resultText = "The werewolves refuse to listen to you and you must go a different route.";
				GameManager.changeTime(30);
			}
			if(rand == 2){
				resultText = "The werewolves determine that you are cool and let you through.";
			}
		}
		
		if(num == 19){
			int rand = Random.Range (1, 2);
			if(rand == 1){
				resultText = "You learn that you can’t solve it by yourself and can’t get around wizard.";
				GameManager.changeTime (30);
			}
			if(rand == 2){
				resultText = "You get through but have to abandon some of your team.";
			}
		}
		if(num == 20){
			resultText = "You solve all three puzzles, but lose more time.";
			GameManager.changeTime (30);
		}
		if(num == 21){
			resultText = "You run into a different group of ogres, and the one you helped helps you pass their clan.";
		}
		if(num == 22){
			resultText = "You have to take a longer route because you cannot pass through the clan.";
			GameManager.changeTime (30);
		}
		if(num == 23){
			resultText = "She sneaks away with some of your food, which causes you to go hungry.";
			inResourceBar.incrementHealth (-10);
		}
		if(num == 24){
			resultText = "Turns out she was a wanted fairy who often conned travelers - you get coin reward.";
            inResourceBar.addResource("sprites/PotofGold");
		}
		if(num == 25){
			resultText = "This takes time, but the pixie is so grateful that it rewards you with 5 health points.";
			inResourceBar.incrementHealth (5);
		}
		if (num == 26) {
			resultText = "You continue on your way.";
		}
		if(num == 27){
			resultText = "The pixie looks angry, but you got some sweet snacks that make you feel better and continue on your way.";
			inResourceBar.incrementHealth (5);
		}
		if (num == 28) {
			resultText = "The dwarf is helpful and points you in the right direction, which saves you some time";
			GameManager.changeTime (-20);

		}
		if(num == 29){
			resultText = "You’re in an enchanted maze, why would you think you know where you are going? You get lost and it takes you a while to get back on the path."; 
			GameManager.changeTime (20);
		}
		if (num == 30) {
			resultText = "That was nice of you. You don't even lose any time, becuase talking through the directions with the giant helped you decide faster which way you wanted to go.";
		}
		if (num == 31) {
			resultText = "The giant looks disappointed, but you nervously scamper down the path.";
		}
		if (num == 32) {
			resultText = "The elves are thrilled to have more company! The song is interesting- you note a line that curiously says that the secret is 'Hans Christian Anderson'. Hmm.";
			GameManager.changeTime (20);
			ChallengeManager.setNext (16);
			ChallengeManager.setCorrect (true);
		}
		if (num == 33) {
			resultText = "You continue on your way.";
			ChallengeManager.setNext(16);
			ChallengeManager.setCorrect (false);
		}
		if (num == 34) {
			if(ChallengeManager.getCorrect())
				resultText = "You enter the correct password Hans Christian Anderson and make it through!";
			else{
				resultText = "Maybe you should have listened to those elves, they probably had some useful information in their song. Because you don't have the password, you run into the gate until it breaks. Ouch.";
				inResourceBar.incrementHealth(-5);
			}
		}
		if (num == 35) {
			resultText = "You run into the gate until it breaks. Ouch.";
            inResourceBar.incrementHealth(-5);
		}
		if (num == 37) {
			resultText = "You continue down the path.";
		}
		if (num == 38) {
			int rand = Random.Range (1, 2);
			if(rand == 1){
				resultText = "The witch is so grateful that she gives you a potion as a thank you. Sweet!";
                inResourceBar.addResource("sprites/potion");
			}
			if(rand == 2){
				resultText = "The witch pulls you down with her in an attempt to steal all of your stuff. Thankfully you escape with only a small loss to your health.";
                inResourceBar.incrementHealth(-5);
			}
		}
		if (num == 39 || num == 40) {
			resultText = "Hopefully no one saw that!";
            inResourceBar.incrementHealth(-5);
		}
		if (num == 41) {
			resultText = "He complies, but is grumpy about it and mutters about your ignorance. You take a new path to avoid contact with him.";
			GameManager.changeTime (10);
		}
		if (num == 42) {
			resultText = "He complies, but is grumpy about it and mutters about your ignorance. You take a new path to avoid contact with him.";
			GameManager.changeTime (10);
		}
		if (num == 43) {
			resultText = "Although the argument was uncomforatble, the character appreciates your patience and explains what the pendant means to him. Turns out, it represents something completely different to him than to you. Interesting.";
		} 
		if (num == 44) {
			resultText = "Ahhh.. so relaxing. That was refreshing.";
			GameManager.changeTime (10);
			inResourceBar.incrementHealth (5);
		}
		if (num == 45) {
			resultText = "Continue down the path.";
		}


        // TO DO store a ref so Find isn't called every time we need to call GUIManager
        GameObject.Find("Canvas").GetComponent<GUIManager>().showResult(resultText);
		
	}
	
}
