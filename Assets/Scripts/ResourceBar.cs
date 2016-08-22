using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ResourceBar : MonoBehaviour {
	public Image resource1;
	public Image resource2;
	public Image resource3;
	public static string r1;
	public static string r2;
	public static string r3;

	//public Sprite pixie;
	//public Sprite potOfGold;


	//resource options
	//public Sprite temp;

	//Health
	public static Text healthText;
	public static float health;
    public Slider healthBar;
    float targetHealth;

	// Use this for initialization
	void Start ()
    {
		resource1 = GameObject.Find ("Resource1").GetComponent <Image>();
		resource2 = GameObject.Find ("Resource2").GetComponent <Image>();
		resource3 = GameObject.Find ("Resource3").GetComponent <Image>();
		//resource1.sprite = Resources.Load<Sprite> ("PotofGold");

		/*resource1.gameObject.SetActive (false); //use .enabled if this doesn't work
		resource2.gameObject.SetActive (false);
		resource3.gameObject.SetActive (false);*/
		r1 = "";
		r2 = "";
		r3 = "";

		healthText = GameObject.Find ("Health Text").GetComponent <Text>();
		health = 100;

        SetResourceBarVisibility(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.F10))
        {
            incrementHealth(-10f);
        }
	
	}

	public bool addResource(string imgName){
		Sprite temp = Resources.Load <Sprite> ("potOfGold");
		if (r1 == "") {
			r1 = imgName;
			//if (temp) {
				resource1.sprite = temp;
				Debug.Log ("Sprite should be set");
			//} else
			//	Debug.LogError ("Sprite " + r1 + " not found");

			resource1.gameObject.SetActive (true);
			return true;
		} else if (r2 =="") {
			r2 = imgName;
			//if (temp)
				resource2.sprite = temp;
			//else
			//	Debug.LogError ("Sprite not found");
			resource2.gameObject.SetActive (true);
			return true;
		} else if (r3 == "") {
			r3 = imgName;
			//if (temp)
				resource3.sprite = temp;
			//else
			//	Debug.LogError ("Sprite not found");
			resource3.gameObject.SetActive (true);
			return true;
		} else {
			Debug.Log ("No avail resource");
			return false;
		}
	}
	public bool useResource(string imgName){
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
	public bool checkResource(string imgName){
		if (r1.Equals (imgName) || r2.Equals (imgName) || r3.Equals (imgName))
			return true;
		else
			return false;
	}

	public void incrementHealth(float inc){
        targetHealth = health + inc;
        healthBar.GetComponent<Animator>().SetTrigger("startflash");
        StartCoroutine(HealthBarSlideEffect());
	}

    IEnumerator HealthBarSlideEffect()
    {
        Debug.Log("Target Health: " + targetHealth);

        if(health > targetHealth)
        {
            while (health > targetHealth)
            {
                yield return new WaitForEndOfFrame();
                health -= 0.2f;
                healthBar.value = health;
                healthText.text = "Health: " + (int)health;
                
            }
        }
        else
        {
            while (health < targetHealth)
            {
                yield return new WaitForEndOfFrame();
                health += 0.2f;
                healthBar.value = health;
                healthText.text = "Health: " + (int)health;
                
            }
        }

        health = targetHealth;
        healthText.text = "Health: " + (int)health;

        healthBar.GetComponent<Animator>().SetTrigger("stopflash");

        StopCoroutine(HealthBarSlideEffect());
    }

    public void SetResourceBarVisibility(bool inIsVisible)
    {
        if (inIsVisible) GetComponent<CanvasGroup>().alpha = 1;
        else GetComponent<CanvasGroup>().alpha = 0;
    }


}