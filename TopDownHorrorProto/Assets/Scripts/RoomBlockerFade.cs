using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBlockerFade : MonoBehaviour
{
	Animator anim;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (other.name != "pCylinder1")
			{
				anim.SetBool("hasEntered", true);
			}
		}
	}
}
