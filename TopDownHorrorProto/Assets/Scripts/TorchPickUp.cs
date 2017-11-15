using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPickUp : MonoBehaviour
{
	[SerializeField]
	string interactType;
	[SerializeField]
	string objectName;

	bool pickUp;

	void Update()
	{
		if (pickUp && Input.GetKeyDown(KeyCode.E))
		{
			GameManager.instance.hasTorch = true;
			UIManager.instance.HideInteractNotifier();
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//UI prompts player to use E to pick up
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
