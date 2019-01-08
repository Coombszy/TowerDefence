using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

	public int Health = 100;
	
	public void DealDamage(int Damage)
	{
		Health =- Damage;
		if(Health <1)
		{
			Destroy(this.gameObject);
		}
	}
}
