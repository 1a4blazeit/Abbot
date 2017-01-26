using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour {
	
	bool begun;

	// Use this for initialization
	void Start () {
		begun = false;
        GameObject.Find("UIModel").GetComponent<UIController>().PrintCenteredText("Press Enter!");
	}
	
	// Update is called once per frame
	void Update () {
		if (!begun && Input.GetKeyDown("return"))
        {
            GameObject.Find("UIModel").GetComponent<UIController>().RemoveCenteredText();
            GameObject.Find("PlayerModel").GetComponent<PlayerController>().CreatePlayer();
			GameObject.Find("LevelModel").GetComponent<LevelController>().GenerateLevel();
			GameObject.Find("CameraModel").GetComponent<CameraController>().mobile = true;
			begun = true;

        }
		
		else if(begun && Input.GetKeyDown("return")) {
			OnReset();
		}
	}
	
	void OnReset () { //reset gamestate to start position
		begun = false;
		GameObject.Find("UIModel").GetComponent<UIController>().PrintCenteredText("Press Enter!");
		
		GameObject.Find("PlayerModel").GetComponent<PlayerController>().ResetPlayer();
		
		GameObject.Find("LevelModel").GetComponent<LevelController>().DeleteLevel();
		
		GameObject.Find("CameraModel").GetComponent<CameraController>().mobile = false;
		GameObject.Find("CameraModel").GetComponent<Transform>().position = new Vector3(0,0,-10);
		
	}

}
