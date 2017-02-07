using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    private float speed = 0.25f;
    private bool limit = false;
    private bool dead;
    private bool alreadyHit;
    HingeJoint hinge;

    void Start()
    {
        dead = false;
        alreadyHit = false;
        hinge = gameObject.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("BlueClown"))
        {
            if (!dead)
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
            else if (dead && !alreadyHit)
            {
                deadClown(1);
            }
        }
        else if (gameObject.tag.Equals("RedClown") && dead && !alreadyHit)
        {
            deadClown(2);
        }
        else if (gameObject.tag.Equals("GreenClown") && dead && !alreadyHit)
        {
            deadClown(3);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            dead = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            DestroyImmediate(collision.gameObject);
        }   
    }

    private void deadClown(int clownType)
    {
        if (transform.rotation.x > 0)
        {
            if (clownType == 1) // blue
            {
                gameObject.SendMessageUpwards("Blue"); // score
                transform.Translate(Vector3.zero, Space.World); // stop movement
            }
            else if (clownType == 2) // red
            {
                gameObject.SendMessageUpwards("Red"); // score
            }
            else if (clownType == 3) // green
            {
                gameObject.SendMessageUpwards("Green"); // score

            }
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().mass = 300;
            alreadyHit = true;
        }
    }
}
