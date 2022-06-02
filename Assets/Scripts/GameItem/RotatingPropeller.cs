using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPropeller : MonoBehaviour {

    public int RotatingSpeed = 45;
    
	void Update ()
    {
        transform.Rotate(new Vector3(0, RotatingSpeed, 0) * Time.deltaTime);
    }
}
