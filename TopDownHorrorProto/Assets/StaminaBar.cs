using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour {

	public PlayerMotor StaminaMotor;
    public Image _bar;

    public float _StaminaValue = 0;
	
	// Update is called once per frame
	void Update () {
		StaminaChange(StaminaMotor.stamina);
	}

	//Stamina Bar fills up to 180 degrees depending on fill amount
    void StaminaChange(float StaminaValue) {

        float amount = (StaminaValue/1.0f) * 180.0f/360;
        _bar.fillAmount = amount;

    }
}
