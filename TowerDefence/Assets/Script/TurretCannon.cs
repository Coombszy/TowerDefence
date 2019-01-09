using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCannon : MonoBehaviour {
	
	public float ShotsPerSecond = 1f;
	public float TurnSpeed = 100f;
	public GameObject Bullet;

	private float Timer;

	// Use this for initialization
	void Start () {
		Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if(this.gameObject.GetComponent<TurretTargeting>().CurrentTarget != null && this.gameObject.GetComponent<TurretTargeting>().TargetAcquired)
		{
			if(Timer > 1/ShotsPerSecond){
			Timer = 0;
			Vector3 targetDir = this.gameObject.GetComponent<TurretTargeting>().CurrentTarget.transform.position - this.gameObject.transform.position;
			float step = TurnSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(this.gameObject.transform.forward, targetDir, step, 0.0f);
      //Debug.DrawRay(this.gameObject.transform.position, newDir, Color.red,2);

      // Move position a step closer to the target.
      Quaternion Temp = Quaternion.LookRotation(newDir);
			this.gameObject.transform.rotation = new Quaternion(0, Temp.y, 0, Temp.w);

			Instantiate(Bullet, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.6f,this.gameObject.transform.position.z), this.gameObject.transform.rotation);
			}
		}
	}
}
