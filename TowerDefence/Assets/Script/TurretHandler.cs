using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretHandler : MonoBehaviour {

	public int Cost = 30;
	public int Range = 10;
	public float PlaceRange = 0.4f;
	public GameObject Summoner = null;
	public bool TargetAcquired = false;
	public GameObject CurrentTarget = null;

	private Vector3 MyLocation = new Vector3();

	// Use this for initialization
	void Start () {
		MyLocation = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(CurrentTarget == null)
		{
			CalculateNewTarget();
		}
		else{
			Vector3 directionToTarget = CurrentTarget.transform.position - MyLocation;
    	float DistanceToTarget = directionToTarget.sqrMagnitude;
			if(DistanceToTarget > Range)
			{
				CalculateNewTarget();
			}
		}

	}

	public void CalculateNewTarget()
	{
		TargetAcquired = false;
		GameObject[] Targets = GameObject.FindGameObjectsWithTag("Enemy");
		if(Targets != null && Targets.Length != 0)
		{
			GameObject BestTarget = null;
			float BestTargetRange = Mathf.Infinity;
			foreach(GameObject Enemy in Targets)
			{
				Vector3 directionToTarget = Enemy.transform.position - MyLocation;
    		float DistanceToTarget = directionToTarget.sqrMagnitude;
				if (DistanceToTarget < BestTargetRange && DistanceToTarget < Range)
				{
					BestTarget = Enemy;
					BestTargetRange = DistanceToTarget;
				}
			}
			CurrentTarget = BestTarget;
			if (BestTarget == null){TargetAcquired = false;}
			else {TargetAcquired = true;}
		}
	}
}
