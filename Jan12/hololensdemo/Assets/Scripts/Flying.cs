 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

    bool selected = false;
    int y = 0;

    public GameObject ship;
    private Rigidbody shiprb;
    public ParticleSystem leftBooster;
    public ParticleSystem rightBooster;

    void Start()
    {
        //y = 0;
        selected = false;
        shiprb = ship.GetComponent<Rigidbody>();
        leftBooster.Stop();
        rightBooster.Stop();
    }

    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        selected = !selected;
    }

    void Update()
    {
        // If the user has selected the ship, turn off gravity and turn on boosters for lift off
        if (selected)
        {
            // move object
            if (y == 0) ship.transform.Translate(0, 1, 0);
            y++;

            // play rocket launch sound clip
            //audio.Play();

            // turn on particle systems
            leftBooster.Play();
            rightBooster.Play();
            // turn off gravity
            shiprb.useGravity = false;
            shiprb.isKinematic = true;
        }
        // If the user has not selected the ship, keep gravity on and boosters turned off
        else
        {

            // turn off particle systems
            leftBooster.Stop();
            rightBooster.Stop();

            // turn on gravity while not flying
            shiprb.useGravity = true;
            shiprb.isKinematic = false;
        }
    }
}
