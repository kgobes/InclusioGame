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
		timeText = GameObject.Find ("Timer").GetComponent<Text>();
		timer = 0;
		partTime = 0;
		gameStarted = false;
		StartCoroutine(BeginGame());
		textPanel = GameObject.Find ("TextPanel").GetComponent <Image>();
		textPanel.gameObject.SetActive (false);
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
	private IEnumerator BeginGame () {
		Camera.main.clearFlags = CameraClearFlags.Skybox;
		Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate());
		playerInstance = Instantiate(playerPrefab) as Player;
		playerInstance.name = "player";
		//MazeCell temp = mazeInstance.GetCell (mazeInstance.RandomCoordinates);

		//temp = mazeInstance.GetCell (mazeInstance.RandomCoordinates);
		Vector3 sLoc = new Vector3 (0.5f, 0.5f, 0.5f);
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