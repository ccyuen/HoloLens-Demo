using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    private float speed = 0.25f;
    private bool limit = false;
    private bool dead;
    private bool alreadyHit;
    private Vector3 cords = new Vector3();
    private Quaternion rotation;
    HingeJoint hinge;

    void Start()
    {
        cords = gameObject.transform.position;
        rotation = gameObject.transform.rotation;
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
                if (transform.localPosition.x < -0.068f)
                {
                    limit = true;
                }
                else if (transform.localPosition.x > 0.302002f)
                {
                    limit = false;
                }


                if (limit)
                        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
                else
                        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
                hinge.anchor = new Vector3(-0.085f, -0.117f, 0.107f);
                //hinge.anchor = transform.localPosition;
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

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            DestroyImmediate(collision.gameObject);
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

    void Reset1()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().mass = 0.01f;
        gameObject.transform.position = cords;
        gameObject.transform.rotation = rotation;
        alreadyHit = false;
        dead = false;
        cords = gameObject.transform.position;
        rotation = gameObject.transform.rotation;
    }

    void Moving1(Vector3 hitInfo)
    {
        gameObject.GetComponent<HingeJoint>().transform.position = hitInfo;
    }
}
