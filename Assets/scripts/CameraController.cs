using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public bool mobile;
	public bool advance;
	public bool retreat;

	// Use this for initialization
	void Start () {
		mobile = false;
		advance = false;
	}
	
	void FixedUpdate () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (mobile) {
			if(GameObject.Find("PlayerModel").GetComponent<Transform>().position.x - gameObject.transform.position.x > 3) {
				advance = true;
			}
			else if (GameObject.Find("PlayerModel").GetComponent<Transform>().position.x - gameObject.transform.position.x < 1) {
				advance = false;
			}
			
			if((gameObject.transform.position.x > 0) && (GameObject.Find("PlayerModel").GetComponent<Transform>().position.x - gameObject.transform.position.x < -3)) {
				retreat = true;
			}
			else if ((gameObject.transform.position.x <= 0) || (GameObject.Find("PlayerModel").GetComponent<Transform>().position.x - gameObject.transform.position.x > -1)) {
				retreat = false;
			}
			
			if(advance) {
				gameObject.transform.position += new Vector3 (0.08f, 0, 0);
			}
			else if(retreat) {
				gameObject.transform.position -= new Vector3 (0.08f, 0, 0);
			}
		
		}
	}
}
