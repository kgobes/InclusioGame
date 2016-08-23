using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class GUIManager : MonoBehaviour
{
    Text eventText;
    Image eventImage;
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
    CanvasGroup instructionsPanel;
    CanvasGroup navPanel;

    GameManager gameManager;

	// Use this for initialization

    void Awake()
    {
        inGameUI = GameObject.Find("InGameUIPanel").GetComponent<CanvasGroup>();
        pauseMenu = GameObject.Find("PausePanel").GetComponent<CanvasGroup>();
        pauseButton = GameObject.Find("Pause Button").GetComponent<CanvasGroup>();
        instructionsPanel = GameObject.Find("InstructionsPanel").GetComponent<CanvasGroup>();
        navPanel = GameObject.Find("NavPanel").GetComponent<CanvasGroup>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        eventText = GameObject.Find("EventText").GetComponent<Text>();
        eventImage = GameObject.Find("EventImage").GetComponent<Image>();
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

        HideAllUI();
        
        SetPauseButtonVisibility(false);
        disablePanels();
	}

    void HideAllUI()
    {
        inGameUI.interactable = false;
        pauseMenu.interactable = false;
        instructionsPanel.interactable = false;

        inGameUI.blocksRaycasts = false;
        pauseMenu.blocksRaycasts = false;
        instructionsPanel.blocksRaycasts = false;

        inGameUI.alpha = 0;
        pauseMenu.alpha = 0;
        instructionsPanel.alpha = 0;
    }

	// Update is called once per frame
	void Update () {
		//resultPanel.gameObject.SetActive(false);
		//textPanel.gameObject.SetActive (false);
	}
	public void disablePanels()
    {
        HideEventUI();
        HideResultUI();
	}

    public void DisplayEventUI(string inStoryText, List<Option> inOptionList, Sprite inImage)   // with image
    {        
        eventUIActive = true;

        if(!inImage)
        {
            Debug.Log("no image");
            eventText.rectTransform.offsetMax = new Vector2(eventText.rectTransform.offsetMax.x, -10);

            eventImage.sprite = null;
            eventImage.color = new Color32(255, 255, 255, 0);
        }
        else
        {
            Debug.Log("has image");
            eventText.rectTransform.offsetMax = new Vector2(eventText.rectTransform.offsetMax.x, -150);

            eventImage.sprite = inImage;
            eventImage.color = new Color32(255, 255, 255, 255);
       }

        CanvasGroup _textPanelGroup = textPanel.GetComponent<CanvasGroup>();
        _textPanelGroup.alpha = 1f;
        _textPanelGroup.interactable = true;
        _textPanelGroup.blocksRaycasts = true;

        navPanel.alpha = 0f;
        navPanel.interactable = false;
        navPanel.blocksRaycasts = false;

        displayText(inStoryText);
        displayOptions(inOptionList);
        StartCoroutine(FadeInEventUI());
    }

    void HideEventUI()
    {
        CanvasGroup _textPanelGroup = textPanel.GetComponent<CanvasGroup>();
        _textPanelGroup.alpha = 0f;
        _textPanelGroup.interactable = false;
        _textPanelGroup.blocksRaycasts = false;
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
	public void displayText(string text)
    {
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
        HideEventUI();
	}
	public void clickOption2(){

        optObject2.executeResult(resourceBar);
        HideEventUI();
	}
	public void clickOption3(){

        optObject3.executeResult(resourceBar);
        HideEventUI();
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
        StartCoroutine(FadeResultUI());
        Debug.Log("Click Continue!");
	}

    void HideResultUI()
    {
        CanvasGroup _resultPanelGroup = resultPanel.GetComponent<CanvasGroup>();
        _resultPanelGroup.alpha = 0f;
        _resultPanelGroup.interactable = false;
        _resultPanelGroup.blocksRaycasts = false;

        navPanel.alpha = 1f;
        navPanel.interactable = true;
        navPanel.blocksRaycasts = true;
    }

    IEnumerator FadeResultUI()
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

        HideResultUI();


        if(!playerRef) playerRef = GameObject.Find("player").GetComponent<Player>();
        playerRef.canMove(true);
        GameManager.continueTime();

        eventUIActive = false;

        StopCoroutine(FadeResultUI());
    }

	public void showResult(string resultText){

        CanvasGroup _resultPanelGroup = resultPanel.GetComponent<CanvasGroup>();
        _resultPanelGroup.alpha = 1f;
        _resultPanelGroup.interactable = true;
        _resultPanelGroup.blocksRaycasts = true;

        resultPanel.canvasRenderer.SetAlpha(1f);
        foreach (Transform _child in resultPanel.transform)
        {
            _child.GetComponent<CanvasRenderer>().SetAlpha(1f);
        }

		resText.text = resultText;
	}

    public bool GetEventUIActive() { return eventUIActive; }

    public void DisplayPauseMenu()
    {
        inGameUI.interactable = false;
        pauseMenu.interactable = true;
        instructionsPanel.interactable = false;

        inGameUI.blocksRaycasts = false;
        pauseMenu.blocksRaycasts = true;
        instructionsPanel.blocksRaycasts = false;

        inGameUI.alpha = 0;
        pauseMenu.alpha = 1;
        instructionsPanel.alpha = 0;
    }

    public void DisplayGameUI()
    {
        inGameUI.interactable = true;
        pauseMenu.interactable = false;
        instructionsPanel.interactable = false;

        inGameUI.blocksRaycasts = true;
        pauseMenu.blocksRaycasts = false;
        instructionsPanel.blocksRaycasts = false;

        inGameUI.alpha = 1;
        pauseMenu.alpha = 0;
        instructionsPanel.alpha = 0;
    }

    public void DisplayInstructionsMenu()
    {
        inGameUI.interactable = false;
        pauseMenu.interactable = false;
        instructionsPanel.interactable = true;

        inGameUI.blocksRaycasts = false;
        pauseMenu.blocksRaycasts = false;
        instructionsPanel.blocksRaycasts = true;

        inGameUI.alpha = 0;
        pauseMenu.alpha = 0;
        instructionsPanel.alpha = 1;
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

    public void OnPressInstructionsButton()
    {
        DisplayInstructionsMenu();
    }

    public void OnPressReturnToPauseButton()
    {
        DisplayPauseMenu();
    }

    public void OnPressReturnToMenuButton()
    {
        StopAllCoroutines();
        Application.LoadLevel(1);
    }

    public void OnMouseDownMoveButton()
    {
        if (!playerRef) playerRef = GameObject.Find("player").GetComponent<Player>();
        playerRef.SetDeltaMoveInput(true);
    }

    public void OnMouseUpMoveButton()
    {
        if (!playerRef) playerRef = GameObject.Find("player").GetComponent<Player>();
        playerRef.SetDeltaMoveInput(false);
    }

    public void OnPressTurnLeft()
    {
        if (!playerRef) playerRef = GameObject.Find("player").GetComponent<Player>();
        playerRef.TurnLeft();
    }

    public void OnPressTurnRight()
    {
        if (!playerRef) playerRef = GameObject.Find("player").GetComponent<Player>();
        playerRef.TurnRight();
    }
}