using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScreenController : MonoBehaviour
{
    EndGameInfo info;

    public Text timeText;
    public Text healthText;
    public RectTransform itemsPanel;
    public RectTransform survivedPanel;

	// Use this for initialization
	void Start ()
    {
        GetEndGameInfo();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void GetEndGameInfo()
    {
        EndGame _endObject = GameObject.Find("Maze End").GetComponent<EndGame>();
        info = _endObject.GetEndGameInfo();
        Destroy(_endObject.gameObject);

        timeText.text = info.time.ToString();
    }

    public void OnPressContinue()
    {
        Application.LoadLevel("StartScreen");
    }
}