using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLamp : MonoBehaviour {
    public Material[] mat = new Material[2];
    public Light lampLight;
    private bool touching = false;

    void Start()
    {
        mat = GetComponent<Renderer>().materials;
        lampLight.enabled = false;
    }
    
    // called by LampTriggerEvent once the cube is colliding with the base of the lamp
    void isTouching ()
    {
        touching = true;
    }

    // called by LampTriggerEvent once the cube is no longer colliding with the base of the lamp
    void isNotTouching()
    {
        touching = false;
    }

    void update()
    {
        if (touching)
        {
            // change the lamp light material to on
            GetComponent<Renderer>().material = mat[1];
            lampLight.enabled = true;
        }
        else
        {
            // change the lamp light material to off
            GetComponent<Renderer>().material = mat[0];
            lampLight.enabled = false;
        }
    }
}
