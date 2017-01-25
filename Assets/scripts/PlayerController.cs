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
    bool grounded;
    int jumping;
    Vector3 move;



    // Use this for initialization
    void Start() {
        speed = 0.1f;
        exist = false;
        grounded = false;
        jumping = 0;
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate()
    {
        if (exist)
        {
            move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            transform.position += move * speed;

            if (rb.velocity.y == 0) grounded = true;
            else grounded = false;

            if (Input.GetKeyDown("space") && grounded && (jumping == 0)) //if on the ground, initiate jump when space pressed
            {
                jumping = 10;
                rb.AddForce(new Vector2(0, 6*jumping));
            }
            else if (Input.GetKey("space") && (jumping > 0)) //if in midair and holding space, extend the jump
            {
                jumping = jumping - 1;
                rb.AddForce(new Vector2(0, 6*jumping));
            }
            else if ((jumping != 0))//when space is released stop extending jump
            {
                jumping = 0;
            }
        }
    }

    public void CreatePlayer()
    {
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = playerSprite;
        bc = gameObject.AddComponent<BoxCollider2D>();
        rb = gameObject.AddComponent<Rigidbody2D>();

        rb.freezeRotation = true;
        exist = true;
    }
}
