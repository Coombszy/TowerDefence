using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

	public int Health = 100;
	public int GoldReward = 15;
	
	public void DealDamage(int Damage)
	{
		Health -= Damage;
		if(Health <1)
		{
			Destroy(this.gameObject);
			GameObject.FindGameObjectWithTag("Base").GetComponent<BaseHandler>().Gold += Random.Range(GoldReward-5, GoldReward+5);
			GameObject.FindGameObjectWithTag("Canvas").GetComponent<TurretPlacer>().UpdateGoldStashBox();
		}
	}
}
