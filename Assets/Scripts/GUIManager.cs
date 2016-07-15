using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	static GUIText finished;
	// Use this for initialization
	void Start () {
		//finished = GameObject.Find ("Finished").GetComponent<GUIText>();
		//finished.active = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void endOfGame(){
		Debug.Log ("in eog");
		Application.LoadLevel ("ChooseCharacter");
		//finished = isActiveAndEnabled; 
	}
}
