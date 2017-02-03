using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableGravity : MonoBehaviour {
    bool isSelected = false;
    private Rigidbody objectrb;

    void Start()
    {
        objectrb = this.GetComponent<Rigidbody>();
    }

    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        isSelected = !isSelected;

        // If the user has selected the ship, turn off gravity and turn on boosters for lift off
        if (isSelected)
        {
            objectrb.useGravity = false;
            objectrb.isKinematic = true;
        }
        // If the user has not selected the ship, keep gravity on and boosters turned off
        else
        {
            objectrb.useGravity = true;
            objectrb.isKinematic = false;
        }
    }
}
