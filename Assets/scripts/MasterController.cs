using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("UIModel").GetComponent<UIController>().PrintCenteredText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
