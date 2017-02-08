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
    public AudioClip lever;
    public Camera mainCamera;
    private Vector3 A;
    private Vector3 B;
    private Vector3 axis;
    private bool stop;
    private bool playSoundOnce;
    private float totalAngle;

    // Use this for initialization
    void Start()
    {
        totalAngle = 0;
        playSoundOnce = true;
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
            if (playSoundOnce)
            {
                AudioSource.PlayClipAtPoint(lever, mainCamera.transform.position, 0.8f);
                playSoundOnce = false;
            }
            leverHandle.transform.RotateAround(A, axis, 100 * Time.deltaTime);
            totalAngle += 100 * Time.deltaTime;
        }

        if (totalAngle > 120)
        {
            stop = true;
            curtain.transform.Translate(Vector3.right * 0.15f * Time.deltaTime);
            if (curtain.transform.position.x >= 1.047f)
                curtain.SetActive(false);
        }
    }

    public virtual void OnInputClicked(InputEventData eventData)
    {
        Debug.Log("Has been selected!");
        rotate = true;
    }
}
