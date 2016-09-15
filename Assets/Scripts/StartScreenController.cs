using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartScreenController : MonoBehaviour
{
    CanvasGroup startPanel;
    CanvasGroup optionsPanel;
    CanvasGroup instructionsPanel;

	// Use this for initialization
	void Start ()
    {
        startPanel = GameObject.Find("StartPanel").GetComponent<CanvasGroup>();
        optionsPanel = GameObject.Find("OptionsPanel").GetComponent<CanvasGroup>();
        instructionsPanel = GameObject.Find("InstructionsPanel").GetComponent<CanvasGroup>();

        SetPanelActive(optionsPanel, false);
        SetPanelActive(instructionsPanel, false);
        SetPanelActive(startPanel, true);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void SetPanelActive(CanvasGroup inTargetPanel, bool inIsActive)
    {
        if (inIsActive) inTargetPanel.alpha = 1f;
        else inTargetPanel.alpha = 0f;

        inTargetPanel.interactable = inIsActive;
        inTargetPanel.blocksRaycasts = inIsActive;
    }

    public void OnPressReturnButton()
    {
        SetPanelActive(optionsPanel, false);
        SetPanelActive(instructionsPanel, false);
        SetPanelActive(startPanel, true);
    }

    public void OnPressOptionsButton()
    {
        SetPanelActive(optionsPanel, true);
        SetPanelActive(startPanel, false);
    }

    public void OnPressInstructionsButton()
    {
        SetPanelActive(instructionsPanel, true);
        SetPanelActive(startPanel, false);
    }

    public void OnChangeVolume(Slider inSlider)
    {
        AudioManagerSingleton.GetInstance().SetGlobalVolume(inSlider.value);
    }
}