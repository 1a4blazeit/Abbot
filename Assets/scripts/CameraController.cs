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
	void FixedUpdate () {
		if(mobile) {
			transform.position += new Vector3(0, 0.02f, 0);
		}
	}
}
