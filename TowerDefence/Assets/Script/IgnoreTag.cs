using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTag : MonoBehaviour {
	public string TagToIgnore;
	void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag == TagToIgnore)
        {
					
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.GetComponent<Collider>());
        }
	}
}
