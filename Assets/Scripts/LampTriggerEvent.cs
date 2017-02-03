using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTriggerEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // while the cube stays on the lamp
    void OnTriggerStay(Collider other)
    {
        // if the object is the cube then
        // gameObject.SendMessageUpwards("isTouching");
        // else do nothing
    }
}
