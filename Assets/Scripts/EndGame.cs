using UnityEngine;
using System.Collections;

public class EndGame : MazeCell {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("hey");
		if (other.name == "player")
			GUIManager.endOfGame ();
	}
}
