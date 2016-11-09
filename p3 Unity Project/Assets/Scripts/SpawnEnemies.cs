using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public Vector3 startPosition;

	[SerializeField]
	private float newZPos, externalPos;
	//private float newZPos = -10;

	[SerializeField]
	string spawnerName; 



//	private float newXPos = -10f;
//	private float newYPos = -10f;

	 

	public GameObject[] gameObjectsSet;
	public float moveSpeed = 1f;
	public float moveDistance = 50f;
	public float startTime = 0f;
	public float secondsBetweenSpawn = 3f;
	public float timeLeftUntilSpawn = 0f;

	//ONLY FOR PROTOTYPING!!!!!!!!!!!
	[SerializeField]
	GameObject player;



	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		newZPos = gameObject.transform.position.z;

	
	}

	void SpawnRandomEnemies() {
		int selectItem = Random.Range (0, 6);
		//Debug.Log ("The enemy no is: " + selectItem);
		GameObject myObj = Instantiate (gameObjectsSet [selectItem]) as GameObject;

		myObj.transform.position = transform.position;
	}

	// Update is called once per frame
	void Update () {
		// newXPos = Mathf.PingPong (Time.time * moveSpeed, moveDistance) - (moveDistance / 2f);



		newZPos = (Mathf.PingPong (Time.time * moveSpeed, moveDistance) - (moveDistance / 2f));

		transform.position = new Vector3 (startPosition.x, startPosition.y, newZPos + externalPos);   // startPosition.x


		//transform.position = new Vector3 (startPosition.x, startPosition.y, newZPos);   // startPosition.x

		//ONLY FOR PROTOTYPING!!!!!!!!!!!!
		if (player.GetComponent <Transform> ().position.x < 180) {
			

		timeLeftUntilSpawn = Time.time - startTime;

	
			if (timeLeftUntilSpawn >= secondsBetweenSpawn) {
				startTime = Time.time - Random.Range (0.1f, 0.5f);
				timeLeftUntilSpawn = 0;

				SpawnRandomEnemies ();
			} 
		}
	
	}



}
