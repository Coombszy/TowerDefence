    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class TurretPlacer : MonoBehaviour {
        public GameObject[] objectsToSpawn = new GameObject[]{};
        public int TypeNum = 0;
        public GameObject TurretTypeBox;
        public GameObject PlayerBase;
        public GameObject GoldStashBox;
        public GameObject GameCamera;

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
            //Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);spawnPosition.y = 0.0f; // USE THIS FOR ORTHOGRAPHIC CAMERA TYPE
            Vector2 MousePos = Input.mousePosition;
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, Camera.main.transform.position.y));
            if(isLocationSafe(spawnPosition))
            {
                if(PlayerBase.GetComponent<BaseHandler>().Gold-objectsToSpawn[Type].GetComponent<TurretHandler>().Cost >= 0)
                {
                    Instantiate(objectsToSpawn[Type], spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                    PlayerBase.GetComponent<BaseHandler>().Gold = PlayerBase.GetComponent<BaseHandler>().Gold-objectsToSpawn[Type].GetComponent<TurretHandler>().Cost;
                    UpdateGoldStashBox();
                }
            }
        }
        private void UpdateTurretTypeBox()
        {
            TurretTypeBox.GetComponent<Text>().text = "TurrType:"+TypeNum;
        }
        public void UpdateGoldStashBox()
        {
            GoldStashBox.GetComponent<Text>().text= "GoldStash:"+PlayerBase.GetComponent<BaseHandler>().Gold;
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
                    Range = Object.GetComponent<TurretHandler>().PlaceRange;
                    if(objectsToSpawn[TypeNum].GetComponent<TurretHandler>().PlaceRange > Range)
                    {
                        Range = objectsToSpawn[TypeNum].GetComponent<TurretHandler>().PlaceRange;
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