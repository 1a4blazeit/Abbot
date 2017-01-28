using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	bool mobile;
	bool advance;
	bool retreat;
	bool up;
	bool down;

    Vector3 playerPosition;


	// Use this for initialization
	void Start () {
		mobile = false;
		advance = false;
        retreat = false;
        up = false;
        down = false;
	}
	
	void FixedUpdate () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (mobile) {
            playerPosition = GameObject.Find("PlayerModel").GetComponent<Transform>().position;


            if (playerPosition.x - gameObject.transform.position.x > 2) {
                advance = true;
            }
            else if (playerPosition.x - gameObject.transform.position.x < 1) {
                advance = false;
            }

            if ((gameObject.transform.position.x > 0) && (playerPosition.x - gameObject.transform.position.x < -2)) {
                retreat = true;
            }
            else if ((gameObject.transform.position.x <= 0) || (playerPosition.x - gameObject.transform.position.x > -1)) {
                retreat = false;
            }

            if (playerPosition.y - gameObject.transform.position.y > 2) {
                up = true;
            }
            else if (playerPosition.y - gameObject.transform.position.y < 1) {
                up = false;
            }

            if ((gameObject.transform.position.y > 0.5) && (playerPosition.y - gameObject.transform.position.y <= -1)) {
                down = true;
            }
            else if ((gameObject.transform.position.y <= 0.5) || (playerPosition.y - gameObject.transform.position.y > -1)) {
                down = false;
            }

            if (advance) {
                gameObject.transform.position += new Vector3(Mathf.Clamp(1.9f * (playerPosition.x - gameObject.transform.position.x) * Time.deltaTime, 0.07f, 1.5f), 0, 0);
            }
            else if (retreat)
            {
                gameObject.transform.position += new Vector3(Mathf.Clamp(1.9f * (playerPosition.x - gameObject.transform.position.x) * Time.deltaTime, -1.5f, -0.07f), 0, 0);
            }
			
			if(up) {
				gameObject.transform.position += new Vector3 (0, 7f * Time.deltaTime, 0);
			}
			else if (down) {
				gameObject.transform.position -= new Vector3 (0, 7f * Time.deltaTime, 0);
			}

		
		}
	}

    public void ReadyCamera()
    {
        mobile = true;
        advance = false;
        retreat = false;
        up = false;
        down = false;
    }

    public void ResetCamera()
    {
        mobile = false;
        gameObject.transform.position = new Vector3(0, 0, -10);
    }
}
