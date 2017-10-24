using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
	public float stamina = 100.0f;
	public float staminaDepletion = 5.0f;
	public float staminaRegen = 3.0f;
	bool running = false;

    NavMeshAgent agent;

    [SerializeField]
    float standardSpeed;
    [SerializeField]
    float reverseSpeed;
    [SerializeField]
    float maxMoveTime;
    [SerializeField]
    float sprintSpeed;
    [SerializeField]
    float maxSprintTime;
    [SerializeField]
    float remainingSprintTime;
    [SerializeField]
    float rotationSpeed;

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
        }

		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			stamina -= Time.deltaTime / staminaDepletion;
			if(stamina > 0)
			{
				running = true;
			}
		}
        #endregion

        #region Player Rotation
        if (agent.isStopped)
        {
            float rotationInput = Input.GetAxis("Horizontal");

            transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
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

    public void SetStandardSpeed()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = standardSpeed;
    }

    public void SetReverseSpeed()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = reverseSpeed;
    }

    IEnumerator MovementLimiter()
    {

        yield return new WaitForSeconds(maxMoveTime);
        agent.isStopped = true;
    }
}
