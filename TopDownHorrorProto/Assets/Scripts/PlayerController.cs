using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

	[SerializeField]
	bool usingTorch;

    Camera cam;
    PlayerMotor motor;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
	{

		if (Input.GetButtonDown("Jump")) {
			usingTorch = true;
		} else if (Input.GetButtonUp("Jump")) {
			usingTorch = false; 
		}

		if (!usingTorch) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = cam.ScreenPointToRay (Input.mousePosition);

				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 100f, movementMask)) {
					motor.MoveToPoint (hit.point);
					//Stop focusing on objects
				}
			}

			if (Input.GetMouseButtonDown (1)) {
				Ray ray = cam.ScreenPointToRay (Input.mousePosition);

				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 100f)) {
					//Check to see if hit interactable, if so focus on it
				}
			}
		}
	}
}
