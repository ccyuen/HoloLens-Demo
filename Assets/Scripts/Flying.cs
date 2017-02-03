using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

    bool selected;

    public GameObject ship;
    private Rigidbody shiprb;
    public ParticleSystem leftBooster;
    public ParticleSystem rightBooster;
  
    private ConstantForce rocketForce;
    public float liftSpeed = 20f;
    public float turnSpeed = 1f;



    void Start()
    {
        selected = false;
        shiprb = ship.GetComponent<Rigidbody>();
        //rocketForce.force = Vector3.zero;
        //rocketForce.relativeTorque = Vector3.zero;
        leftBooster.Stop();
        rightBooster.Stop();
    }

    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        selected = !selected;

        // If the user has selected the ship, turn off gravity and turn on boosters for lift off
        if (selected)
        {
            // propel object
            rocketForce.force = Vector3.up * liftSpeed;
            rocketForce.relativeTorque = new Vector3(0, turnSpeed, 0);

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
            rocketForce.force = Vector3.zero;
            rocketForce.relativeTorque = Vector3.zero;

            // turn off particle systems
            leftBooster.Stop();
            rightBooster.Stop();

            // turn on gravity while not flying
            shiprb.useGravity = true;
            shiprb.isKinematic = false;
        }
    }
}
