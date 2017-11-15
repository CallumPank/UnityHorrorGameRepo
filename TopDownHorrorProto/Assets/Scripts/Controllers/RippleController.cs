using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleController : MonoBehaviour {
    
    public float currentTime;
    Material mat;

    // Use this for initialization
    void Start () {
        mat = GetComponent<Renderer> ().material;
    }

    // Update is called once per frame
    void Update () {
        currentTime += Time.deltaTime;
        mat.SetFloat ("_Timer", currentTime);
    }
}