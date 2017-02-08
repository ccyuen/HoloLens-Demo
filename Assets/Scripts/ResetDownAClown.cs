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
    private bool color;

    void Start()
    {
        color = false;
        cords = transform.parent.gameObject.transform.position;
        rotation = transform.parent.gameObject.transform.rotation;
    }

    void Update()
    {
        if (color)
            reset.color = Color.yellow;
        else
            reset.color = Color.white;

        color = false;
    }

    void Reset2()
    {
        color = true;
    }
            

    public virtual void OnInputClicked(InputEventData eventData)
    {
        // On each Select gesture, reset the game
        gameObject.SendMessageUpwards("Reset");
    }
}
