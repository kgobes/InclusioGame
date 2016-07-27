using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public static Text eventText;
	public static Image textPanel;

	// Use this for initialization
	void Start () {
		eventText = GameObject.Find ("EventText").GetComponent<Text>();
		textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		//textPanel.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	public static Rect windowRect = new Rect(20, 20, 120, 50);
	public static void displayText(string text){
		Debug.Log ("in Display Text");
		textPanel.gameObject.SetActive (true);
		eventText.text = text;
	}
	public void clickContinue(){
		Player p = GameObject.Find ("player").GetComponent<Player>();
		p.canMove (true);
		textPanel.gameObject.SetActive (false);
		GameManager.continueTime ();
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
