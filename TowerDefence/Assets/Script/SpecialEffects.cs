using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour {

	public bool ExplodeOnDeath = false; public float Offset = 0.5f; public int Children = 5; public GameObject Child;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{
		if(ExplodeOnDeath)
		{
			Vector3 CurrentLocation = this.transform.position;
			for(int i = 0; i < Children; i++)
			{
				Instantiate(Child, CurrentLocation + new Vector3(Random.Range(-Offset,Offset),0,Random.Range(-Offset,Offset)), Quaternion.identity);
			}
		}
	}
}
