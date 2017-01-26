using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour {

    public GameObject floor;
	GameObject[] floorInstance;
	
	

	// Use this for initialization
	void Start () {
        GameObject.Find("UIModel").GetComponent<UIController>().PrintCenteredText("Press Enter!");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("return"))
        {
            GameObject.Find("UIModel").GetComponent<UIController>().RemoveCenteredText();
            GameObject.Find("PlayerModel").GetComponent<PlayerController>().CreatePlayer();
			
			floorInstance = new GameObject[3];
			
			floorInstance[0] = Instantiate(floor) as GameObject;
			floorInstance[0].GetComponent<Transform>().position = new Vector3(0, -2, 0);
			
			floorInstance[1] = Instantiate(floor) as GameObject;
			floorInstance[1].GetComponent<Transform>().position = new Vector3(4, 1, 0);
			
			floorInstance[2] = Instantiate(floor) as GameObject;
			floorInstance[2].GetComponent<Transform>().position = new Vector3(0, 4, 0);

        }
	}

}
