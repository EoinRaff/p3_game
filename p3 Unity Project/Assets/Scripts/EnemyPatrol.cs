using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour {


    NavMeshAgent agent;
    GameObject player, rPortal, gPortal, bPortal;
    Color currentColor;
   

        /// <summary>
        /// The completed scene also needs a NavMesh. This is made by going to window > navigation. 
        /// Here any environment objects can be marked as static
        /// Then the NavMesh can be "Baked"
        /// 
        /// This will allow pathfinding for the enemies
        /// </summary>


	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        rPortal = GameObject.Find("rPortal");
        gPortal = GameObject.Find("gPortal");
        bPortal = GameObject.Find("bPortal");
        player = GameObject.FindGameObjectWithTag("Player");

	}

    void moveToPoint(GameObject target)
    {
        agent.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update () {
        currentColor = gameObject.GetComponent<Renderer>().material.color;
        if (currentColor != Color.red && currentColor != Color.green && currentColor != Color.blue)
        {
            moveToPoint(findClosestPlayer());
        }
        else if (currentColor == Color.red)
        {
            moveToPoint(rPortal);

        }
        else if (currentColor == Color.green)
        {
            moveToPoint(gPortal);
        }
        else if (currentColor == Color.blue)
        {
            moveToPoint(bPortal);
        }
        else
        {
            Debug.Log("you shouldn't be here..." + gameObject.name);
        }

    }

    void onTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            if (currentColor == Color.cyan || currentColor == Color.magenta || currentColor == Color.yellow )
            {
                Destroy(gameObject);
                //this probably needs to be called in the player class in order to affect it's health...
            }
        }
        if (other.GetComponent<Collider>().tag == "Portal")
        {
            Destroy(gameObject);
        }
    }

    GameObject findClosestPlayer()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject player in players)
        {
            Vector3 difference = player.transform.position - position;
            float currentDistance = difference.sqrMagnitude;
            if (currentDistance < distance)
            {
                closest = player;
                distance = currentDistance;
            }
        }
        return closest;
    }
}
