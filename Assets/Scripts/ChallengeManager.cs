using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChallengeManager : MonoBehaviour {
	//public Challenge chal;
	//public Transform hinge;
	//public Text eventText;
	//public Image textPanel;
	public int numOfChal = 3;
	public static int next = -1;
	public static List<ChallengeTemplate> challenges = new List<ChallengeTemplate>();
	public static ChallengeTemplate current;

    private GUIManager GUIManagerInst;

	// Use this for initialization
	void Start () {
		/*eventText = GameObject.Find ("EventText").GetComponent<Text>();
		textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		textPanel.gameObject.SetActive (false);*/

        GUIManagerInst = GameObject.Find("TextPanel").GetComponent<GUIManager>();

        if (!GUIManagerInst)
            Debug.LogError("GUI Manager/TextPanel object not found in scene! Unable to store reference");

		checkPosition ();

		initializeChallenges ();
		Debug.Log ("In CM start");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void setNext(int n){
		next = n;
		Debug.Log ("next set to " + next);
	}
	void checkPosition(){
		Vector3 sLoc = new Vector3 (-(Maze.size.x-1)/2, 0.5f, -(Maze.size.z-1)/2);
		Vector3 endSpot = new Vector3 (Maze.size.x-1, 0, Maze.size.z-1);
		if ((transform.localPosition == sLoc) || (transform.localPosition == endSpot)) {
			Destroy (this.gameObject);
			Debug.Log ("event destroyed");
		}

	}
	public void chooseNextScen(){

		Debug.Log ("next scen is " + next);
		int num = 0;
		if (next == -1){
			num = Random.Range (0, challenges.Count);
			while (challenges[num].getDependent () == true) {
				num = Random.Range (0, challenges.Count);
			}
		}
		else{
			for(int  i = 0; i<challenges.Count; i++){
				if(next == challenges[i].getNumber ())
					num = i;
			}
			//num = next-1;
			next = -1;
		}
		Debug.Log ("num: " + num);
		current = challenges [num];
        GUIManagerInst.displayText(current.getStory());
		//gm.displayText(current.getStory ());
        GUIManagerInst.displayOptions(current.getOptionList());
		//gm.displayOptions (current.getOptionList ());
		challenges.Remove (current);

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
	

	
		
		ChallengeTemplate f = new ChallengeTemplate (6, "You pass a pot of gold sitting on the side of the road.", false);
		f.addOption ("Ignore the pot of gold. It isn’t yours and stealing is wrong.", 11);
		f.addOption ("Take the gold. Who is stupid enough to leave a pot of gold in the middle of the forest anyways?", 12);
		
		ChallengeTemplate g = new ChallengeTemplate (7, "You pass by three elves and a pixie. As you get closer, you notice that the elves are teasing the pixie. Elves and pixies have never gotten along.", false);
		g.addOption ("Join them! Laugh and throw rocks at the pixie.", 13);
		g.addOption ("Ignore it and keep walking.", 14);
		g.addOption ("Tell the elves to stop.", 15);
		
		//come back to this shit
		ChallengeTemplate h = new ChallengeTemplate (8, "You encounter a group of werewolves blocking the path. The werewolves refuse to let you through because you are an elf and they do not like elves.", false);
		h.addOption ("Consume a potion that changes you into a wolf.", 16);
		h.addOption ("Try to communicate with the werewolves and prove yourself as an elf.", 17);
		
		
		ChallengeTemplate i = new ChallengeTemplate (9, "You meet a wizard on the path. He demands that you solve a riddle to get past him. He says you can either complete one riddle by yourself to get past him or you can work as a group to solve three riddles.", false);
		i.addOption ("Choose to work by yourself and solve one riddle.", 19);
		i.addOption ("Work as a group.", 20);
		
		ChallengeTemplate j = new ChallengeTemplate (10, "You encounter an ogre stuck under a fallen tree. Ogres are known for being vicious creatures who attack anybody in their way. You don’t know if this ogre is necessarily violent, but that’s how the stereotype goes.", false);
		j.addOption ("Help the ogre - he turns out to be a nonviolent, pleasant being.", 21);
		j.addOption ("Don’t help the ogre and continue along your path.", 22);

		ChallengeTemplate k = new ChallengeTemplate(11, "You encounter a fairy who appears pleasant and sweet. You watched her manipulate an ogre into giving her food, but because ogres are typically viewed as violent creatures, you assume she had no other choice. She asks to accompany you and claims she knows secret shortcuts through the maze. ", false);
		k.addOption ("Let the fairy join you, you could use someone who is clever.", 23);
		k.addOption ("Call out the fairy for being a cheater and report her to the fairy chief.", 24);
	
		
		ChallengeTemplate l = new ChallengeTemplate (12, "You come across a group of your fellow elves stealing food from a pixie.", false);
		l.addOption ("Intervene and try stop the elves.", 25);
		l.addOption ("Ignore them and continue on your journey.", 26);
		l.addOption ("Join the elves and steal the food.", 27);

		ChallengeTemplate m = new ChallengeTemplate (13, " You find yourself lost and see a sign that points directions but it’s in dwarvish language and you can’t read it. You need to ask for help from a dwarf but you remember that someone told you that they have the tendency to lie.", false);
		m.addOption ("Suck it up and ask for help.", 28);
		m.addOption ("You think you have a good sense of direction and don’t want to waste your time getting potentially incorrect advice.", 29);
		

		
		
		//ADD CHALLENGES TO CHALLENGE LIST
		challenges.Add (a);
		challenges.Add (b);
		challenges.Add (c);
		challenges.Add (d);
		challenges.Add (e);

		challenges.Add (f);
		challenges.Add (g);
		challenges.Add (h);
		challenges.Add (i);
		challenges.Add (j);


	}
}
