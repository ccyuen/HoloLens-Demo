using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {
    static float rotationsPerMinute = 10.0f;
    float rotationAmount = 0;
    
    void Start()
    {
        rotationAmount = rotationsPerMinute * Time.deltaTime;
        this.gameObject.transform.Rotate(rotationAmount, rotationAmount * 2.0f, rotationAmount);
    }
  
    void Update()
    {
        rotationAmount = rotationsPerMinute * Time.deltaTime;
        this.gameObject.transform.Rotate(rotationAmount, rotationAmount * 2.0f, rotationAmount);
    }
}
