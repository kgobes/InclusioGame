using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChallengeManager : MazePassage {
	//public Challenge chal;
	//public Transform hinge;

	// Use this for initialization
	void Start () {
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
			displayNextChallenge ();
		}
	}
	void displayNextChallenge(){
		//Panel panel = new Panel ();
	//	CreateButton 
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
