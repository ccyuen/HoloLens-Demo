using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStack : MonoBehaviour {

    public GameObject Prefab;   

	// Use this for initialization
	void Start () {
		for (int layers = 0; layers < 8; layers++)
        {
            for (int i = 0; i < 3; i++)
            {
               // Instantiate(Prefab, transform.position + (transform.right * distance), transform.);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		    
	}
}
