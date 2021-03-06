﻿using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.VR.WSA.Input;

public class CannonBehavior : MonoBehaviour
{
    private GestureRecognizer _gestureRecognizer;

    public float ForceMagnitude = 200f;
    public Material CannonMaterial;
    public AudioSource ShootSound;
    public AudioClip CollisionClip;
    bool shoot = false;

    void Start()
    {
        _gestureRecognizer = new GestureRecognizer();
        _gestureRecognizer.TappedEvent += GestureRecognizerOnTappedEvent;
        _gestureRecognizer.NavigationUpdatedEvent += GestureRecognizerOnNavigationUpdatedEvent;
        _gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.NavigationX | GestureSettings.NavigationY | GestureSettings.NavigationZ);
        _gestureRecognizer.StartCapturingGestures();
    }

    private void GestureRecognizerOnNavigationUpdatedEvent(InteractionSourceKind source, Vector3 normalizedOffset, Ray headRay)
    {
        Debug.LogFormat("Nav Upd: {0} Offset: {1}", Enum.GetName(typeof(InteractionSourceKind), source), normalizedOffset);
    }

    private void GestureRecognizerOnTappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        if (shoot) Shoot();      
    }

    public void enableShoot()
    {
        shoot = true;
    }

    public void disableShoot()
    {
        shoot = false;
    }


    public void Shoot()
    {
        //    ShootSound.Play();

        var eyeball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        eyeball.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        eyeball.GetComponent<Renderer>().material = CannonMaterial;
        

        var rigidBody = eyeball.AddComponent<Rigidbody>();
        rigidBody.mass = 0.5f;
        rigidBody.position = transform.position;
        var forward = transform.forward;
        forward = Quaternion.AngleAxis(-10, transform.right) * forward;
        rigidBody.AddForce(forward * ForceMagnitude);
        eyeball.tag = "Bullet";
        eyeball.AddComponent<AudioCollisionBehaviour>().SoundSoftCrash = CollisionClip;
    }

    private void OnDestroy()
    {
        if (_gestureRecognizer != null)
        {
            if (_gestureRecognizer.IsCapturingGestures())
            {
                _gestureRecognizer.StopCapturingGestures();
            }
            _gestureRecognizer.Dispose();
        }
    }
}
