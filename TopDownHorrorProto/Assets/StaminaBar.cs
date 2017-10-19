using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour {

    public Image _bar;
    public RectTransform Button;

    public float _StaminaValue = 0;
	
	// Update is called once per frame
	void Update () {
        StaminaChange(_StaminaValue);
	}

    void StaminaChange(float healthValue) {

        float amount = (healthValue/100.0f) * 180.0f/360;
        _bar.fillAmount = amount;
        float buttonAngle = amount * 360;
        Button.localEulerAngles = new Vector3(0, 0, -buttonAngle); 


    }
}
