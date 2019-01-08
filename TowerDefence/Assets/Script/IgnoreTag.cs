using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTag : MonoBehaviour {
	public string TagToIgnore;
	public GameObject PrefabToIgnore;

	void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag == TagToIgnore)
        {
					//Debug.Log("Boop!");
            Physics.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider>(), this.gameObject.GetComponent<BoxCollider>());
        }
	}

	void Start () {
		Physics.IgnoreCollision(this.gameObject.GetComponent<BoxCollider>(), PrefabToIgnore.GetComponent<BoxCollider>());
		Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), PrefabToIgnore.GetComponent<Collider>());
		Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), PrefabToIgnore.GetComponent<BoxCollider>());
		}
}
