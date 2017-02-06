using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    private float speed = 0.25f;
    private bool notHit;
    private bool limit = false;
    HingeJoint hinge;

    void Start()
    {
        notHit = true;
        hinge = gameObject.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("BlueClown"))
        {
            if (notHit)
            {
                if (transform.position.z <= -0.4620051f)
                {
                    limit = true;
                }
                else if (transform.position.z >= 0.274f)
                {
                    limit = false;
                }


                switch (limit)
                {
                    case true:
                        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
                        hinge.anchor = new Vector3(-0.085f, -0.117f, 0.107f);
                        break;
                    case false:
                        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
                        hinge.anchor = new Vector3(-0.085f, -0.117f, 0.107f);
                        break;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            if (gameObject.tag.Equals("BlueClown"))
            {
                gameObject.BroadcastMessage("Blue"); // score
                notHit = false; // stop update for movement
                transform.Translate(Vector3.zero, Space.World); // stop movement


                // add the hinge
                /*gameObject.AddComponent<HingeJoint>();
                HingeJoint hinge = this.GetComponent<HingeJoint>();
                JointLimits limits = hinge.limits;
                hinge.useLimits = true;
                hinge.enableCollision = true;
                hinge.enablePreprocessing = true;
                hinge.autoConfigureConnectedAnchor = true;
                hinge.axis = new Vector3(0, 0, 0);
                hinge.connectedAnchor = new Vector3(2.016f, 0.3929849f, -0.4620051f);
                limits.min = 0;
                limits.bounciness = 0;
                limits.bounceMinVelocity = 0;
                limits.max = 90;
                hinge.breakForce = Mathf.Infinity;
                hinge.breakTorque = Mathf.Infinity;
                hinge.limits = limits;
                hinge.anchor = new Vector3(-0.14f, -0.117f, 0.107f);*/
            }
            else if (gameObject.tag.Equals("RedClown"))
            {
                gameObject.BroadcastMessage("Red");

            }
            else if (gameObject.tag.Equals("GreenClown"))
            {
                gameObject.BroadcastMessage("Green");
            }

            // turn gravity on for hinge to activate
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
