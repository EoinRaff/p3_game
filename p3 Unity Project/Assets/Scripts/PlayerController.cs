using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int health;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Enemy" && (other.GetComponent<Renderer>().material.color == Color.cyan || other.GetComponent<Renderer>().material.color == Color.magenta|| other.GetComponent<Renderer>().material.color == Color.yellow))
        {
            Destroy(other.gameObject);
            health--;
            print(health);
            if (health <= 0)
            {
                print("DEAD");
            }
        }
    }
}
