using UnityEngine;

// Thise will automatically add the mentioned component when the program starts. 
[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour {

	// This makes the variable visible inside Unity eventhough it´s declared as private. 
	[SerializeField]
	Camera playerCam;

	Vector3 velocity; 
	Vector3 rotation; 
	Vector3 camRotation;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent <Rigidbody> (); 
	}
	
	//Insted of runnning each frame (the the function Update will do), we insted run each frame there is a physical change 
	void FixedUpdate () {
		getTheObjectMoving ();
		getTheObjectRotating ();

		Debug.Log (camRotation);

	}


	//Here we get the the velocity from the playerControle scripts 
	public void move (Vector3 _velocity) {

		velocity = _velocity;
	}

	//Here we get the the rotation from the playerControle scripts 
	public void getRotation (Vector3 _rotation) {

		rotation = _rotation;
	}

	public void getCamRotation (Vector3 _camRotation) {
		camRotation = _camRotation; 
	}

	void getTheObjectMoving () {

		//Insures that there has happen some change to the our velocity vector
		if (velocity != Vector3.zero) {

		// Here we call the method: Moveposition, this has the ability to check whether our object is colliding with any objects inside the created world
			// The time.fixedDeltaTime, is the is the seconds of the interval of the object changes 

			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); 
		}
	}

	// This method applies the rotation to the Rigidbody
	 void getTheObjectRotating () {

		// Here we call the method MoveRotation which are contained inside the Rigidbody class (this is the same for rb.rotation). 
		// The Quaternion is a way of representing rotation, and by calling Quaternion.Euler we give it the input of the axis zyx.
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
		playerCam.transform.Rotate (-camRotation);

	}



}
