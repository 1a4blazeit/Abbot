using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public bool mobile;

	// Use this for initialization
	void Start () {
		mobile = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(mobile) {
			transform.position = new Vector3(GameObject.Find("PlayerModel").GetComponent<Transform>().position.x, 0, -10);
		}
	}
}
