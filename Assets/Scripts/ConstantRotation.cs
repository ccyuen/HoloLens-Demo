using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {
    static float rotationsPerMinute = 10.0f;
    float rotationAmount = rotationsPerMinute * Time.deltaTime;

    void Start()
    {
        this.gameObject.transform.Rotate(rotationAmount, rotationAmount * 2.0f, rotationAmount);
    }
  
    void Update()
    {
       this.gameObject.transform.Rotate(rotationAmount, rotationAmount * 2.0f, rotationAmount);
    }
}
