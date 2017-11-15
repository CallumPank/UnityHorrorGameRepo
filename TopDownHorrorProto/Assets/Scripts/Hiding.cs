using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour {

    [SerializeField]
    string interactType;
    [SerializeField]
    string objectName;

    public PlayerController Player;
    public PlayerMotor motor;
    public EnemyAI Enemy;
    public bool InTriggerBox = false;
    public bool hidden = false;
    bool EnemySawYouHide = false;
    //PlayerMotor motor;
    GameObject player;
    

	// Use this for initialization
	void Start ()
    {
        player = GameManager.instance.player;
    }

    void OnTriggerEnter(Collider other)
    {
        // if player sees you when you enter then keep chasing
        if (Enemy.chasing)
        {
            EnemySawYouHide = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            InTriggerBox = true;
            //print("InTriggerBox = " + InTriggerBox);
            // display "press E to hide"
            UIManager.instance.ShowInteractNotifier(interactType, objectName);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            InTriggerBox = false;
            // hidden = false;
            print("InTriggerBox = " + InTriggerBox);
            UIManager.instance.HideInteractNotifier();
        }
    }

    public void Hide(Vector3 HidePoint)
    {

    }

    // Update is called once per frame
    void Update ()
    {

        if (InTriggerBox)
        {
            if (!EnemySawYouHide)
            {
                Enemy.chasing = false;
                Enemy.hidden = true;
            }
            else
            {
                Enemy.chasing = true;
            }
            
            
        }
        else
        {
            Enemy.hidden = false;
        }
       
        // test key
        if (Input.GetKeyDown(KeyCode.K))
        {
            print("chasing = " + Enemy.chasing);
            print("InTriggerBox = " + InTriggerBox);
        }

        if (InTriggerBox && Input.GetKeyDown(KeyCode.E))
        {
            print("HIDE!");
            Player.hidden = true;
            Player.transform.position = transform.position;
          
            // trigger hiding animation

        }

        

    }

    void LateUpdate()
    {
		if (Player != null)
		{
			if (Player.hidden == true && Input.GetKeyDown(KeyCode.E))
			{
				Player.hidden = false;               
			}
		}
    }
}
