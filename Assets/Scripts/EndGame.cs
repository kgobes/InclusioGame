using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public struct EndGameInfo
{
    public int time;
    public float health;
    public List<EndItemInfo> items;
    public List<EndItemInfo> survivedCharacters;
}

public class EndGame : MazeCell
{
    private EndGameInfo info;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start ()
    {
        Debug.LogWarning("endgame start");
        DontDestroyOnLoad(transform.root.gameObject);
	}
    // timeText.text = (getTime() / 60).ToString("00") + ":" + (getTime() % 60).ToString("00");
	// Update is called once per frame
	void Update ()
    {

	}

	public void OnTriggerEnter(Collider other){
		Debug.Log ("hey");
		if (other.name == "player")
        {
            GameManager.pauseTime();
            BuildEndGameInfo();

			Application.LoadLevel ("EndScene");

		}
	}

    void BuildEndGameInfo()
    {
        info.time = GameManager.getTime();
        info.health = ResourceBar.health;
        info.survivedCharacters = GameManager.GetSurvivedCharactersList();
    }

    public EndGameInfo GetEndGameInfo() { return info; }
}