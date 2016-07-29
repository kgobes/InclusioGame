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
		if (num == 1) {
			resultText = "The other elves angrily leave, but the troll is safe and is thankful for your help and joins you.";
			ResourceBar.addResource ("troll");
			ChallengeManager.next = 2;
		}
		if (num == 2) {
			resultText = "The troll is captured under a net and the other elves thank you for taking their side.";
			ChallengeManager.next = 2;
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
			}
			else if(rand == 2){
				resultText = "The pixie is so grateful that he asks to join your team.";
				ResourceBar.addResource ("pixie");
			}
		}
		if (num == 6) {
			resultText = "You leave the pixie laying on the ground with it’s torn wing and continue on your journey.";
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

		GUIManager.showResult (resultText);

	}

}
