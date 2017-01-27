using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public GameObject floor;
	GameObject[] floorInstance;
	public GameObject tile;
	GameObject tileInstance;
	
	bool live;
	
	
	int nextFloor; //track the next array slot that should be used when generating new floors
	int floorHeight; //track the height of the next floor
	public int killPlane; //track the point at which the player should die, as they have no chance of reaching the bottom floor
	int floorHoriz; //temp until random put in; determines next floor horizontal placement
	float platformWidth; // make it a little tougher shall we?

	// Use this for initialization
	void Start () {
		floorInstance = new GameObject[5];
		live = false;
	}
	
	// Update is called once per frame

	
	void Update() {
		if(live && floorInstance[nextFloor].GetComponent<Transform>().position.y < GameObject.Find("CameraModel").GetComponent<Transform>().position.y - 7) {
			makePlatform();
		}
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
		floorHoriz = 4;
		platformWidth = 1.0f;
		
		for(int i = 0; i < 5; i++) {
			floorInstance[i] = Instantiate(floor) as GameObject;
			floorInstance[i].GetComponent<Transform>().position = new Vector3(floorHoriz - 4, floorHeight, 0);
		
			floorHoriz = (floorHoriz + 4) % 12;
			floorHeight = floorHeight + 3;
		}
		
		live = true;
		
		
	}
	
	public void DeleteLevel() {
		for(int i = 0; i < 5; i++) {
			Destroy(floorInstance[i]);
		}
		live = false;
	}
}
