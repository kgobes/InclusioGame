using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

	public static Text eventText;
	public static Image textPanel;
	public static Button opt1;
	public static Button opt2;
	public static Button opt3;

	public static Option optObject1;
	public static Option optObject2;
	public static Option optObject3;


	public static Text resText;
	public static Image resultPanel;
	public static Button cont;
	/*
	public Text eventText;
	public Image textPanel;
	public Button opt1;
	public Button opt2;
	public Button opt3;
	
	public Option optObject1;
	public Option optObject2;
	public Option optObject3;
	
	
	public Text resText;
	public Image resultPanel;
	public Button cont;*/

    private static Player playerRef;

    public ResourceBar resourceBar;

	// Use this for initialization
	void Start () {

		Debug.Log ("GUI MANAG my name is " + this.name);

		eventText = GameObject.Find ("EventText").GetComponent<Text>();
		textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		opt1 = GameObject.Find ("Option Button 1").GetComponent <Button>();
        opt2 = GameObject.Find("Option Button 2").GetComponent<Button>();
        opt3 = GameObject.Find("Option Button 3").GetComponent<Button>();

	
		/*eventText.enabled = false;
		opt1.enabled = false;
		opt2.enabled = false;
		opt3.enabled = false;*/


		resultPanel = GameObject.Find ("ResultPanel").GetComponent <Image> ();
		resText = GameObject.Find ("ResultText").GetComponent<Text>();
		cont = GameObject.Find ("Continue Button").GetComponent <Button>();
		//resultPanel.gameObject.SetActive(false);
		//textPanel.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		//resultPanel.gameObject.SetActive(false);
		//textPanel.gameObject.SetActive (false);
	}
	public static void disablePanels(){
		resultPanel.gameObject.SetActive(false);
		textPanel.gameObject.SetActive (false);
		//resultPanel.enabled = false;
		//textPanel.enabled = false;
	}

    public void DisplayEventUI(string inStoryText, List <Option> inOptionList)
    {
        displayText(inStoryText);
        displayOptions(inOptionList);

        

        StartCoroutine(FadeInEventUI());
    }

    IEnumerator FadeInEventUI()
    {
        textPanel.canvasRenderer.SetAlpha(0f);
        foreach (Transform _child in textPanel.transform)
        {
            _child.GetComponent<CanvasRenderer>().SetAlpha(0f);
        }

        textPanel.CrossFadeAlpha(1f, 1f, false);
        textPanel.transform.GetChild(0).GetComponent<Graphic>().CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(1f);

        foreach(Transform _child in textPanel.transform)
        {
            _child.GetComponent<Graphic>().CrossFadeAlpha(1f, 1f, false);
        }

        StopCoroutine(FadeInEventUI());
    }

	//public static Rect windowRect = new Rect(20, 20, 120, 50);
	public void displayText(string text){
		textPanel.gameObject.SetActive (true);
		eventText.text = text;
	}
	public void displayOptions(List<Option> optionList){
		if (optionList.Count == 2) {
			opt1.gameObject.SetActive (true);
			opt2.gameObject.SetActive (true);
			opt3.gameObject.SetActive (false);
			opt1.GetComponentInChildren<Text>().text = optionList[0].getButtonText();
			opt2.GetComponentInChildren<Text>().text = optionList[1].getButtonText();
			optObject1 = optionList[0];
			optObject2 = optionList[1];
		}
		else if (optionList.Count == 3) {
			opt1.gameObject.SetActive (true);
			opt2.gameObject.SetActive (true);
			opt3.gameObject.SetActive (true);
			opt1.GetComponentInChildren<Text>().text = optionList[0].getButtonText();
			opt2.GetComponentInChildren<Text>().text = optionList[1].getButtonText();
			opt3.GetComponentInChildren<Text>().text = optionList[2].getButtonText();
			optObject1 = optionList[0];
			optObject2 = optionList[1];
			optObject3 = optionList[2];

		}

	}
	public void clickOption1(){

		optObject1.executeResult(resourceBar);
		textPanel.gameObject.SetActive (false);
	}
	public void clickOption2(){

        optObject2.executeResult(resourceBar);
		textPanel.gameObject.SetActive (false);
	}
	public void clickOption3(){

        optObject3.executeResult(resourceBar);
		textPanel.gameObject.SetActive (false);
	}
	/*public void clickContinue(){
		Player p = GameObject.Find ("player").GetComponent<Player>();
		p.canMove (true);
		textPanel.gameObject.SetActive (false);
		GameManager.continueTime ();
		//p.canMove (true);
	}*/

	public void clickContinue()
    {
        StartCoroutine(HideResultUI());
        Debug.Log("Click Continue!");
	}

    IEnumerator HideResultUI()
    {
        resultPanel.canvasRenderer.SetAlpha(1f);
        foreach (Transform _child in resultPanel.transform)
        {
            _child.GetComponent<CanvasRenderer>().SetAlpha(1f);
        }

        resultPanel.CrossFadeAlpha(0f, 1f, false);

        foreach (Transform _child in resultPanel.transform)
        {
            _child.GetComponent<Graphic>().CrossFadeAlpha(0f, 1f, false);
        }

        yield return new WaitForSeconds(1f);

        resultPanel.gameObject.SetActive(false);
        playerRef = GameObject.Find("player").GetComponent<Player>();
        playerRef.canMove(true);
        GameManager.continueTime();

        StopCoroutine(HideResultUI());
    }

	public void showResult(string resultText){

		resultPanel.gameObject.SetActive (true);
		resText.text = resultText;
	}
}
