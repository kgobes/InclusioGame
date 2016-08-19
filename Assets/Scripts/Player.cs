using UnityEngine;
using UnityEngine.UI;

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
	public float rotateSpeed = 16.0f;
	public float jumpSpeed = 8.0F;
	public float gravity = -9.8F;
	private Vector3 moveDirection = Vector3.zero;
	//private CharacterController controller;

    private bool isTurning = false; // true while turning, used to restrict input while this is happening
    private float turnSpeed = 8f; // coefficient for the speed the player will rotate when turning

    ParticleSystem UIFogLeft;
    ParticleSystem UIFogRight;

	void Start(){
		//controller = GetComponent<CharacterController>();

		//camPrefab = Instantiate (camPrefab) as CameraFollow;
        UIFogLeft = transform.FindChild("UIFog_left").gameObject.GetComponent<ParticleSystem>();
        UIFogRight = transform.FindChild("UIFog_right").gameObject.GetComponent<ParticleSystem>();
        UIFogLeft.Stop();
        UIFogRight.Stop();
	}
	
	private void Rotate (MazeDirection direction) {
        Debug.Log("starting rotation");
		currentDirection = direction;
        isTurning = true;
	}
	
	public void SetLocation (Vector3 sLoc) {
	//public void SetLocation(MazeCell cell){
		//currentCell = cell;
		//transform.localPosition = cell.transform.localPosition;
		transform.localPosition = sLoc;

	}

	void Update() {
		//Vector2 v3 = new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f);//put in y instead
		//transform.Rotate(v3 * rotateSpeed * Time.deltaTime);
		controller = GetComponent<CharacterController> ();
		//if (controller.isGrounded) { //*FIX DISSSSS**
		//	Debug.Log ("In grounded");

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                Debug.Log("In Jump");
                moveDirection.y += jumpHeight;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        if (canMoveAround)
        controller.Move(moveDirection * Time.deltaTime);

        if(isTurning)
        {
            UpdateTurning();
        }
        else    // ignore additional input to turn if a turn is already in progress
        {
            if (canMoveAround)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    //transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    Rotate(currentDirection.GetNextCounterclockwise());
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    Rotate(currentDirection.GetNextClockwise());
                }
            }
        }

	}

	public void UpdateTurning()
    {
        float _margin = 0.5f; // if the rotation is this close to the desired rotation, the turn is complete. Expressed in degrees
        if (transform.localRotation.eulerAngles.y > (currentDirection.ToRotation().eulerAngles.y - _margin) && transform.localRotation.eulerAngles.y < (currentDirection.ToRotation().eulerAngles.y + _margin))   // check if current rotation is very close to desired rotation
        {
           // Debug.Log("Turn Complete!");
            transform.localRotation = currentDirection.ToRotation();    // set localRotation to EXACTLY the rotation we want to ensure accuracy
            isTurning = false;
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, currentDirection.ToRotation(), Time.deltaTime * turnSpeed);
        }
    }
		
	public void canMove(bool canMoveAround){
		this.canMoveAround = canMoveAround;
        GetComponent<Rigidbody>().isKinematic = !canMoveAround;

        //if(canMoveAround)
        //{
        //    UIFogLeft.Stop();
        //    UIFogRight.Stop();
        //}
        //else
        //{
        //    UIFogLeft.Play();
        //    UIFogRight.Play();
        //}
	}




}