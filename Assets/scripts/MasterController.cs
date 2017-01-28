using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour {
	
	bool begun;
	
	string startMessage;

	// Use this for initialization
	void Start () {
		startMessage = "Press Enter!";
		begun = false;
        GameObject.Find("UIModel").GetComponent<UIController>().PrintCenteredText(startMessage);
	}
	
	// Update is called once per frame
	void Update () {
		if (!begun && Input.GetKeyDown("return"))
        {
            GameObject.Find("UIModel").GetComponent<UIController>().RemoveCenteredText();
            GameObject.Find("PlayerModel").GetComponent<PlayerController>().CreatePlayer();
			GameObject.Find("LevelModel").GetComponent<LevelController>().GenerateLevel();
            GameObject.Find("CameraModel").GetComponent<CameraController>().ReadyCamera();
			begun = true;

        }
		
		else if(begun && Input.GetKeyDown("return")) {
			OnReset();
		}
	}
	
	void FixedUpdate() {
	}

    public void DeathRequest()
    {
        startMessage = "You died!";
        OnReset();
    }
	
	void OnReset () { //reset gamestate to start position
		begun = false;
		GameObject.Find("UIModel").GetComponent<UIController>().PrintCenteredText(startMessage);
		startMessage = "Press Enter!";
		
		GameObject.Find("PlayerModel").GetComponent<PlayerController>().ResetPlayer();
		
		GameObject.Find("LevelModel").GetComponent<LevelController>().DeleteLevel();
		
		GameObject.Find("CameraModel").GetComponent<CameraController>().ResetCamera();
		
		
	}
	
	public void FinishedLevel() {
		startMessage = "You did it!";
		OnReset();
	}

}
