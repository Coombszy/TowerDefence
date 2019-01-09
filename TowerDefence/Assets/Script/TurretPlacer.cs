    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class TurretPlacer : MonoBehaviour {
        public GameObject[] objectsToSpawn = new GameObject[]{};
        public int TypeNum = 0;
        public GameObject TurretTypeBox;
        // Use this for initialization
        void Start () {
        
        }
        void Update () {
            if (Input.GetMouseButtonDown(0))
            {
                if(EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                Summon(TypeNum);
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                TypeNum++;
                if(objectsToSpawn.Length == TypeNum)
                {
                    TypeNum = 0;
                }
                UpdateTurretTypeBox();
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                TypeNum--;
                if(TypeNum < 0)
                {
                    TypeNum = (objectsToSpawn.Length-1);
                }
                UpdateTurretTypeBox();
            }
        }
        private void Summon(int Type)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);spawnPosition.y = 0.0f;
            if(isLocationSafe(spawnPosition))
            {
                Instantiate(objectsToSpawn[Type], spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
        }

        private void UpdateTurretTypeBox()
        {
            TurretTypeBox.GetComponent<Text>().text = "TurrType:"+TypeNum;
        }

        private bool isLocationSafe(Vector3 Location)
	    {
            List<GameObject> Targets = new List<GameObject>();
            bool Safe = true;
            Targets.AddRange(GameObject.FindGameObjectsWithTag("Tower"));
            //Targets.AddRange(GameObject.FindGameObjectsWithTag("Floor"));
		    if(Targets != null && Targets.Count != 0)
		    {
			    foreach(GameObject Object in Targets)
			    {
				    Vector3 directionToTarget = Object.transform.position - Location;
    		        float DistanceToTarget = directionToTarget.sqrMagnitude;
                    float Range;
                    Range = Object.GetComponent<TurretTargeting>().PlaceRange;
                    if(objectsToSpawn[TypeNum].GetComponent<TurretTargeting>().PlaceRange > Range)
                    {
                        Range = objectsToSpawn[TypeNum].GetComponent<TurretTargeting>().PlaceRange;
                    }
				    if (DistanceToTarget < Range)
				    {
					    Safe = false;
				    }
			    }
		    }
            Collider[] colliders = Physics.OverlapSphere(Location,0.1f);
			if (colliders.Length != 1)
			{
				Safe = false;
			}
            return Safe;
	    }
} 