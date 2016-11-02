using UnityEngine;

// Thise will automatically add the mentioned component when the program starts. In this pertically case it is a component called PlayerMotor. 
// This will in turn invoke that a Rigidbody body is added (Look at script PlayerMotor line 3)
[RequireComponent(typeof(PlayerMotor))]

public class PlayerControler : MonoBehaviour {

	[SerializeField] 
	float speed,mouseSensetivity;
	
	

	private PlayerMotor motor; 

	void Start () {

		motor = GetComponent <PlayerMotor> (); 

	}

	void Update () {
		
		// When you use GetAxisRaw, you get the data without unity making any smoothing that you would get if you used GetAxis. 
		// When using Horizontal and Vertical axis, the value is going to between the range of -1 to 1 (for them both individually)
		float xMovement = Input.GetAxisRaw("Horizontal");
		float zMovement = Input.GetAxisRaw ("Vertical");

		// Like the previus floates we acess some input information, this time it would be from the mouse 
		float yRotation = Input.GetAxisRaw ("Mouse X");
		float xRotation = Input.GetAxisRaw ("Mouse Y");

		//Debug.Log (xRotation);


		// This creates a 3D vector that makes the object able to move. The reason for using transform is that this takes into consideration the current location of the object.
		Vector3 getMovingHorizontal = transform.right * xMovement;
		Vector3 getMovingVertical = transform.forward * zMovement;

		//Here to add the previous vectors together, and normalize (this mean that the total value have to be one) 
		Vector3 velocity = (getMovingHorizontal + getMovingVertical).normalized * speed;

		//Here a vector is created which will used to create the rotation. Here the mouse sensativity is an factor which influence how much the rotation is affeceted. 
		Vector3 rotation = new Vector3 (0,yRotation,0) * mouseSensetivity;
		Vector3 camRotation = new Vector3 (xRotation ,0,0) * mouseSensetivity;


		//Here a function inside PlayerMotor is called 
		motor.move (velocity);
		motor.getRotation (rotation);
		motor.getCamRotation (camRotation);
	}




}
