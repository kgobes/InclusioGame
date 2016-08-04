using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Option{
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

	public void executeResult(){
		//ChallengeManager cm = GameObject.Find ("Challenge Manager").GetComponent <ChallengeManager>();
		if (num == 1) {
			resultText = "The other elves angrily leave, but the troll is safe and is thankful for your help and joins you.";
			ResourceBar.addResource ("troll");
			ChallengeManager.setNext (2);
		}
		if (num == 2) {
			resultText = "The troll is captured under a net and the other elves thank you for taking their side.";
			ChallengeManager.setNext (2);
		}
		if (num == 3) {
			if(ResourceBar.checkResource ("troll")){
				resultText = "You make it through the gate and the troll is reunited with his family.";
				ResourceBar.useResource ("troll");
			}
			else
				resultText = "Hmmm doesn't look like you have a troll here to help you. Maybe you should see if you can find one...";
		}
		if (num == 4) {
			int rand = Random.Range (1, 2);
			if(rand == 1){
				resultText = "Unintentionally offend them and they whack you with their club. You lose 5 health points."; 
				ResourceBar.incrementHealth (-5);
			}
			else if(rand == 2){
				resultText = "You got lucky! The trolls let you through the gate.";
			}
		}
		if (num == 5) {
			int rand = Random.Range (1, 2);
			if(rand == 1){
				resultText = "You lose 2 points of your own health.";
				ResourceBar.incrementHealth (-5);
				ChallengeManager.setNext (4);
			}
			else if(rand == 2){
				resultText = "The pixie is so grateful that he asks to join your team.";
				ResourceBar.addResource ("pixie");
				ChallengeManager.setNext (4);
			}
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
			if(ResourceBar.checkResource ("pixie")){
				resultText = "You make it through the wall.";
				ResourceBar.useResource ("pixie");
			}
			else{
				resultText = "Hmmm doesn't look like you have a pixie here to help you. Maybe you should see if you can find one...";
			}
		}
		if (num == 9) {
			resultText = "The unicorn refuses to join based on your team’s negative response towards it. Some of your team is furious and insult you for it, which makes you feel bad.";
				ResourceBar.incrementHealth (-10);
		}
		if (num == 10) {
			resultText = "Your team is happy, but the unicorn blocks your path.";
				GameManager.changeTime (20);
		}

		if (num == 11) {
			resultText = "A unicorn set this pot of gold as a test. By not stealing it, you gained its trust and he offers to split the pot with you in exchange for some food.";
			//ADD COINSSSSS ***
			
		}
		if (num == 12) {
			int rand = Random.Range (1, 2);
			if(rand == 1){
				resultText = "You now have loads of coins.";
				//ADD COINSSS*****
			}
			if(rand == 2){
				resultText = "A unicorn placed the pot as a trick and you fell for it. He takes the gold back and pokes you with his horn.";
				ResourceBar.incrementHealth (-5);
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
				ResourceBar.incrementHealth (5);
			}
		}
		if(num == 16){ //come back to this one
			//NEED POTION *** 
			resultText = "You are now a wolf! The other wolves let you pass. But now you are stuck as a wolf for an unknown amount of time.";
			//LOST POTION **
			
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
/*Result 2: You get through but some of your group doesn’t
Action: You must chose one of these options 
Option 1: Continue without them
Option 2: Go back and help them and lose time 
Result 3: You all get through
Action: Nothing 
*/
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
		
		GUIManager.showResult (resultText);
		
	}
	
}
