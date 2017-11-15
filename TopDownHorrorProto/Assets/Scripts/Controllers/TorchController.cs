//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TorchController : MonoBehaviour
//{
//    [SerializeField]
//    Light torch;

//    [SerializeField]
//    float forwardAngle;
//    [SerializeField]
//    float backwardAngle;

//    PlayerMotor motor;

//    // Use this for initialization
//    void Start()
//    {
//        motor = GetComponent<PlayerMotor>();
//        motor.SetStandardSpeed();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetButtonDown("Jump"))
//        {
//            PointTorchBackward();
//        }
//        else if (Input.GetButtonUp("Jump"))
//        {
//            PointTorchForward();
//        }
//    }

//    void PointTorchForward()
//    {
//        torch.spotAngle = forwardAngle;
//        RotateTorch();
//        motor.SetStandardSpeed();
//    }

//    void PointTorchBackward()
//    {
//        torch.spotAngle = backwardAngle;
//        RotateTorch();
//        motor.SetReverseSpeed();
//    }

//    void RotateTorch()
//    {
//        Vector3 v = torch.gameObject.transform.eulerAngles;
//        v.y += 180f;
//        torch.gameObject.transform.eulerAngles = v;
//    }
//}
