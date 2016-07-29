using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChallengeManager : MazePassage {
	//public Challenge chal;
	//public Transform hinge;
	//public Text eventText;
	//public Image textPanel;
	public int numOfChal = 12;
	public static int next = -1;
	public List<ChallengeTemplate> challenges = new List<ChallengeTemplate>();
	public ChallengeTemplate current; 

	// Use this for initialization
	void Start () {
		/*eventText = GameObject.Find ("EventText").GetComponent<Text>();
		textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		textPanel.gameObject.SetActive (false);*/
		checkPosition ();

		initializeChallenges ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void checkPosition(){
		Vector3 sLoc = new Vector3 (-(Maze.size.x-1)/2, 0.5f, -(Maze.size.z-1)/2);
		Vector3 endSpot = new Vector3 (Maze.size.x-1, 0, Maze.size.z-1);
		if ((transform.localPosition == sLoc) || (transform.localPosition == endSpot)) {
			Destroy (this.gameObject);
			Debug.Log ("event destroyed");
		}

	}
	void OnTriggerEnter(Collider other){
		if (other.name == "player") {
			Debug.Log ("Collision with player and event");
			Player p = GameObject.Find ("player").GetComponent <Player>();
			p.canMove (false);
			GameManager.pauseTime ();
			chooseNextScen();
			GUIManager.displayText(current.getStory ());
			GUIManager.displayOptions (current.getOptionList ());
			Destroy (this.gameObject);

		}
	}
	void chooseNextScen(){
		int num;
		if (next == -1)
			num = Random.Range (0, numOfChal);
		else {
			num = next;
			next = -1;
		}
		current = challenges [num];

	}
	void initializeChallenges(){
		//create array of challengeTemplates
		ChallengeTemplate a = new ChallengeTemplate(1, " You encounter a blind troll being attacked by other elves. It calls out for help. Do you help defend him from your own kind or join the other elves in attacking the troll because you heard trolls love to eat elves?",false);
		a.addOption ("Defend the troll and go against your own people.",1);
		a.addOption ("Join in with the other elves attacking the troll",2);

		ChallengeTemplate b = new ChallengeTemplate(2, "A group of trolls is blocking the entrance to a gate.", true);
		b.addOption ("Ask your troll teammate to ask the trolls to allow you to pass.", 3);
		b.addOption ("Use hand gestures to try to communicate.", 4);

		ChallengeTemplate c = new ChallengeTemplate (3, "You come across a pixie on your path. Pixies are notoriously untrustworthy and you’ve had experiences with them tricking you in the past. This pixie is asking for help to heal his torn wing, but helping him involves losing a little of your own health.", false);
		c.addOption ("Agree to help the pixie.", 5);
		c.addOption ("Refuse to help the pixie and continue on with your adventure.", 6);

		ChallengeTemplate d = new ChallengeTemplate (4, "There’s a door in your path and you can’t fit through it.", true);
		d.addOption ("Go around the door.", 7);
		d.addOption ("The pixie who joined you goes through the door and then uses magic to get you through", 8);

		ChallengeTemplate e = new ChallengeTemplate (5, "You encounter a unicorn. Some members of your team are very vocal about their distrust for unicorns and threaten to leave your group if you allow the unicorn to join..", false);
		e.addOption ("Accept the unicorn into your group", 9);
		e.addOption ("Deny the unicorn entrance.", 10);
	

	



		//ADD CHALLENGES TO CHALLENGE LIST
		challenges.Add (a);
		challenges.Add (b);
		challenges.Add (c);
		challenges.Add (d);
		challenges.Add (e);





		/*ChallengeTemplate f = new ChallengeTemplate (6, "You pass by three elves and a pixie. As you get closer, you notice that the elves are teasing the pixie. Elves and pixies have never gotten along.");
		ChallengeTemplate g = new ChallengeTemplate (7, "You encounter a group of werewolves blocking the path. The werewolves refuse to let you through because you are an elf and they do not like elves.");
		ChallengeTemplate h = new ChallengeTemplate (8, "You meet a wizard on the path. He demands that you solve a riddle to get past him. He says you can either complete one riddle by yourself to get past him or you can work as a group, but will need to solve three riddles.");
		ChallengeTemplate i = new ChallengeTemplate (9, "You encounter an ogre in the middle of the forest, stuck under a fallen tree. Ogres are known for being large, vicious creatures who attack anybody in their way. You don’t know if this ogre is necessarily violent, but that’s how the stereotype goes. ");
		ChallengeTemplate j = new ChallengeTemplate (10, "You encounter a fairy who comes across as pleasant and sweet. You saw her take advantage of an ogre, but because ogres are typically seen as violent creatures, you assume she had no other choice. She asks to accompany you and claims she can cut through the maze (i.e., cheating).");
		ChallengeTemplate k = new ChallengeTemplate (11, "You come across a group of your fellow elves stealing food from a pixie.");
		ChallengeTemplate l = new ChallengeTemplate (12, "You find yourself lost and see a sign that points directions but it’s in dwarfish language and you can’t read it. You need to ask for help from a dwarf but you are reminded that someone told you they are lower on the social ladder and have the tendency to lie.");

		challenges.Add (f);
		challenges.Add (g);
		challenges.Add (h);
		challenges.Add (i);
		challenges.Add (j);
		challenges.Add (k);
		challenges.Add (l);
		*/
	}
}
