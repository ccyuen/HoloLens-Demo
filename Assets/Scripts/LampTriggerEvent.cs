using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTriggerEvent : MonoBehaviour {

    private Vector3 position;
    public Camera mainCamera;
    public AudioClip switchOn;
    public AudioClip switchOff;

    void Start()
    {
        position = gameObject.transform.position;
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, position.x, position.x), Mathf.Clamp(gameObject.transform.position.y, position.y, position.y), Mathf.Clamp(gameObject.transform.position.z, position.z, position.z));
    }

    //public GameObject light;
    // when the cube first touches the lamp
    void OnCollisionEnter(Collision object2)
    {
        // if the tag of the colliding object is equal to RedCube then trigger an event else do nothing
        if (object2.gameObject.tag.Equals("RedCube"))
        {
            // send a message to the redcube to say that the lamp has collided with the redcube
            gameObject.SendMessageUpwards("isTouching");
            AudioSource.PlayClipAtPoint(switchOn, mainCamera.transform.position);
        }
    }

    // while the cube stays on the lamp
    void OnCollisionStay(Collision object2)
    {
        // if the tag of the colliding object is equal to RedCube then trigger an event else do nothing
        if (object2.gameObject.tag.Equals("RedCube"))
        {
            // send a message to the redcube to say that the lamp is colliding with the redcube
            gameObject.SendMessageUpwards("isTouching");
        }
    }

    // when the cube is off the lamp
    void OnCollisionExit(Collision object2)
    {
        // if the tab of the colliding object is equal to RedCube then trigger an event else do nothing
        if (object2.gameObject.tag.Equals("RedCube"))
        {
            // send a message to the redcube to say that the lamp is no longer colliding with the redcube
            gameObject.SendMessageUpwards("isNotTouching");
            AudioSource.PlayClipAtPoint(switchOff, mainCamera.transform.position);
        }
    }
}
