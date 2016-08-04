using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Maze mazePrefab;
	private Maze mazeInstance;

	public static int timer = 0;
	public int partTime = 0;
	public static bool gameStarted;
	public Text timeText;

	public Image textPanel;

	//player
	public Player playerPrefab;
	private Player playerInstance;

	private void Start () {
		Debug.Log ("Game MANAG my name is " + this.name);
		timeText = GameObject.Find ("Timer").GetComponent<Text>();
		timer = 0;
		partTime = 0;
		gameStarted = false;

		StartCoroutine(BeginGame());
		GUIManager.disablePanels ();
		//
		//textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		//textPanel.gameObject.SetActive (false);

	}
	private void Update () {
		if (Input.GetKeyDown(KeyCode.X)) {
			RestartGame();
		}
		if (gameStarted) {
			partTime += 1;
			if(partTime == 30){
				timer += 1;
				timeText.text = "Time: " + timer;
				partTime = 0;
			}
		}
	}

	public static void pauseTime(){
		gameStarted = false;
	}
	public static void continueTime(){
		gameStarted = true;
	}
	public static void changeTime(int increment){
		timer += increment;
	}
	private IEnumerator BeginGame () {
		Camera.main.clearFlags = CameraClearFlags.Skybox;
		Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate());
		playerInstance = Instantiate(playerPrefab) as Player;
		playerInstance.name = "player";
		//MazeCell temp = mazeInstance.GetCell (mazeInstance.RandomCoordinates);

		//temp = mazeInstance.GetCell (mazeInstance.RandomCoordinates);
		//Vector3 sLoc = new Vector3 (0.5f, 0.5f, 0.5f);
		Vector3 sLoc = new Vector3 (-(Maze.size.x-1)/2, 0.5f, -(Maze.size.z-1)/2);
		//Vector3 sLoc = new Vector3 (-2f, 0f, -2f);
		//Debug.Log (-(mazeInstance.size.x - 1) + " and " + -(mazeInstance.size.z-1));
		playerInstance.SetLocation(sLoc);
		//playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
		//Camera.main.enabled = false;
		Camera.main.clearFlags = CameraClearFlags.Depth;
		Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
		gameStarted = true;
	}
	
	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);
		}
		StartCoroutine(BeginGame());
	}

	public void setGameStarted(bool s){
		gameStarted = s;
	}
	public static int getTime(){
		return timer;
	}
}