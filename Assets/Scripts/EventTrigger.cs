using UnityEngine;
using System.Collections;

public class EventTrigger : MazePassage {
	//public ChallengeManager cm;
	// Use this for initialization
	void Start () {
		Debug.Log ("event trigger start");
		//cm = GameObject.Find("Challenge Manager").GetComponent<ChallengeManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "player") {
			Debug.Log("collison with player");
			Player p = GameObject.Find ("player").GetComponent <Player>();
			p.canMove (false);
			//GameObject cm = GameObject.Find ("Challenge Manager").GetComponent <ChallengeManager>();
			GameManager.pauseTime ();
			//cm.chooseNextScen();
			ChallengeManager.chooseNextScen();
			Destroy (this.gameObject);
			
		}
	}
}
