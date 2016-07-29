using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MazeCell {
	public static int myTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter(Collider other){
		Debug.Log ("hey");
		if (other.name == "player") {
			//GUIManager.endOfGame ();
			GameManager.pauseTime ();
			myTime = GameManager.getTime ();
			setTime (myTime);
			Application.LoadLevel ("EndScene");

		}
	}
	public void OnLevelWasLoaded(int level) {
		if (level == 5) {
			Debug.Log ("time: " + getTime ());
			Text timeText = GameObject.Find ("endTime").GetComponent<Text>();
			timeText.text = "" + getTime ();
		}
	}
	public void setTime(int t){
		myTime = t;
	}
	public int getTime(){
		return myTime;
	}
	public void returnToMenu(){
		Application.LoadLevel ("StartScreen");
	}



}
