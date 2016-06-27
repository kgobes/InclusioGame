using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textChange : MonoBehaviour {
	public static Text charName;
	public Button genChar;
	// Use this for initialization
	void Start () {
		charName = GameObject.Find ("charName").GetComponent<Text>();
		charName.enabled = false;
		genChar = GameObject.Find ("GenChar").GetComponent<Button>();
		genChar.GetComponentInChildren<Text>().text = "Generate Character";
		//connect start text to button to change scene ***

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clickGenChar(){
		charName.text = generateCharacter ();
	}

	public string generateCharacter(){
		int x = Random.Range (1,4);
		Debug.Log (x);
		string character = "";
		if (x == 1)
			character = "Turtle";
		else if(x == 2)
			character = "Lion";
		else if(x == 3)
			character = "Bird";
		return character;

	}

}
