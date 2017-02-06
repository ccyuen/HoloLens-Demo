using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{


    //public Vector3 pos1;
    //public Vector3 pos2;

    public float speed;
    private bool limit = false;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("MovingClown")) {
            if (transform.position.z <= -0.2f)
                limit = true;
            else if (transform.position.z >= 0.2f)
                limit = false;

            switch(limit)
            {
                case true:
                    transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
                    break;
                case false:
                    transform.Translate(Vector3.back * Time.deltaTime * speed, Space.Self);
                    break;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            if (gameObject.tag.Equals("BlueClown"))
            {
                transform.Translate(Vector3.zero);
                gameObject.AddComponent<HingeJoint>();
                HingeJoint hinge = gameObject.GetComponent<HingeJoint>();
                JointLimits limits = hinge.limits;
                hinge.useLimits = true;
                limits.min = 0;
                limits.bounciness = 0;
                limits.bounceMinVelocity = 0;
                limits.max = 90;
                hinge.limits = limits;
            }
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
