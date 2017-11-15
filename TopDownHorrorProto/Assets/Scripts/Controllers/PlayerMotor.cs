using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
	public NavMeshAgent agent;

	public float stamina = 100.0f;
	public float staminaRegen = 0.01f;
	public float staminaDepress = 0.01f;

	[Header("Player Speed")]
	[SerializeField]
	float standardSpeed;
	[SerializeField]
	float reverseSpeed;
	[SerializeField]
	float sprintSpeed;
	[SerializeField]
	float rotationSpeed;
	[Header("Movement Cooldowns")]
	[SerializeField]
	float maxMoveTime;
	[SerializeField]
	float maxSprintTime;
	float remainingSprintTime;
	[Header("GameObject Components")]
	[SerializeField]
	GameObject gfx;

	// Use this for initialization
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.isStopped = true;
		remainingSprintTime = maxSprintTime;
	}

	void Update()
	{
		#region Sprinting
		if (Input.GetKeyDown(KeyCode.LeftShift) && remainingSprintTime > 0f)
		{
			agent.speed = sprintSpeed;
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift) || remainingSprintTime <= 0f)
		{
			agent.speed = standardSpeed;
		}

		if (!agent.isStopped && Input.GetKey(KeyCode.LeftShift))
		{

			remainingSprintTime -= Time.deltaTime;
			remainingSprintTime = Mathf.Clamp(remainingSprintTime, 0f, maxSprintTime);
		}

		if (agent.isStopped)
		{
			remainingSprintTime += Time.deltaTime;
			remainingSprintTime = Mathf.Clamp(remainingSprintTime, 0f, maxSprintTime);
			stamina = remainingSprintTime;
		}


		if (Input.GetKey(KeyCode.LeftShift) && stamina >= staminaDepress)
		{
			stamina -= staminaDepress;

		}
		#endregion

		#region Player Rotation
		if (agent.isStopped)
		{
			float rotationInput = Input.GetAxis("Horizontal");

			transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
		}
		#endregion

		#region Lookback
		if (Input.GetButtonDown("Jump"))
		{
			SetReverseSpeed();
			Rotate();
		}
		else if (Input.GetButtonUp("Jump"))
		{
			SetStandardSpeed();
			Rotate();
		}
		#endregion

		if (agent.remainingDistance <= 0.1f)
		{
			agent.isStopped = true;
		}
	}

	public void MoveToPoint(Vector3 point)
	{
		agent.SetDestination(point);
		agent.isStopped = false;
		StopCoroutine("MovementLimiter");
		StartCoroutine("MovementLimiter");
	}
    public void TeleportTo(Vector3 point)
    {
        agent.SetDestination(point);
        agent.isStopped = true;
        //agent.speed = 0;
        agent.ResetPath();
        StopCoroutine("MovementLimiter");
    }

    void SetStandardSpeed()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.speed = standardSpeed;
	}

	void SetReverseSpeed()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.speed = reverseSpeed;
	}

	IEnumerator MovementLimiter()
	{

		yield return new WaitForSeconds(maxMoveTime);
		agent.isStopped = true;
	}

	void Rotate()
	{
		Vector3 gfxRot = gfx.transform.eulerAngles;
		gfxRot.y += 180f;
		gfx.transform.eulerAngles = gfxRot;

	}
}
