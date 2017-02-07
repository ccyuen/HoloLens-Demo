using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLamp : MonoBehaviour {
    public Material off;
    public Material on;
    public Light lampLight;
    private bool touching;

    void Start()
    {
        touching = false;
        lampLight.enabled = false;
    }
    
    // called by LampTriggerEvent once the cube is colliding with the base of the lamp
    void isTouching()
    {
        touching = true;
    }

    // called by LampTriggerEvent once the cube is no longer colliding with the base of the lamp
    void isNotTouching()
    {
        touching = false;
    }

    void Update()
    {
        if (touching)
        {
            // change the lamp light material to on
            gameObject.GetComponent<Renderer>().material = on;
            lampLight.enabled = true;
        }
        else
        {
            // change the lamp light material to off
            gameObject.GetComponent<Renderer>().material = off;
            lampLight.enabled = false;
        }
    }
}
