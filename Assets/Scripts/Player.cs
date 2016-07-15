using UnityEngine;

public class Player : MonoBehaviour {
	
	private MazeCell currentCell;
	private MazeDirection currentDirection;

	//attempt to implement character controller
	//public CameraFollow camPrefab;
	public float acceleration=1f;
	public float jumpHeight = 10f;
//	Vector3 newPos = new Vector3 (0f,0f,0f); 
	public float TerminalVelocity = -20f;
	public float speed = 4.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = -9.8F;
	private Vector3 moveDirection = Vector3.zero;
	//private CharacterController controller;

	void Start(){
		//controller = GetComponent<CharacterController>();
		//camPrefab = Instantiate (camPrefab) as CameraFollow;

	}
	
	private void Rotate (MazeDirection direction) {
		transform.localRotation = direction.ToRotation();
		currentDirection = direction;
	}
	
	public void SetLocation (Vector3 sLoc) {
	//public void SetLocation(MazeCell cell){
		//currentCell = cell;
		//transform.localPosition = cell.transform.localPosition;
		transform.localPosition = sLoc;

	}
	
	/*private void Move (MazeDirection direction) {
		MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage) {
			controller.Move ();
//			SetLocation(edge.otherCell);
		}
	}*/
	void Update() {

		CharacterController controller = GetComponent<CharacterController> ();
		//if (controller.isGrounded) { //*FIX DISSSSS**
		//	Debug.Log ("In grounded");
			
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if(controller.isGrounded){
			if (Input.GetButton ("Jump")) {
				Debug.Log("In Jump");
				moveDirection.y += jumpHeight;
				}}
			if (Input.GetKeyDown (KeyCode.Q)) {
				Debug.Log ("In Key Q");
				//transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
				Rotate (currentDirection.GetNextCounterclockwise ());
			} 
			if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log("In Key E");
				//transform.localRotation = Quaternion.Euler(0f, 90f, 0f);

				Rotate (currentDirection.GetNextClockwise ());
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);
		//}
	}

	
		/*private void Update () {//Q and E for rotate, WASD for moving
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			//Move (currentDirection);
			newPos.y += gravity*Time.deltaTime;
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
		Move (newPos);
	} */
		//TRIGGER
	/*void OnCollisionColliderHit(Collider other){
		Debug.Log ("In on trigger enter for player");
		if (other.name == "Maze End") {
			Debug.Log ("In end game! Yay!");
		}
	}*/





}