using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
	[SerializeField]
	float playerSpeed;
	[SerializeField]
	float rotateSpeed;
	[SerializeField]
	GameObject gfx;
	[SerializeField]
	float slerpTime;

	Vector3 forwardRot = new Vector3(0f, 0f, 0f);
	Vector3 backwardRot = new Vector3(0f, 180f, 0f);
	Vector3 rightRot = new Vector3(0f, 90f, 0f);
	Vector3 leftRot = new Vector3(0f, 270f, 0f);

	CharacterController controller;

	// Use this for initialization
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		float moveX = Input.GetAxis("Left Horizontal");
		float moveZ = Input.GetAxis("Left Vertical");

		Rotation();

		Vector3 movement = new Vector3(moveX, 0f, moveZ);
		movement = transform.TransformDirection(movement);

		controller.Move(movement * playerSpeed * Time.deltaTime);
	}

	void Rotation()
	{
		float moveX = Input.GetAxis("Left Horizontal");
		float moveZ = Input.GetAxis("Left Vertical");

		if (moveZ != 0 || moveX != 0)
		{
			float angle = Mathf.Atan2(moveX, moveZ) * Mathf.Rad2Deg;
			Quaternion target = Quaternion.Euler(0, angle, 0);
			gfx.transform.rotation = Quaternion.Slerp(gfx.transform.rotation, target, slerpTime);
		}
	}
}