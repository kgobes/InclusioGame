using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public static Text eventText;
	public static Image textPanel;

	// Use this for initialization
	void Start () {
		//finished = GameObject.Find ("Finished").GetComponent<GUIText>();
		//finished.active = false;
		//finished = GameObject.Find ("story").GetComponent<GUIText>();

		eventText = GameObject.Find ("EventText").GetComponent<Text>();
		textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		textPanel.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void displayText(string text){
		textPanel.gameObject.SetActive (true);
		eventText.text = text;
	}
	public void clickContinue(){
		Player p = GameObject.Find ("player").GetComponent<Player>();
		textPanel.gameObject.SetActive (false);
		//p.canMove (true);
	}

	public static void endOfGame(){
		Debug.Log ("in eog");
		Application.LoadLevel ("StartScreen");
//		GameManager.setGameStarted (false);
//		score = GameManager.getTime ();

		//finished = isActiveAndEnabled; 
	}
}
