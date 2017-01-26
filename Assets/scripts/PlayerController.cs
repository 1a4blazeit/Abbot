using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Sprite playerSprite;
    SpriteRenderer sr;
    BoxCollider2D bc;
    Rigidbody2D rb;
    float speed;
    bool exist;
    int jumping;
    Vector3 move;
	
	static int JUMP_START = 9;
	static float JUMP_MULTI = 9.0f;


    // Use this for initialization
    void Start() {
        speed = 0.1f;
        exist = false;
        jumping = 0;

    }

    // Update is called once per frame

    void Update()
    {
        if (exist)
        {
            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            transform.position += move * speed;

       

            if (Input.GetKeyDown("z") && (jumping == 0) && (Physics2D.Raycast(gameObject.transform.position + (new Vector3(0.5f, -0.6f, 0)), (new Vector3(-1, 0, 0)), 1.0f)))//if on the ground, initiate jump when space pressed
            {
                jumping = JUMP_START;
                rb.AddForce(new Vector2(0, JUMP_MULTI*jumping));
            }
            else if (Input.GetKey("z") && (jumping > 0)) //if in midair and holding jump, extend the jump
            {
                jumping = jumping - 1;
                rb.AddForce(new Vector2(0, JUMP_MULTI*jumping));
            }
            else 
            {
                jumping = 0;
            }
			 
        }
    }



    public void CreatePlayer()
    {
		
		gameObject.transform.position = new Vector3(0, 0, 0);
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = playerSprite;
        bc = gameObject.AddComponent<BoxCollider2D>();
        rb = gameObject.AddComponent<Rigidbody2D>();

        rb.freezeRotation = true;
        exist = true;

        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
    }
	
	public void ResetPlayer() {
		Destroy(sr);
		Destroy(bc);
		Destroy(rb);
		exist = false;
	}
}
