using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleRemover : MonoBehaviour
{
	[SerializeField]
	float timeBeforeDestroy;

	float timer;

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= timeBeforeDestroy)
		{
			Destroy(gameObject);
		}
	}
}
