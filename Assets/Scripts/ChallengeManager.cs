using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChallengeManager : MazePassage {
	//public Challenge chal;
	//public Transform hinge;
	//public Text eventText;
	//public Image textPanel;

	// Use this for initialization
	void Start () {
		/*eventText = GameObject.Find ("EventText").GetComponent<Text>();
		textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		textPanel.gameObject.SetActive (false);*/
		initializeChallenges ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void initializeChallenges(){
		//create array of challengeTemplates
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "player") {
			Debug.Log ("Collision with player and event");
			Player p = GameObject.Find ("player").GetComponent <Player>();
			//p.canMove (false);
			GUIManager.displayText("Heyo");
			Destroy (this.gameObject);
			//textPanel.gameObject.SetActive (true);
			//eventText.text = "Yooo this will be some interesting scenario thing";
		}
	}

	void displayNextChallenge(){
		//Panel panel = new Panel ();
	}


	/*public void CreateButton(Transform panel ,Vector3 position, Vector2 size, UnityEngine.Events.UnityAction method)
	{
		GameObject button = new GameObject();
		button.transform.parent = panel;
		button.AddComponent<RectTransform>();
		button.AddComponent<Button>();
		button.transform.position = position;
		button.GetComponent<RectTransform>().SetSize(size);
		button.GetComponent<Button>().onClick.AddListener(method);
	}*/
}
