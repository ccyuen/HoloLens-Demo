using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLamp : MonoBehaviour {
    public Material[] mat = new Material[2];
    public Material OffMaterial;
    public Material OnMaterial;

    void Start()
    {
        mat = GetComponent<Renderer>().materials;
        mat[0] = OffMaterial;
        mat[1] = OnMaterial;
    }
    
    // called by LampTriggerEvent once the cube is colliding with the base of the lamp
    void isTouching ()
    {
        // change the lamp light material to on
        GetComponent<Renderer>().material = mat[1];
    }

    // called by LampTriggerEvent once the cube is no longer colliding with the base of the lamp
    void isNotTouching()
    {
        // change the lamp light material to off
        GetComponent<Renderer>().material = mat[0];
    }
}
