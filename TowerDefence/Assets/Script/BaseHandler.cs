using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHandler : MonoBehaviour {

	public int Health = 1000;
	public string EnemyTag = "Enemy";
	public GameObject HealthTextBox;

	void Start()
	{
		HealthTextBox.GetComponent<Text>().text = "HP:"+Health;
	}
	void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag == EnemyTag)
        {
            Health -= 1;
						HealthTextBox.GetComponent<Text>().text = "HP:"+Health;
						Destroy(collision.gameObject);
        }
	}
}
