using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour 
{
    // not using forces so update is better than fixed update
	void Update () 
    {
        // any object that rotates should have a RigidBody component otherwise performance will suffer
		transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
	}
}
