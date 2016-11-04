using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ShootableThing : NetworkBehaviour {


	//The box's current health point total
	public int currentHealth = 3;

	void Start () {
		if (!isLocalPlayer)
			return;
	}

	[Command]
	public void CmdDamage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		if (currentHealth <= 0) 
		{
			//if health has fallen below zero, deactivate it 
		    //gameObject.SetActive (false);
			CmddestroyEnemy (); 
		}
	}

	//this updates the destuction of enemy on both screens (but only the host can destroy)

	public void CmddestroyEnemy () {

		//gameObject.SetActive (false)
		NetworkServer.Destroy (this.gameObject);


	}

}
