using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLamp : MonoBehaviour {
    public Material[] mat;
    public Material OffMaterial;
    public Material OnMaterial;

    void Start()
    {
        mat = GetComponent<Renderer>().materials;
        mat[0] = OffMaterial;
        mat[1] = OnMaterial;
    }
    
    // Update is called once per frame
    void isTouching ()
    {
        GetComponent<Renderer>().materials = mat[1];
    }
}
