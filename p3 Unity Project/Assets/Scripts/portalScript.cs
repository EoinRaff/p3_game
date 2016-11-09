using UnityEngine;
using System.Collections;

public class portalScript : MonoBehaviour {

    Color portalColor;
    static int numberOfGhosts;

	// Use this for initialization
	void Awake () {

        numberOfGhosts = 0;
        portalColor = gameObject.GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Enemy" && other.GetComponent<Renderer>().material.color == portalColor)
        {
            Destroy(other.gameObject);
            numberOfGhosts++;
        }
    }
}
