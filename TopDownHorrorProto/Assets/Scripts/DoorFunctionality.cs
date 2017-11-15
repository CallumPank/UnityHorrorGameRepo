using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFunctionality : MonoBehaviour
{
	public bool open;
	string interactType;
	bool canInteract;
	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (canInteract && Input.GetButtonDown("Interact"))
		{
			open = !open;

			anim.SetBool("open", open);
		}

		if (open)
		{
			interactType = "close";
		} else if (!open)
		{
			interactType = "open";
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			canInteract = true;
			UIManager.instance.ShowInteractNotifier(interactType, "door");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			canInteract = false;
			UIManager.instance.HideInteractNotifier();
		}
	}

}
