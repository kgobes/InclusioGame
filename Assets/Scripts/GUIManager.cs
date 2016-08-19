using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour
{
    Text eventText;
    Image textPanel;
    Button opt1;
    Button opt2;
    Button opt3;

    Option optObject1;
    Option optObject2;
    Option optObject3;

    Text resText;
    Image resultPanel;

    private static Player playerRef;

    public ResourceBar resourceBar;

    bool eventUIActive;

    CanvasGroup inGameUI;
    CanvasGroup pauseMenu;
    CanvasGroup pauseButton;

    GameManager gameManager;

	// Use this for initialization

    void Awake()
    {
        inGameUI = GameObject.Find("InGameUIPanel").GetComponent<CanvasGroup>();
        pauseMenu = GameObject.Find("PausePanel").GetComponent<CanvasGroup>();
        pauseButton = GameObject.Find("Pause Button").GetComponent<CanvasGroup>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        eventText = GameObject.Find("EventText").GetComponent<Text>();
        textPanel = GameObject.Find("TextPanel").GetComponent<Image>();
        opt1 = GameObject.Find("Option Button 1").GetComponent<Button>();
        opt2 = GameObject.Find("Option Button 2").GetComponent<Button>();
        opt3 = GameObject.Find("Option Button 3").GetComponent<Button>();

        resultPanel = GameObject.Find("ResultPanel").GetComponent<Image>();
        resText = GameObject.Find("ResultText").GetComponent<Text>();
    }

	void Start ()
    {
		Debug.Log ("GUI MANAG my name is " + this.name);

        DisplayGameUI();
        SetPauseButtonVisibility(false);
	}
	
	// Update is called once per frame
	void Update () {
		//resultPanel.gameObject.SetActive(false);
		//textPanel.gameObject.SetActive (false);
	}
	public void disablePanels(){
		resultPanel.gameObject.SetActive(false);
		textPanel.gameObject.SetActive (false);
		//resultPanel.enabled = false;
		//textPanel.enabled = false;
	}

    public void DisplayEventUI(string inStoryText, List <Option> inOptionList)
    {
        eventUIActive = true;

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

        eventUIActive = false;

        StopCoroutine(HideResultUI());
    }

	public void showResult(string resultText){

		resultPanel.gameObject.SetActive (true);
		resText.text = resultText;
	}

    public bool GetEventUIActive() { return eventUIActive; }

    public void DisplayPauseMenu()
    {
        inGameUI.interactable = false;
        pauseMenu.interactable = true;

        inGameUI.blocksRaycasts = false;
        pauseMenu.blocksRaycasts = true;

        inGameUI.alpha = 0;
        pauseMenu.alpha = 1;        
    }

    public void DisplayGameUI()
    {
        inGameUI.interactable = true;
        pauseMenu.interactable = false;

        inGameUI.blocksRaycasts = true;
        pauseMenu.blocksRaycasts = false;

        inGameUI.alpha = 1;
        pauseMenu.alpha = 0;  
    }

    public void SetPauseButtonVisibility(bool inIsVisible)
    {
        if (inIsVisible) pauseButton.alpha = 1;
        else pauseButton.alpha = 0;
    }

    public void OnPressPauseButton()
    {
        gameManager.PauseGame();
    }

    public void OnPressPlayButton()
    {
        gameManager.UnPauseGame();
    }

    public void OnPressReturnToMenuButton()
    {
        StopAllCoroutines();
        Application.LoadLevel(1);
    }
}