using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeleportLocalArray : MonoBehaviour {

    public GameObject[] teleport;

    public static TeleportLocalArray instance;

    // Use this for initialization
    void Start () {

        instance = this;

        teleport = GameObject.FindGameObjectsWithTag("Teleports");

        for (int i = 0; i < teleport.Length; i++)
        {
            Debug.Log("Teleport Locations Is " + i + teleport[i].name);
        }

	}

    public void Teleport(MonoBehaviour go, int index)
    {
        var pos = go.transform.position;

        pos.x = teleport[index].transform.position.x;
        pos.z = teleport[index].transform.position.z;
        
        //(go as PlayerController).motor.TeleportTo(go.transform.position);

		NavMeshAgent agent = go.GetComponent<NavMeshAgent>();
		if (agent != null) {
			agent.SetDestination (pos);
		}

        go.transform.position = pos;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
