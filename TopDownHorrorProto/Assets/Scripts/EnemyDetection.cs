using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDetection : MonoBehaviour
{

	public float fearIncrease = 0.1f;
	public float fearDecrease = 0.01f;

	public EnemyAI AI;

	void Update()
	{
		if (!GameManager.instance.enemyDetected)
		{
			GameManager.instance.playerFear -= fearDecrease;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			GameManager.instance.enemyDetected = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			GameManager.instance.enemyDetected = false;
		}
	}

	void OnTriggerStay(Collider c)
	{
		if (c.gameObject.tag == "Enemy")
		{
			GameManager.instance.playerFear += fearIncrease;

		}
	}
}
