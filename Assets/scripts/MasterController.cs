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
			begun = true;

        }
	}

}
