using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class LeverPullDown : MonoBehaviour, IInputClickHandler
{

    public GameObject curtain;
    public GameObject leverHandle;
    private bool rotate;
    public GameObject cylinder;
    private Vector3 A;
    private Vector3 B;
    private Vector3 axis;
    private bool stop;

    // Use this for initialization
    void Start()
    {
        A = cylinder.GetComponent<Renderer>().bounds.center;
        B = cylinder.GetComponent<Renderer>().bounds.center + new Vector3 (-2,0,0);
        axis = B - A;
        rotate = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate && !stop)
        {
            leverHandle.transform.RotateAround(A, axis, 20 * Time.deltaTime);
            curtain.transform.Translate(Vector3.right * 0.15f * Time.deltaTime);
        }

        if (curtain.transform.position.x >= 1.047f)
        {
            stop = true;
            curtain.SetActive(false);
        }
    }

    public virtual void OnInputClicked(InputEventData eventData)
    {
        Debug.Log("Has been selected!");
        rotate = !rotate;
    }
}
