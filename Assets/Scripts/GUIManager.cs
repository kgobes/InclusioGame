using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	static GUIText finished;
	public GUIText story;
	public int timer = 0;
	public int partTime = 0;
	public int score;
	// Use this for initialization
	void Start () {
		//finished = GameObject.Find ("Finished").GetComponent<GUIText>();
		//finished.active = false;
		//finished = GameObject.Find ("story").GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		partTime += 1;
		if (partTime == 60) {
			timer += 1;
			//story = "new";
			partTime = 0;

		}
	}
	public static void endOfGame(){
		Debug.Log ("in eog");
		Application.LoadLevel ("StartScreen");
//		GameManager.setGameStarted (false);
//		score = GameManager.getTime ();

		//finished = isActiveAndEnabled; 
	}
}
