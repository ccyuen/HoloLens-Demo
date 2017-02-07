using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ResetDownAClown : MonoBehaviour, IInputClickHandler
{

    public GameObject game;
    public TextMesh reset;
    private Vector3 cords = new Vector3();
    private Quaternion rotation;

    void Start()
    {
        cords = transform.parent.gameObject.transform.position;
        rotation = transform.parent.gameObject.transform.rotation;
    }

    void OnCollisionEnter(Collision object2)
    {
        // if the tag of the colliding object is equal to RedCube then trigger an event else do nothing
        if (object2.gameObject.tag.Equals("Cursor"))
        {
            reset.color = Color.yellow;
        }
    }

    // while the cube stays on the lamp
    void OnCollisionStay(Collision object2)
    {
        // if the tag of the colliding object is equal to RedCube then trigger an event else do nothing
        if (object2.gameObject.tag.Equals("Cursor"))
        {
            reset.color = Color.yellow;
        }
    }

    // when the cube is off the lamp
    void OnCollisionExit(Collision object2)
    {
        // if the tab of the colliding object is equal to RedCube then trigger an event else do nothing
        if (object2.gameObject.tag.Equals("Cursor"))
        {
            reset.color = Color.white;
        }
    }


    public virtual void OnInputClicked(InputEventData eventData)
    {
        // On each Select gesture, reset the game
        Destroy(transform.parent.gameObject);
        Instantiate(game, cords, rotation);
    }
}
