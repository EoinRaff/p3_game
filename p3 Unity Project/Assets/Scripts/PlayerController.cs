using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int health;
    int maxHealth;
    public GameObject spawnPoint;
    public int respawnTime;
    //public GameObject respawnCam;
    GameObject mainCam;
    // Use this for initialization
    void Start () {
        maxHealth = health;
        //respawnCam.GetComponent<Camera>().enabled = false;
        //respawnCam.GetComponent<AudioListener>().enabled = false;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Enemy" &&
            other.GetComponent<Renderer>().material.color != Color.red && 
            other.GetComponent<Renderer>().material.color != Color.green && 
            other.GetComponent<Renderer>().material.color != Color.blue)
        {
            Destroy(other.gameObject);
            health--;
            print(health);
            if (health <= 0)
            {
                instantRespawn();
                //StartCoroutine(Respawn());
                //gameObject.transform.position = findClosestSpawn().position;

            }
        }
    }

    //This doesn't work as hoped, so we should have one respawn point. 
    //Hopefully the similiar function in enemy patrol will work
    Transform findClosestSpawn()
    {

        GameObject[] listOfPoints;
        listOfPoints = GameObject.FindGameObjectsWithTag("Respawn");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject point in listOfPoints)
        {
            Vector3 difference = point.transform.position - position;
            float currentDistance = difference.sqrMagnitude;
            if (currentDistance < distance)
            {
                closest = point;
                distance = currentDistance;
            }
        }
        return closest.transform;
    }

    IEnumerator Respawn()
    {
       
        //Disable Camera, Audiolistener, and Renderer
        //swap to respawn Camera

        yield return new WaitForSeconds(respawnTime);

        //disable respawn Camera
        //re-enable Camera, audiolistener, and renderer.


        gameObject.transform.position = spawnPoint.transform.position;
        health = maxHealth;
    }

    void instantRespawn()
    {
        gameObject.transform.position = spawnPoint.transform.position;
        health = maxHealth;
    }
}
