using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//template for all challenges

public class ChallengeTemplate { 
	public int number;
	public string story;
	public bool dependent; 

	public List<Option> options = new List<Option> ();

	public ChallengeTemplate(int number, string story, bool dep){
		this.number = number;
		this.story = story;
		dependent = dep;

	}

	public int getNumber(){
		return number;
	}
	public string getStory(){
		return story;
	}
	public void addOption(string buttonText, int num){
		Option x = new Option (buttonText, num);
		options.Add (x);
	}
	public List<Option> getOptionList(){
		return options;
	}
	public bool getDependent(){
		return dependent;
	}
}
