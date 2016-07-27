using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//template for all challenges

public class ChallengeTemplate {
	public int number;
	public string story;
	public string question;
	public string op1;
	public string op2;
	public string op3;
	public List<string> options = new List<string> ();

	public ChallengeTemplate(int number, string story){
		this.number = number;
		this.story = story;
		/*this.question = question;
		this.op1 = op1;
		this.op2 = op2;
		this.op3 = op3;*/
	}

	public int getNumber(){
		return number;
	}
	public string getStory(){
		return story;
	}
	public void addOption(string op){
		options.Add(op);
	}
}
