using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Sprite playerSprite;
	public PhysicsMaterial2D playerMaterial;
    public RuntimeAnimatorController playerAnimation;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator an;
    float speed;
    bool exist;
    int jumping;
    float move;
    bool ceilingHead;
    int currentAnimationState;
	
	static int JUMP_START = 14;
	static float JUMP_MULTI = 8.5f;


    // Use this for initialization
    void Start() {
        speed = 5f;
        exist = false;
        jumping = 0;
        ceilingHead = false;
        currentAnimationState = 0;


    }

    // Update is called once per frame

    void Update()
    {
        if (exist)
        {
            move = Input.GetAxisRaw("Horizontal");
            if (Input.GetKey("right"))
            {
                ChangeState(1);
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (Input.GetKey("left"))
            {
                ChangeState(1);
                gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else ChangeState(0);
			
            if (Input.GetKeyDown("z") && (jumping == 0) && (Physics2D.Raycast(gameObject.transform.position + (new Vector3(0.375f, -0.6f, 0)), (new Vector3(-1, 0, 0)), 0.75f)))//if on the ground, initiate jump when space pressed
            {
                jumping = JUMP_START;
                ceilingHead = false;
                GameObject.Find("AudioModel").GetComponent<AudioController>().PlayJump();
            }
			else if (!Input.GetKey("z")) jumping = 0;
            else if (rb.velocity.y <= 0)
            {
                if (!ceilingHead) ceilingHead = true;
                else jumping = 0;
            }
            if (jumping > 0)
            {
                ChangeState(2);
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

    void ChangeState(int state)
    {
        if (currentAnimationState == state) return;

        else {
            gameObject.GetComponent<Animator>().SetInteger("state", state);
            currentAnimationState = state; 
        }
    }



    public void CreatePlayer()
    {
		
		gameObject.transform.position = new Vector3(-8.5f, 0, 0);
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = playerSprite;
        an = gameObject.AddComponent<Animator>();
        an.runtimeAnimatorController = playerAnimation;
        rb = gameObject.AddComponent<Rigidbody2D>();

        rb.freezeRotation = true;
        exist = true;

        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
		
		
    }
	
	public void ResetPlayer() {
        Destroy(an);
        Destroy(sr);
		Destroy(rb);
		exist = false;
	}
}
