using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour {

    public Transform[] Waypoints;
    //public int MoveSpeed;
    int destination = 0;
    NavMeshAgent agent;
    public bool chase = false;
    GameObject player;
    
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
        GoToNextPoint();

	}
	void GoToNextPoint()
    {
        if (Waypoints.Length==0)
        {
            return;
        }
        agent.destination = Waypoints[destination].position;

        destination = (destination + 1) % Waypoints.Length;
    }
    void ChasePlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent.destination = player.transform.position;

        //needs some collision logic

    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //switch for debugging
            chase = !chase;
        }

        if (agent.remainingDistance > 0.5f && !chase)
        {
            GoToNextPoint();
        }
        if (chase)
        {
            ChasePlayer();
        }
	}
}
