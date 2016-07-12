using UnityEngine;

public class Player : MonoBehaviour {
	
	private MazeCell currentCell;
	private MazeDirection currentDirection;
	
	private void Rotate (MazeDirection direction) {
		transform.localRotation = direction.ToRotation();
		currentDirection = direction;
	}
	
	public void SetLocation (MazeCell cell) {
		//if (cell is MazePassage) {
			//Debug.Log ("In set location maze passage");
			currentCell = cell;
			transform.localPosition = cell.transform.localPosition;
		//}
	}
	
	private void Move (MazeDirection direction) {
		MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage) {
			SetLocation(edge.otherCell);
		}
	}
	
	private void Update () {//Q and E for rotate, WASD for moving
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			Move (currentDirection);
		} else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			Move (currentDirection.GetNextClockwise ());
		} else if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			Move (currentDirection.GetOpposite ());
		} else if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			Move (currentDirection.GetNextCounterclockwise ());
		} else if (Input.GetKeyDown (KeyCode.Q)) {
			Rotate(currentDirection.GetNextCounterclockwise ());
		} else if (Input.GetKeyDown (KeyCode.E)) {
			Rotate(currentDirection.GetNextClockwise ());
		}
	} 

	void onTriggerEnter(Collider other){
		Debug.Log ("In on trigger enter for player");
		if (other.name == "Maze End") {
			Debug.Log ("In end game! Yay!");
		}
	}









}