using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	public LayerMask movementMask;
    public bool Scared = false;
    public bool hidden = false;

    FearBar PlayerFear;
	Camera cam;
	PlayerMotor motor;
    public Hiding hide;

	// Use this for initialization
	void Start()
	{
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();
        PlayerFear = GetComponent<FearBar>();
        hide = GetComponent<Hiding>();

    }


    // Update is called once per frame
    void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100f, movementMask))
			{
				motor.MoveToPoint(hit.point);
				//Stop focusing on objects
			}
           
        }

        if (Input.GetKeyDown(KeyCode.I)) // If fear is high 
        {
            motor.MoveToPoint(transform.position + new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f)));
        }

        if (Input.GetKeyDown(KeyCode.O)) // If fear is very high                    Input.GetKeyDown(KeyCode.O)
        {
            motor.MoveToPoint(transform.position);
        }

        if (hidden)
        {
            // print("Hidden");

            motor.MoveToPoint(transform.position);
        }

        

        if (Input.GetMouseButtonDown(1))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100f))
			{
				//Check to see if hit interactable, if so focus on it
			}
		}
	}
}
