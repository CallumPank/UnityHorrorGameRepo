using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SphereCollider))]
public class PickUp : MonoBehaviour
{
	[Header("Pick Up Details To Be Displayed On UI")]
	[SerializeField]
	string interactType;
	[SerializeField]
	string objectName;

	bool pickUp;

	// Update is called once per frame
	void Update()
	{
		CheckForPickUp();
	}

	void CheckForPickUp()
	{
		if (pickUp && Input.GetButtonDown("Interact"))
		{
			//add to inventory etc
			UIManager.instance.HideInteractNotifier();
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			pickUp = true;
			UIManager.instance.ShowInteractNotifier(interactType, objectName);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			pickUp = false;
			UIManager.instance.HideInteractNotifier();
		}
	}
}
