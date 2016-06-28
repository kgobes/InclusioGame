using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textChange : MonoBehaviour {
	public static Text charName;
	public Button genChar;
	public Image charPic;
	public Sprite fish;
	public Sprite lion;
	public Sprite penguin;
	// Use this for initialization
	void Start () {
		charName = GameObject.Find ("charName").GetComponent<Text>();
		charName.enabled = false;
		genChar = GameObject.Find ("GenChar").GetComponent<Button>();
		genChar.GetComponentInChildren<Text>().text = "Generate Character";
		charPic = GameObject.Find ("charPic").GetComponent<Image>();
		//charPic = GetComponent<SpriteRenderer> ();
		charPic.enabled = false;

		//images
		/*fish = GameObject.Find ("fish").GetComponent<Sprite>();
		lion = GameObject.Find ("lion").GetComponent<Sprite>();
		penguin = GameObject.Find ("penguin").GetComponent<Sprite>();*/
		fish = Resources.Load <Sprite>("fish");
		lion= Resources.Load <Sprite>("lion");
		penguin= Resources.Load <Sprite>("peng");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clickGenChar(){
		charName.text = generateCharacter ();
	}

	public string generateCharacter(){
		charPic.enabled = true;
		int x = Random.Range (1,4);
		Debug.Log (x);
		string character = "";
		if (x == 1) {
			character = "Fish";
			//charPic.sprite = Resources.Load<Sprite>("fish.jpg");
			//charPic.GetComponent<Image>().sprite = fish;
			if(fish)
				charPic.sprite = fish;
			else
				Debug.LogError ("Sprite not found", this);
		} else if (x == 2) {
			character = "Lion";
			//charPic.sprite = Resources.Load<Sprite>("lion.jpg");
			//charPic.GetComponent<Image>().sprite = lion;
			if(lion)
				charPic.sprite = lion;
			else
				Debug.LogError ("Sprite not found", this);
		} else if (x == 3) {
			character = "Penguin";
			//charPic.sprite = Resources.Load<Sprite>("peng.png");
			//charPic.GetComponent<Image>().sprite = penguin;
			if(penguin)
				charPic.sprite = penguin;
			else
				Debug.LogError ("Sprite not found", this);
		}
		return character;

	}

}
