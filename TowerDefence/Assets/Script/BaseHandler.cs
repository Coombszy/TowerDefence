using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseHandler : MonoBehaviour {

	public int Health = 1000;
	public int Gold = 100;
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
            Health -= collision.gameObject.GetComponent<HealthManager>().DamageIDeal;
						HealthTextBox.GetComponent<Text>().text = "HP:"+Health;
						Destroy(collision.gameObject);
        }
				if(Health <= 0)
				{
					EndGame();
				}
	}
	public void EndGame()
	{
		SceneManager.LoadScene (2);
	}
}
