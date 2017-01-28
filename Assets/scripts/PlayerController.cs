using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Sprite playerSprite;
	public PhysicsMaterial2D playerMaterial;
    SpriteRenderer sr;
    Rigidbody2D rb;
    float speed;
    bool exist;
    int jumping;
    float move;
    bool ceilingHead;
	
	static int JUMP_START = 14;
	static float JUMP_MULTI = 12f;


    // Use this for initialization
    void Start() {
        speed = 5f;
        exist = false;
        jumping = 0;
        ceilingHead = false;


    }

    // Update is called once per frame

    void Update()
    {
        if (exist)
        {
            move = Input.GetAxisRaw("Horizontal");
			
            if (Input.GetKeyDown("z") && (jumping == 0) && (Physics2D.Raycast(gameObject.transform.position + (new Vector3(0.5f, -0.6f, 0)), (new Vector3(-1, 0, 0)), 1.0f)))//if on the ground, initiate jump when space pressed
            {
                jumping = JUMP_START;
                ceilingHead = false;
            }
			else if (!Input.GetKey("z")) jumping = 0;
            else if (rb.velocity.y <= 0)
            {
                if (!ceilingHead) ceilingHead = true;
                else jumping = 0;
            }

			 
        }
    }
	
	void FixedUpdate() {
		if (exist) {
			rb.velocity = new Vector3(move * speed, Mathf.Clamp(rb.velocity.y, -100f, 9f), 0);
			
			if(jumping > 0) {
				rb.AddForce(new Vector3(0, 1, 0) * JUMP_MULTI * jumping);
				jumping--;
			}
		}
	}



    public void CreatePlayer()
    {
		
		gameObject.transform.position = new Vector3(-8.5f, 0, 0);
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = playerSprite;
        rb = gameObject.AddComponent<Rigidbody2D>();

        rb.freezeRotation = true;
        exist = true;

        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
		
		
    }
	
	public void ResetPlayer() {
		Destroy(sr);
		Destroy(rb);
		exist = false;
	}
}
