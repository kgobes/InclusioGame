using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Maze mazePrefab;
	private Maze mazeInstance;

	//player
	public Player playerPrefab;
	private Player playerInstance;

	private void Start () {
		StartCoroutine(BeginGame());
	}
	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}
	
	private IEnumerator BeginGame () {
		Camera.main.clearFlags = CameraClearFlags.Skybox;
		Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate());
		playerInstance = Instantiate(playerPrefab) as Player;
		MazeCell temp = mazeInstance.GetCell (mazeInstance.RandomCoordinates);
		Debug.Log (temp);
		string name = temp.name;
		//while (temp is Maze) {
		Debug.Log ("name: "+ name);

		while(name.Contains ("MazeWall")){
			Debug.Log ("it was a darn wall");
			temp = mazeInstance.GetCell (mazeInstance.RandomCoordinates);
		}
		playerInstance.SetLocation(temp);
		//playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
		Camera.main.enabled = false;
	//	Camera.main.clearFlags = CameraClearFlags.Depth;
	//	Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
	}
	
	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);
		}
		StartCoroutine(BeginGame());
	}
}