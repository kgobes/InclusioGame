using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScenarioManager : MonoBehaviour {
	public Text title;
	public Text scenText;
	public Button opt1;
	public Button opt2;
	public Button opt3;

	public int scenCount = 1;
	public int score = 0;

	public Text points;

	// Use this for initialization
	void Start () {
//		title = GameObject.Find ("scenTitle").GetComponent<Text>();
//		scenText = GameObject.Find ("scenText").GetComponent<Text>();
/*		opt1 = GameObject.Find ("opt1").GetComponent<Button>();
		opt2 = GameObject.Find ("opt2").GetComponent<Button>();
		opt3 = GameObject.Find ("opt3").GetComponent<Button>();
		points = GameObject.Find ("points").GetComponent<Text> ();
		points.text = "Points: " + score;*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		Application.LoadLevel ("MazeScene");
	}
	public void exitStartScreenButton(){
		Application.LoadLevel ("ChooseCharacter");
	}
	public void loadNextScenario(){
		score++;
		scenCount++;
		title.text = "Scenario " + scenCount;
		scenText.text = "Text for Scenario " + scenCount;
		opt1.GetComponentInChildren<Text>().text = "new opt1";
		points.text = "Points: " + score;
	}
}
	