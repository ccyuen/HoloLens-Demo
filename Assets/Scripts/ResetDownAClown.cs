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

    void Update()
    {
        reset.color = Color.white;
    }

    void Reset2()
    {
        reset.color = Color.yellow;
    }
            

    public virtual void OnInputClicked(InputEventData eventData)
    {
        // On each Select gesture, reset the game
        gameObject.SendMessageUpwards("Reset");
    }
}
