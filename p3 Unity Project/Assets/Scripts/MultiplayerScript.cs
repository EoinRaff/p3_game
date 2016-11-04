using UnityEngine;

using UnityEngine.Networking;

public class MultiplayerScript : NetworkBehaviour {

	[SerializeField]
	Behaviour [] DisableComponent;

	Camera sceneCamera;

	// Use this for initialization

	void Start () {

		if (!isLocalPlayer) {

			for (int i = 0; i < DisableComponent.Length; i++) {

				DisableComponent [i].enabled = false; 

			} 

		} else {

			sceneCamera = Camera.main;

			if (sceneCamera != null) {

				sceneCamera.gameObject.SetActive (false); 

			}

		}
		registerPlayer ();

	}
		
	void OnDisable () {

		if (sceneCamera != null) {

			sceneCamera.gameObject.SetActive (true); 

		}

	}

	void registerPlayer () {

		string playerID = "Player " +  GetComponent <NetworkIdentity> ().netId; 
		transform.name = playerID;


	}

}

