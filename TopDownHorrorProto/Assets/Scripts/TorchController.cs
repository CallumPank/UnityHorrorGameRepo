using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{

    bool SeeEnemyAi;

	public float minAngle = 10;
	public float maxAngle = 42;

	[SerializeField]
    Light torch;

    [SerializeField]
    float forwardAngle;
    [SerializeField]
    float backwardAngle;

    PlayerMotor motor;

    // Use this for initialization
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
		torch.type = LightType.Spot;
        motor.SetStandardSpeed();
    }

    // Update is called once per frame
    void Update()
    {
       

		//Changes Torch Angle to 10 (Focus Beam Maybe?) Open = E
		if (Input.GetButtonDown ("Open")) {
			torch.spotAngle = minAngle;
		}

		if (Input.GetButtonUp ("Open")) {
			PointTorchForward();
		}

        if (Input.GetButtonDown("Jump"))
        {
            PointTorchBackward();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            PointTorchForward();
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(gameObject.name + "Was Triggered By" + other.gameObject.name);
    }


    void PointTorchForward()
    {
        torch.spotAngle = forwardAngle;
        RotateTorch();
        motor.SetStandardSpeed();
    }

    void PointTorchBackward()
    {
        torch.spotAngle = backwardAngle;
        RotateTorch();
        motor.SetReverseSpeed();
    }

    void RotateTorch()
    {
        Vector3 vec = torch.gameObject.transform.eulerAngles;
        vec.y += 180f;
        torch.gameObject.transform.eulerAngles = vec;
    }
}
