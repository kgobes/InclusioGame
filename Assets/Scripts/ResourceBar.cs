using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceBar : MonoBehaviour {
	public static Image resource1;
	public static Image resource2;
	public static Image resource3;
	public static string r1;
	public static string r2;
	public static string r3;


	//resource options
	public static Sprite temp;

	//Health
	public static Text healthText;
	public static int health;

	// Use this for initialization
	void Start () {
		resource1 = GameObject.Find ("Resource1").GetComponent <Image>();
		resource2 = GameObject.Find ("Resource2").GetComponent <Image>();
		resource3 = GameObject.Find ("Resource3").GetComponent <Image>();
		/*resource1.gameObject.SetActive (false); //use .enabled if this doesn't work
		resource2.gameObject.SetActive (false);
		resource3.gameObject.SetActive (false);*/
		r1 = "";
		r2 = "";
		r3 = "";

		healthText = GameObject.Find ("Health").GetComponent <Text>();
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static bool addResource(string imgName){
		if (r1.Equals ("")) {
			r1 = imgName;
			temp = Resources.Load <Sprite>(imgName);
			if(temp)
				resource1.sprite = temp;
			else
				Debug.LogError ("Sprite not found");

			resource1.gameObject.SetActive (true);
			return true;
		} else if (r2.Equals ("")) {
			r2 = imgName;
			if(temp)
				resource2.sprite = temp;
			else
				Debug.LogError ("Sprite not found");
			resource2.gameObject.SetActive (true);
			return true;
		} else if (r3.Equals ("")) {
			r3 = imgName;
			if(temp)
				resource3.sprite = temp;
			else
				Debug.LogError ("Sprite not found");
			resource3.gameObject.SetActive (true);
			return true;
		} else
			return false;
	}
	public static bool useResource(string imgName){
		if (r1.Equals (imgName)) {
			resource1.gameObject.SetActive (false);
			r1 = "";
			return true;
		}
		else if (r2.Equals (imgName)) {
			resource2.gameObject.SetActive (false);
			r2 = "";
			return true;
		}
		else if (r3.Equals (imgName)) {
			resource3.gameObject.SetActive (false);
			r3 = "";
			return true;
		} else
			return false;
	}
	public static bool checkResource(string imgName){
		if (r1.Equals (imgName) || r2.Equals (imgName) || r3.Equals (imgName))
			return true;
		else
			return false;
	}

	public static void incrementHealth(int inc){
		health += inc;
		healthText.text = "Health: " + health;
	}


}
