using UnityEngine;
using System.Collections;

public class RoundController : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public int BaseHazardCount = 10;
    public float spawnWait = 0.075f;
    public float startWait = 5;
    public float waveWait = 12;
	public float Offset = 2.5f;
	public float MultiRate = 10;
	
	private int Round;
	private Vector3 CurrentLocation;
	private int hazardCount;

    void Start ()
    {
		CurrentLocation = this.gameObject.transform.position;
		Round = 0;
        StartCoroutine (SpawnWaves ());
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
			Round++;
            for (int i = 0; i < hazardCount; i++)
            {
				Instantiate(EnemyPrefabs[PickAnEnemy()], CurrentLocation + new Vector3(Random.Range(-Offset,Offset),0,Random.Range(-Offset,Offset)), Quaternion.identity);
                yield return new WaitForSeconds (spawnWait);
            }
			hazardCount = Mathf.FloorToInt(Mathf.Pow(BaseHazardCount ,(1f+(Round/10f))));
            yield return new WaitForSeconds (waveWait);
        }
    }
	
	private int PickAnEnemy()
	{
		int chance = Random.Range(0,100);
		float Modifier = 1;
		if((Round/MultiRate) >= 1){Modifier = 1 + (Round/100);}
		else{Modifier = Round/MultiRate;}

		if(100 > chance && chance > 100 - (5*Modifier) )
		{
			return 2;
		}
		else if(85 > chance && chance > 85 - (35*Modifier) )
		{
			return 1;
		}
		else{
			return 0;
		}
	}
}
