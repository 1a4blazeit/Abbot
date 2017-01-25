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
    Vector3 move;



    // Use this for initialization
    void Start() {
        speed = 0.1f;
        exist = false;
        grounded = false;
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

            if (Input.GetKeyDown("space") && grounded)
            {
                rb.AddForce(new Vector2(0, 500));
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
