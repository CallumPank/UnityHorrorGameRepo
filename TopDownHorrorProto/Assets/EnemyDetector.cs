using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour {
	 
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerStay(Collision c)
	{
		if (c.collider.gameObject.tag == "EnemyAI") 
		{
			Debug.Log ("Hit Enemy with light trigger");
		}
	}
}
