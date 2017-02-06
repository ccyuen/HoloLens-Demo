using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBallKick : MonoBehaviour {

    bool selected = false;
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;

    void OnSelect ()
    {
        selected = !selected;
    }

	// Update is called once per frame
	void Update () {
        CharacterController ball = GetComponent<CharacterController>();
        // if user has selected the ball then move it up, else let gravity pull it down
        if (selected)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            float curSpeed = speed * Input.GetAxis("Vertical");
            ball.SimpleMove(forward * curSpeed);
        }
    }
}
