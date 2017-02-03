using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

    bool selected = false;
    public GameObject ship;
    private Rigidbody shiprb;
    public ParticleSystem leftBooster;
    public ParticleSystem rightBooster;

    void Start()
    {
        shiprb = ship.GetComponent<Rigidbody>();
        leftBooster.Stop();
        rightBooster.Play();
    }

    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        selected = !selected;

        // If the user has selected the ship, turn off gravity and turn on boosters for lift off
        if (selected)
        {
            leftBooster.Play();
            rightBooster.Play();
            shiprb.useGravity = false;
            shiprb.isKinematic = true;
        }
        // If the user has not selected the ship, keep gravity on and boosters turned off
        else
        {
            leftBooster.Stop();
            rightBooster.Stop();
            shiprb.useGravity = true;
            shiprb.isKinematic = false;
        }
    }
}
