using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Summoner : MonoBehaviour {
	public GameObject EnemyPrefab;
	public int Quantity = 5;
	public float Offset = 2;
	public bool SpawnOnStart = false;

	private List<GameObject> SpawnedEnemies = new List<GameObject>();
	
	void Start()
	{
		if(SpawnOnStart)
		{
			SpawnWave();
		}
	}

	public void SpawnWave()
	{
		Vector3 CurrentLocation = this.transform.position;
		for(int i = 0; i < Quantity; i++)
		{
			SpawnedEnemies.Add(Instantiate(EnemyPrefab, CurrentLocation + new Vector3(Random.Range(-Offset,Offset),0,Random.Range(-Offset,Offset)), Quaternion.identity));
		}
	}

	public void WipeWave()
	{
		foreach(GameObject Enemy in SpawnedEnemies)
		{
			Destroy(Enemy,0);
		}
	}
}
