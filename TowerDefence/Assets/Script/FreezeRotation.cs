using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour {

 	Rigidbody ObjectsRigidbody;
	void Start () {
		ObjectsRigidbody = GetComponent<Rigidbody>();
    ObjectsRigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
	}
	
}
