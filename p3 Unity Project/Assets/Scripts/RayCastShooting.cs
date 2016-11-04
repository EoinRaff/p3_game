using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class RayCastShooting : MonoBehaviour
{


    public string gunColor;
    public int gunDamage = 1;                                           // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public float fireRate = 0.25f;                                      // Number in seconds which controls how often the player can fire
    public float weaponRange = 50f;                                     // Distance in Unity units over which the player can fire
    public float hitForce = 100f;                                       // Amount of force which will be added to objects with a rigidbody shot by the player
    public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun

    private Camera fpsCam;                                              // Holds a reference to the first person camera
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
    private AudioSource gunAudio;                                       // Reference to the audio source which will play our shooting sound effect
    private LineRenderer laserLine;                                     // Reference to the LineRenderer component which will display our laserline
    private float nextFire;                                             // Float to store the time the player will be allowed to fire again, after firing
    Material gunMat;

    void Start()
    {
        // Get and store a reference to our LineRenderer component
        laserLine = GetComponent<LineRenderer>();

        // Get and store a reference to our Camera by searching this GameObject and its parents
        fpsCam = GetComponentInParent<Camera>();
        gunMat = gameObject.GetComponent<Renderer>().material;

    }


    void Update()
    {
        selectColor();
        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;

            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

            // Set the start position for our visual effect for our laser to the position of gunEnd
            laserLine.SetPosition(0, gunEnd.position);

            // Check if our raycast has hit anything
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                // Set the end position for our laser line 
                laserLine.SetPosition(1, hit.point);

                // Get a reference to a health script attached to the collider we hit
                ShootableThing health = hit.collider.GetComponent<ShootableThing>();

                // If there was a health script attached
                if (health != null)
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage(gunDamage, gunColor);
                }

                // Check if the object we hit has a rigidbody attached
                if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }

    void selectColor()
    {
        //for early prototying only
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunMat.color = Color.red;
            gunColor = "Red";
            print(gunColor);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunMat.color = Color.green;
            gunColor = "Green";
            print(gunColor);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunMat.color = Color.blue;
            gunColor = "Blue";
            print(gunColor);
        }

    }
    private IEnumerator ShotEffect()
    {
        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
=======
public class RayCastShooting : MonoBehaviour {


	public string gunColor;
	public int gunDamage = 1;                                           // Set the number of hitpoints that this gun will take away from shot objects with a health script
	public float fireRate = 0.25f;                                      // Number in seconds which controls how often the player can fire
	public float weaponRange = 50f;                                     // Distance in Unity units over which the player can fire
	public float hitForce = 100f;                                       // Amount of force which will be added to objects with a rigidbody shot by the player
	public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun

	private Camera fpsCam;                                              // Holds a reference to the first person camera
	private Camera sightCam;											// Holds a reference to the aim-down-sight camera
	private WaitForSeconds shotDuration = new WaitForSeconds(0.03f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
	private LineRenderer laserLine;                                     // Reference to the LineRenderer component which will display our laserline
	private float nextFire;                                             // Float to store the time the player will be allowed to fire again, after firing

	private MeshRenderer rend;


	void Start () 
	{
		// Get and store a reference to our LineRenderer component
		laserLine = GetComponentInChildren<LineRenderer>();

		// Get and store a reference to our Camera by searching this GameObject
		fpsCam = GetComponent<Camera>();


		sightCam = GetComponentInChildren<Camera> ();

	}


	void Update () 
	{
		//
		if (Input.GetMouseButtonDown (1)) {
			sightCam.enabled = true;
			fpsCam.enabled = false;
		}
		if (Input.GetMouseButtonUp (1)) {
			sightCam.enabled = false;
			fpsCam.enabled = true;
		}

		// Check if the player has pressed the fire button and if enough time has elapsed since they last fired
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) 
		{
			// Update the time when our player can fire next
			nextFire = Time.time + fireRate;

			// Start our ShotEffect coroutine to turn our laser line on and off
			StartCoroutine (ShotEffect());

			// Create a vector at the center of our camera's viewport
			Vector3 fpsRayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

			Vector3 sightRayOrigin = sightCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

			// Declare a raycast hit to store information about what our raycast has hit
			RaycastHit hit;

			// Set the start position for our visual effect for our laser to the position of gunEnd
			laserLine.SetPosition (0, gunEnd.position);

			// Check if our raycast has hit anything
<<<<<<< HEAD
				if (Physics.Raycast (fpsRayOrigin, fpsCam.transform.forward, out hit, weaponRange)) {
					// Set the end position for our laser line 
					laserLine.SetPosition (1, hit.point);

					// Get a reference to a health script attached to the collider we hit
					ShootableThing health = hit.collider.GetComponent<ShootableThing> ();

					// If there was a health script attached
					if (health != null) {
						// Call the damage function of that script, passing in our gunDamage variable
						health.Damage (gunDamage);
					}
				} 
				else 
=======
			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
			{
				// Set the end position for our laser line 
				laserLine.SetPosition (1, hit.point);

				// Get a reference to a health script attached to the collider we hit
				ShootableThing health = hit.collider.GetComponent<ShootableThing>();

				// If there was a health script attached
				if (health != null)
				{
					// Call the damage function of that script, passing in our gunDamage variable
					health.Damage (gunDamage, gunColor);
				}

				// Check if the object we hit has a rigidbody attached
				if (hit.rigidbody != null)
>>>>>>> master
				{
					// If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
					laserLine.SetPosition (1, fpsRayOrigin + (fpsCam.transform.forward * weaponRange));
				}
		}
	}


	private IEnumerator ShotEffect()
	{
		// Turn on our line renderer
		laserLine.enabled = true;

		//Wait for .03 seconds
		yield return shotDuration;

		// Deactivate our line renderer after waiting
		laserLine.enabled = false;
	}
>>>>>>> 6052e502c73dd7b27abacdd3a437ebaaa58e30df
}

