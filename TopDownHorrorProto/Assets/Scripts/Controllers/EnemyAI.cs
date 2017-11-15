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

    public Hiding hide;
    public bool hidden = false;

    public float currentTime;
    public float startTime;

    Animator anim;

    [SerializeField]
    GameObject soundRipple;

    public bool moving;

    public bool chasing;

    [SerializeField]
    Transform currentTarget;


    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent> ();
        anim = GetComponent<Animator> ();
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
            } else if (chasing) {
				agent.isStopped = true;
            }
        }

		if (agent.isStopped && agent.remainingDistance > stoppingDistance)
		{
			agent.isStopped = false;
		}

        //checking to see if the player is in the enemy's LOS, if so they will pursue them
        #region Enemy Raycasting
        RaycastHit hit;

        if (Physics.Raycast (transform.position, transform.forward, out hit, sightRange))
        {
            if (hit.collider.tag == "Player" || hit.collider.tag == "ConeOfView")
            {
                if (hidden == false)
                {
                    Debug.Log("player seen");
                    chasing = true;
                }
                else
                {
                    chasing = false;
                }
                
            }
        }

        if (chasing) {
            agent.SetDestination (GameManager.instance.player.transform.position);
        }

        //if (GetComponent<Hiding>().IsHiding == true)
        //{
        //    chasing = false;
        //}
        #endregion

        if (agent.isStopped) {
            moving = false;
        } else {
            moving = true;
        }
        anim.SetBool ("moving", moving);

    }

    void GetNewTarget () {
        int rand = Random.Range (0, patrolPoints.Length);
        currentTarget = patrolPoints[rand];
        agent.SetDestination (currentTarget.position);
        GenerateSoundRipple ();
        
    }

    void GenerateSoundRipple () {
        GameObject ins = Instantiate (soundRipple, transform.position, Quaternion.identity) as GameObject;
        ins.GetComponent<Renderer> ().material.SetInt ("_StartAnimation", 1);
        Transform camTransform = Camera.main.transform;
        float distToCenter = (Camera.main.farClipPlane - Camera.main.nearClipPlane) / 2.0f;
        Vector3 center = camTransform.position + camTransform.forward * distToCenter;
        float extremeBound = 500.0f;
        MeshFilter meshFilter = ins.GetComponent<MeshFilter> ();
        meshFilter.sharedMesh.bounds = new Bounds (center, new Vector3 (1, 1, 1) * extremeBound);
    }
}
