using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class LeverPullDown : MonoBehaviour
{

    public GameObject window;
    private bool rotate;

    // Use this for initialization
    void Start()
    {
        rotate = false;
        window.SetActive(false);
        // window game object set false
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {

        }

        //if (gameObject.transform.)
        //{

        //}
        //rotate lever
        //when lever is at certain angle, turn window on
        window.SetActive(false);
    }

    public virtual void OnInputClicked(InputEventData eventData)
    {
        rotate = !rotate;
    }
}
