using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearBar : MonoBehaviour {

	public EnemyDetection FOV;
    public EnemyDetection InnerCone;

	public Image _bar;

	public float _FearValue = 0.0f;
    public float amount = 0.0f;


    // Update is called once per frame
    void Update ()
    {
		FearChange(GameManager.instance.playerFear);
        //FearChange(InnerCone.fear);
        //print("Fear = " + amount);
        if (amount >= 0.3)
        {
            // something

        }
        if (amount >= 0.75)
        {
            // something else
        }
    }

	//Stamina Bar fills up to 180 degrees depending on fill amount
	void FearChange(float FearValue)
    {

		amount = (FearValue/1.0f) * 180.0f/360;
		_bar.fillAmount = amount;

	}
}
