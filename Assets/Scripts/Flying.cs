 using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Flying : MonoBehaviour, IInputClickHandler
{

    bool selected = false;
   // Vector3 angle = new Vector3(0, 0, 0);

    public GameObject ship;
    public GameObject path;
    private Rigidbody rigiB;
    public ParticleSystem leftBooster;
    public ParticleSystem rightBooster;
    public float speed;

    void Start()
    {
        //y = 0;
        selected = false;
        rigiB = this.GetComponent<Rigidbody>();
        leftBooster.Stop();
        rightBooster.Stop();
        // initialize angle
    }

    public virtual void OnInputClicked(InputEventData eventData)
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        selected = !selected;
    }

    void Update()
    {
        // If the user has selected the ship, turn off gravity and turn on boosters for lift off
        if (selected)
        {
            // rotate object
            path.transform.Rotate(Vector3.down * speed);
            // play rocket launch sound clip
            //audio.Play();

            // turn off gravity
            rigiB.useGravity = false;

            // turn on particle systems
            leftBooster.Play();
            rightBooster.Play();
        }
        // If the user has not selected the ship, keep gravity on and boosters turned off
        else
        {
            // stop object from rotating
            path.transform.Rotate(Vector3.zero);

            // turn on gravity
            rigiB.useGravity = true;

            // turn off particle systems
            leftBooster.Stop();
            rightBooster.Stop();
        }
    }
}
