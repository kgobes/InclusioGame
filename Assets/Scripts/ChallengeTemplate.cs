using UnityEngine;
using System.Collections;
//template for all challenges

public class ChallengeTemplate: MazePassage {
	public int number;
	public string story;
	public string question;
	public string op1;
	public string op2;
	public string op3;

	public ChallengeTemplate(int number, string story, string question, string op1, string op2, string op3){
		this.number = number;
		this.story = story;
		this.question = question;
		this.op1 = op1;
		this.op2 = op2;
		this.op3 = op3;
	}

	public int getNumber(){
		return number;
	}
	public string getStory(){
		return story;
	}

}
