using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour {

	[SerializeField]
	GameObject player;

	public GameObject[] checkpoints;
	public GameObject sceretPlatForm;


	void Start () {

		sceretPlatForm.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

		if (player.GetComponent <Transform> ().position.y < -10 && player.GetComponent <Transform> ().position.x > 230 ) {
			player.transform.position = checkpoints [0].transform.position;
			Debug.Log ("He fell");
		} else if (player.GetComponent <Transform> ().position.y < -10 && player.GetComponent <Transform> ().position.x < 260 &&  player.GetComponent <Transform> ().position.x > 188) {
			player.transform.position = checkpoints [1].transform.position;

		} else if (player.GetComponent <Transform> ().position.y < -10 && player.GetComponent <Transform> ().position.x < 188) {
		player.transform.position = checkpoints [2].transform.position;

	} else {
			Debug.Log ("stil on field");

		}

		if (Input.GetKeyDown(KeyCode.F1)) {
			sceretPlatForm.SetActive (true);
		}

		if (Input.GetKeyDown(KeyCode.F2)) {
			SceneManager.LoadScene ("enemy_spawn (Prototype)");
		}

	
	}
}
