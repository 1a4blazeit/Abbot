using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public GameObject floor;
	GameObject[] floorInstance;
	
	int nextFloor; //track the next array slot that should be used when generating new floors
	int floorHeight; //track the height of the next floor
	int killPlane; //track the point at which the player should die, as they have no chance of reaching the bottom floor
	int floorHoriz; //temp until random put in; determines next floor horizontal placement

	// Use this for initialization
	void Start () {
		floorInstance = new GameObject[5];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void GenerateLevel () {
		
		nextFloor = 0;
		floorHeight = -2;
		killPlane = -5;
		floorHoriz = 4;
		
		for(int i = 0; i < 5; i++) {
			floorInstance[i] = Instantiate(floor) as GameObject;
			floorInstance[i].GetComponent<Transform>().position = new Vector3(floorHoriz - 4, floorHeight, 0);
		
			floorHoriz = (floorHoriz + 4) % 12;
			floorHeight = floorHeight + 3;
		}
		
		
	}
	
	public void DeleteLevel() {
		for(int i = 0; i < 5; i++) {
			Destroy(floorInstance[i]);
		}
	}
}
