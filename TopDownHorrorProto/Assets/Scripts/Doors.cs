using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	bool canOpen;
	bool open;


	public Transform door;
	public Transform player;


	// Use this for initialization
	void Start () 
	{
		canOpen = true;
		open = false;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		

		float distance = Vector3.Distance (door.transform.position, player.transform.position);
		if (distance < 5) 
		{
			if (Input.GetButtonDown ("Open")) 
			{


				if (canOpen) 
				{
					StartCoroutine ("OpenDoor");
				

				} 
			}
		}

	}


/*	void OpenDoor ()
	{
		transform.Rotate (transform.rotation.x, transform.rotation.y - 90, transform.rotation.z);

	} */

	void ClosedDoor ()
	{
		transform.Rotate (transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);

	} 

	IEnumerator OpenDoor ()
	{
		open = true;
		if (open) 
		{
			transform.Rotate (transform.rotation.x, transform.rotation.y - 90, transform.rotation.z * Time.deltaTime);
			yield return new WaitForSeconds (1);
			open = false;
		}
		if (open == false)
		{
			transform.Rotate (transform.rotation.x, transform.rotation.y + 90, transform.rotation.z * Time.deltaTime);
			yield return new WaitForSeconds (1);
			open = true;

		}
	}

/*	IEnumerator ClosedDoor ()
	{
		if (canClose) 
		{
			transform.Rotate (transform.rotation.x, transform.rotation.y + 10, transform.rotation.z * Time.deltaTime);
			yield return new WaitForSeconds (1);
			canClose = false;
		}

	} */
		
}
