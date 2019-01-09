using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

public string EnemyTag = "Enemy";
public int DamageIDeal = 50;
public float Speed = 0.0005f;
public float DecayTime = 4f;

private float Timer = 0;


void Start()
{
	this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * Speed;
}

void Update()
{
	Timer += Time.deltaTime;
	if(Timer> DecayTime)
	{
		Destroy(this.gameObject);
	}
}

void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == EnemyTag)
        {
					Destroy(this.gameObject);
					collision.gameObject.GetComponent<HealthManager>().DealDamage(DamageIDeal);
				}
				else{
					Destroy(this.gameObject);
				}	
	}
}
