using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour {

    public Transform[] Waypoints;
    //public int MoveSpeed;
    int destination = 0;
    NavMeshAgent agent;
    public bool chase = false;
    GameObject player, rPortal, gPortal, bPortal;
    Color currentColor;
    
    //------------------------
    //This array will be filled with empty game objects in the inspector
    //The object that has this code attached to it will move between these points 
    //in the order they appear in the array
    //------------------------

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
            moveToPoint(player);
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
}
