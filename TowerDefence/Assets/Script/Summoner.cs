using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Summoner : MonoBehaviour {
	public GameObject[] EnemyPrefabs;
	public int Quantity = 5;
	public float Offset = 2;
	public bool SpawnOnStart = false;
	public List<GameObject> SpawnedEnemies = new List<GameObject>();

	private
	
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
			SpawnedEnemies.Add(Instantiate(EnemyPrefabs[PickAnEnemy()], CurrentLocation + new Vector3(Random.Range(-Offset,Offset),0,Random.Range(-Offset,Offset)), Quaternion.identity));
		}
	}

	public void WipeWave()
	{
		foreach(GameObject Enemy in SpawnedEnemies)
		{
			Destroy(Enemy,0);
		}
	}

	private int PickAnEnemy()
	{
		int chance = Random.Range(0,100);
		if(0 > chance && chance <20)
		{
			return 2;
		}
		else if(20> chance && chance <45)
		{
			return 1;
		}
		else{
			return 0;
		}
	}
}
