using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
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

    GUIManager guiManager;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start ()
    {
        Debug.LogWarning("endgame start");
        DontDestroyOnLoad(transform.root.gameObject);
        guiManager = GameObject.Find("Canvas").GetComponent<GUIManager>();
	}
    
	// Update is called once per frame
	void Update ()
    {

	}

	public void OnTriggerEnter(Collider other){
		Debug.Log ("hey");
		if (other.name == "player")
        {
            GameManager.pauseTime();
            other.GetComponent<Player>().canMove(false);
            BuildEndGameInfo();

            guiManager.OnEndGame();
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