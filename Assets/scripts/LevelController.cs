using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public GameObject floor;
	GameObject[] floorInstance;
	public GameObject tile;
	GameObject tileInstance;
	
	public GameObject level_1;
	GameObject levelInstance;
	
	bool live;
	
	
	int nextFloor; //track the next array slot that should be used when generating new floors
	int floorHeight; //track the height of the next floor
	public int killPlane; //track the point at which the player should die, as they have no chance of reaching the bottom floor
	float floorHoriz; //temp until random put in; determines next floor horizontal placement
	float platformWidth; // make it a little tougher shall we?

	// Use this for initialization
	void Start () {
		floorInstance = new GameObject[5];
		live = false;
	}
	
	// Update is called once per frame

	
	void Update() {

	}
	
	//deletes the bottom platform and and makes a new one at the top of the "ladder"
	public void makePlatform() {
		Destroy(floorInstance[nextFloor]);
		
		floorInstance[nextFloor] = Instantiate(floor) as GameObject;
		floorInstance[nextFloor].GetComponent<Transform>().position = new Vector3(floorHoriz - 4, floorHeight, 0);
		floorInstance[nextFloor].GetComponent<Transform>().localScale = new Vector3(platformWidth, 1, 1);
		
		floorHoriz = (floorHoriz + 4) % 12;
		floorHeight = floorHeight + 3;
		killPlane = killPlane + 3;
		
		nextFloor = (nextFloor + 1) % 5;
		
		platformWidth = platformWidth * 0.9f;
		
	}
	
	public void GenerateLevel () {
		
		nextFloor = 0;
		floorHeight = -2;
		killPlane = -5;
		floorHoriz = 0.5f;
		platformWidth = 1.0f;
		
		levelInstance = Instantiate(level_1);
		
		live = true;
		
		
	}
	
	public void DeleteLevel() {
		for(int i = 0; i < 5; i++) {
			Destroy(floorInstance[i]);
		}
		Destroy(tileInstance);
		Destroy(levelInstance);
		live = false;
	}
}
