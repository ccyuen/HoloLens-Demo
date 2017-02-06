using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLamp : MonoBehaviour {
    public Material[] mat = new Material[2];
    public Light lampLight;

    void Start()
    {
        mat = GetComponent<Renderer>().materials;
        lampLight.enabled = false;
    }
    
    // called by LampTriggerEvent once the cube is colliding with the base of the lamp
    void isTouching ()
    {
        Debug.LogError("is touching");
        // change the lamp light material to on
        GetComponent<Renderer>().material = mat[1];
        lampLight.enabled = true;
    }

    // called by LampTriggerEvent once the cube is no longer colliding with the base of the lamp
    void isNotTouching()
    {
        Debug.LogError("is not touching");
        // change the lamp light material to off
        GetComponent<Renderer>().material = mat[0];
        lampLight.enabled = false;
    }
}
