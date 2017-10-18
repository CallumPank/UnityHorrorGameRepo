using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    NavMeshAgent agent;

    [SerializeField]
    Transform[] patrolPoints;
    [SerializeField]
    float stoppingDistance;
    [SerializeField]
    float sightRange;

    bool chasing;

    [SerializeField]
    Transform currentTarget;


    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update () {
        if (currentTarget == null && !chasing) {
            GetNewTarget ();
        }

        if (agent.remainingDistance <= stoppingDistance) {
            if (!chasing) {
                //spend some time observing and then ...
                GetNewTarget ();
            } else {
                //attack player etc.
            }
        }

        //checking to see if the player is in the enemy's LOS, if so they will pursue them
        #region Enemy Raycasting
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, sightRange)) {
            if (hit.collider.tag == "Player") {
                Debug.Log ("player seen");
                chasing = true;
            }
        }

        if (chasing) {
            agent.SetDestination (GameManager.instance.player.transform.position);
        }
        #endregion
    }

    void GetNewTarget() {
        int rand = Random.Range (0, patrolPoints.Length);
        currentTarget = patrolPoints[rand];
        agent.SetDestination (currentTarget.position);
    }
}
