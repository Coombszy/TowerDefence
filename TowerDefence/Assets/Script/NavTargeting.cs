using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavTargeting : MonoBehaviour {
	public GameObject Target;//where it is traveling too

	private NavMeshAgent NavComponent;

	// Use this for initialization
	void Start () {
		NavComponent = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Target)//is target there
		{
			NavComponent.SetDestination(Target.transform.position);
		}
	}
}
