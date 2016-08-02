using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

	public static Text eventText;
	public static Image textPanel;
	public static Button opt1;
	public static Button opt2;
	public static Button opt3;

	public static Option optObject1;
	public static Option optObject2;
	public static Option optObject3;


	public static Text resText;
	public static Image resultPanel;
	public static Button cont;

    private Player playerRef;

	// Use this for initialization
	void Start () {
		eventText = GameObject.Find ("EventText").GetComponent<Text>();
		textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		opt1 = GameObject.Find ("option1").GetComponent <Button>();
		opt2 = GameObject.Find ("option2").GetComponent <Button>();
		opt3 = GameObject.Find ("option3").GetComponent <Button>();

	

		resText = GameObject.Find ("ResultText").GetComponent<Text>();
		resultPanel = GameObject.Find ("ResultPanel").GetComponent <Image> ();
		cont = GameObject.Find ("Continue").GetComponent <Button>();
		resultPanel.gameObject.SetActive(false);
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
	public static void displayOptions(List<Option> optionList){
		if (optionList.Count == 2) {
			opt1.gameObject.SetActive (true);
			opt2.gameObject.SetActive (true);
			opt3.gameObject.SetActive (false);
			opt1.GetComponentInChildren<Text>().text = optionList[0].getButtonText();
			opt2.GetComponentInChildren<Text>().text = optionList[1].getButtonText();
			optObject1 = optionList[0];
			optObject2 = optionList[1];
		}
		else if (optionList.Count == 3) {
			opt1.gameObject.SetActive (true);
			opt2.gameObject.SetActive (true);
			opt3.gameObject.SetActive (true);
			opt1.GetComponentInChildren<Text>().text = optionList[0].getButtonText();
			opt2.GetComponentInChildren<Text>().text = optionList[1].getButtonText();
			opt3.GetComponentInChildren<Text>().text = optionList[2].getButtonText();
			optObject1 = optionList[0];
			optObject2 = optionList[1];
			optObject3 = optionList[2];

		}

	}
	public void clickOption1(){
		optObject1.executeResult ();
		textPanel.gameObject.SetActive (false);
	}
	public void clickOption2(){
		optObject2.executeResult ();
		textPanel.gameObject.SetActive (false);
	}
	public void clickOption3(){
		optObject3.executeResult ();
		textPanel.gameObject.SetActive (false);
	}
	/*public void clickContinue(){
		Player p = GameObject.Find ("player").GetComponent<Player>();
		p.canMove (true);
		textPanel.gameObject.SetActive (false);
		GameManager.continueTime ();
		//p.canMove (true);
	}*/

	public void clickContinue(){
		resultPanel.gameObject.SetActive(false);
        playerRef = GameObject.Find("player").GetComponent<Player>();
        playerRef.canMove(true);
	}
	public static void showResult(string resultText){
		resultPanel.gameObject.SetActive (true);
		resText.text = resultText;
	}
}
