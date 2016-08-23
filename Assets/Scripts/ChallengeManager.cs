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
	public static bool correct = false;

    private GUIManager GUIManagerInst;

	// Use this for initialization
	void Start () {
		/*eventText = GameObject.Find ("EventText").GetComponent<Text>();
		textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		textPanel.gameObject.SetActive (false);*/

        GUIManagerInst = GameObject.Find("Canvas").GetComponent<GUIManager>();

        if (!GUIManagerInst)
            Debug.LogError("GUI Manager/TextPanel object not found in scene! Unable to store reference");

		checkPosition ();

		initializeChallenges ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void setNext(int n){
		next = n;
		Debug.Log ("next set to " + next);
	}
	public static bool getCorrect(){
		return correct;
	}
	public static void setCorrect (bool b){
		correct = b;
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
        GUIManagerInst.DisplayEventUI(current.getStory(), current.getOptionList(), current.GetImage());
		challenges.Remove (current);

	}
	void initializeChallenges(){
		//create array of challengeTemplates
		ChallengeTemplate a = new ChallengeTemplate(1, " You encounter a blind troll being attacked by other elves. It calls out for help. Do you help defend him from your own kind or join the other elves in attacking the troll because you heard trolls love to eat elves?",false);
		a.addOption ("Defend the troll and go against your own people.",1);
		a.addOption ("Join in with the other elves attacking the troll",2);
        a.SetImage(Resources.Load<Sprite>("sprites/spr_troll"));

		ChallengeTemplate b = new ChallengeTemplate(2, "A group of trolls is blocking the entrance to a gate.", true);
		b.addOption ("Ask your troll teammate to ask the trolls to allow you to pass.", 3);
		b.addOption ("Use hand gestures to try to communicate.", 4);
        b.SetImage(Resources.Load<Sprite>("sprites/spr_troll"));

		ChallengeTemplate c = new ChallengeTemplate (3, "You come across a pixie on your path. Pixies are notoriously untrustworthy and you’ve had experiences with them tricking you in the past. This pixie is asking for help to heal his torn wing, but helping him involves losing a little of your own health.", false);
		c.addOption ("Agree to help the pixie.", 5);
		c.addOption ("Refuse to help the pixie and continue on with your adventure.", 6);
        c.SetImage(Resources.Load<Sprite>("sprites/spr_pixie"));

		ChallengeTemplate d = new ChallengeTemplate (4, "There’s a door in your path and you can’t fit through it.", true);
		d.addOption ("Go around the door.", 7);
		d.addOption ("The pixie who joined you goes through the door and then uses magic to get you through", 8);

		/*ChallengeTemplate e = new ChallengeTemplate (5, "You encounter a unicorn who asks if he can join you on your way.. Some members of your team are very vocal about their distrust for unicorns", false);
		e.addOption ("Accept the unicorn into your group", 9);
		e.addOption ("Deny the unicorn entrance.", 10);*/
	

	
		
		ChallengeTemplate f = new ChallengeTemplate (6, "You pass a pot of gold sitting on the side of the road.", false);
		f.addOption ("Ignore the pot of gold. It isn’t yours and stealing is wrong.", 11);
		f.addOption ("Take the gold. Who is stupid enough to leave a pot of gold in the middle of the forest anyways?", 12);
        f.SetImage(Resources.Load<Sprite>("sprites/potofgold"));
		
		ChallengeTemplate g = new ChallengeTemplate (7, "You pass by three elves and a pixie. As you get closer, you notice that the elves are teasing the pixie. Elves and pixies have never gotten along.", false);
		g.addOption ("Join them! Laugh and throw rocks at the pixie.", 13);
		g.addOption ("Ignore it and keep walking.", 14);
		g.addOption ("Tell the elves to stop.", 15);
		
		//come back to this shit
		ChallengeTemplate h = new ChallengeTemplate (8, "You encounter a group of werewolves blocking the path. The werewolves refuse to let you through because you are an elf and they do not like elves.", false);
		h.addOption ("Consume a potion that changes you into a wolf.", 16);
		h.addOption ("Try to communicate with the werewolves and prove yourself as an elf.", 17);
		
		
		//ChallengeTemplate i = new ChallengeTemplate (9, "You meet a wizard on the path. He demands that you solve a riddle to get past him. He says you can either complete one riddle by yourself to get past him or you can work as a group to solve three riddles.", false);
		//i.addOption ("Choose to work by yourself and solve one riddle.", 19);
		//i.addOption ("Work as a group.", 20);
		
		ChallengeTemplate j = new ChallengeTemplate (10, "You encounter an ogre stuck under a fallen tree. Ogres are known for being vicious creatures who attack anybody in their way. You don’t know if this ogre is necessarily violent, but that’s how the stereotype goes.", false);
		j.addOption ("Help the ogre - he could be a pleasant fellow.", 21);
		j.addOption ("Too risky...continue down the path.", 22);

		ChallengeTemplate k = new ChallengeTemplate(11, "You see a fairy who appears pleasant and sweet. As you approach, you watch her manipulate an ogre into giving her food, but because ogres are typically violent creatures, maybe she had no other choice. She asks to accompany you and claims she knows secret shortcuts through the maze. ", false);
		k.addOption ("Let the fairy join you, you could use someone who is clever.", 23);
		k.addOption ("Call out the fairy for being a cheater and report her to the fairy chief.", 24);
	
		
		ChallengeTemplate l = new ChallengeTemplate (12, "You come across a group of your fellow elves stealing food from a pixie.", false);
		l.addOption ("Intervene and try stop the elves.", 25);
		l.addOption ("Ignore them and continue on your journey.", 26);
		l.addOption ("Join the elves and steal the food.", 27);

		ChallengeTemplate m = new ChallengeTemplate (13, " You find yourself lost and see a sign that points directions but it’s in dwarvish language and you can’t read it. You need to ask for help from a dwarf but you remember that someone told you that they have the tendency to lie.", false);
		m.addOption ("Ask for help, it's worth a try.", 28);
		m.addOption ("You think you have a good sense of direction and don’t want to waste your time getting potentially incorrect advice.", 29);
		
		ChallengeTemplate n = new ChallengeTemplate (14, " A giant stops you to ask for directions. You are much smaller than she is and have heard rumors that giants are thieves. You are scared and want to quickly continue on your journey.", false);
		n.addOption ("Take the time to help the giant find her way regardless.", 30);
		n.addOption ("Mumble a white lie about not being sure where you are anyway, and hurry on your way.", 31);

		ChallengeTemplate o = new ChallengeTemplate(15, "A group of elves is singing about their fairy godmother. They ask you to join in their singing, but you don’t believe in fairy godmothers...although it does look like they are having fun", false);
		o.addOption ("Ask questions to learn more.", 32);
		o.addOption("Ignore them and keep going... no time for fun right now.", 33);

		ChallengeTemplate p = new ChallengeTemplate(16, "There is a gate ahead with a lock on it. What is the password?", true);
		p.addOption ("You know this! It’s the secret to life from the singing elves!", 34);
		p.addOption ("A gate is no match for you! You break down the gate using force.", 35);
		p.addOption (" Oh no! You realize you should have talked with the singing elves. You go back to find them.", 36);

		ChallengeTemplate q = new ChallengeTemplate(19, "You spot an old woman struggling on the ground. You recognize her immediately as the evil witch from another story. As you get closer, she says she fell and can’t get back up. She asks for your help.", false);
		q.addOption ("Keep going down the path. She doesn’t sound trustworthy.", 37);
		q.addOption ("Help her up, maybe the rumors aren't true.", 38);

		ChallengeTemplate r = new ChallengeTemplate(21, "You are so busy texting your mom that you don’t notice a tree in the path.", false);
		r.addOption ("You run straight into it. Ow.", 39);
		r.addOption ("Trip over the roots and slam into the groud. Embarrassing.", 40);

		ChallengeTemplate s = new ChallengeTemplate (24, "You encounter another character wearing a necklace with a pendant representing the era of oppression of elves. The character argues that it is a symbol of pride amongst his people and it makes him feel close to home on this long and treacherous journey. What do you do?", false);
		s.addOption ("Tell him that the pendant is offensive and ask him to throw it into the forest.", 41);
		s.addOption ("Ask the character to keep the pendant hidden where no one can see it.", 42);
		s.addOption ("Tell the character to continue wearing the pendant.", 43);

		ChallengeTemplate t = new ChallengeTemplate (23, "You discover a natural hot spring.", false);
		t.addOption ("Jump in!", 44);
		t.addOption ("No time for hanging around.", 45);

		
		//ADD CHALLENGES TO CHALLENGE LIST
		challenges.Add (a);
		challenges.Add (b);
		challenges.Add (c);
		challenges.Add (d);
		//challenges.Add (e);

		challenges.Add (f);
		challenges.Add (g);
		challenges.Add (h);
		//challenges.Add (i);
		challenges.Add (j);

		challenges.Add (k);
		challenges.Add (l);
		challenges.Add (m);
		challenges.Add (n);
		challenges.Add (o);
		challenges.Add (p);
		challenges.Add (q);
		challenges.Add (r);


	}
}
