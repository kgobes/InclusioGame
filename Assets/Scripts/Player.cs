using UnityEngine;

public class Player : MonoBehaviour {
	
	private MazeCell currentCell;
	private MazeDirection currentDirection;
	CharacterController controller;

	//attempt to implement character controller
	//public CameraFollow camPrefab;
	public float acceleration=1f;
	public float jumpHeight = 10f;
	public bool canMoveAround = true;
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

		controller = GetComponent<CharacterController> ();
		//if (controller.isGrounded) { //*FIX DISSSSS**
		//	Debug.Log ("In grounded");
			
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;
		if(controller.isGrounded){
			if (Input.GetButton ("Jump")) {
				Debug.Log("In Jump");
				moveDirection.y += jumpHeight;
				}
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			//transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
			Rotate (currentDirection.GetNextCounterclockwise ());
		} 
		if (Input.GetKeyDown (KeyCode.E)) {
			//transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
			Rotate (currentDirection.GetNextClockwise ());
		}
		moveDirection.y -= gravity * Time.deltaTime;
		//if (canMoveAround)
			controller.Move (moveDirection * Time.deltaTime);
	}

	
		
	public void canMove(bool canMoveAround){
		this.canMoveAround = canMoveAround;
	}




}