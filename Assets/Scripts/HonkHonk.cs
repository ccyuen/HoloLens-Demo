using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonkHonk : MonoBehaviour {

    public Camera mainCamera;
    public AudioClip honkSound; 

	void OnSelect()
    {
        AudioSource.PlayClipAtPoint(honkSound, mainCamera.transform.position);
    }
}
