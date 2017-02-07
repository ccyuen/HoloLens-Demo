using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    private float speed = 0.25f;
    private bool notHit;
    private bool limit = false;
    private bool dead;
    private GameObject ChildGameObject1;
    private MeshRenderer child1;
    private GameObject ChildGameObject2;
    private MeshRenderer child2;
    HingeJoint hinge;

    void Start()
    {
        notHit = true;
        dead = false;
        hinge = gameObject.GetComponent<HingeJoint>();
        ChildGameObject1 = gameObject.transform.GetChild(0).gameObject;
        ChildGameObject2 = gameObject.transform.GetChild(1).gameObject;
        child1 = ChildGameObject1.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
        child2 = ChildGameObject2.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
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
            else
            {
                transform.Translate(Vector3.zero, Space.World); // stop movement
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!dead)
        {
            if (collision.gameObject.tag.Equals("Bullet"))
            {
                if (gameObject.tag.Equals("BlueClown"))
                {
                    gameObject.SendMessageUpwards("Blue"); // score
                    notHit = false; // stop update for movement
                }
                else if (gameObject.tag.Equals("RedClown"))
                {
                    gameObject.SendMessageUpwards("Red");

                }
                else if (gameObject.tag.Equals("GreenClown"))
                {
                    gameObject.SendMessageUpwards("Green");
                }
                // turn gravity on for hinge to activate
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().mass = 300;
                dead = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (!dead)
        {
            if (collision.gameObject.tag.Equals("Bullet"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
