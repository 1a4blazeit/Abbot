using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Sprite playerSprite;
    SpriteRenderer sr;
    PolygonCollider2D pc;
    Rigidbody2D rb;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate()
    {

    }

    public void CreatePlayer()
    {
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = playerSprite;
        pc = gameObject.AddComponent<PolygonCollider2D>();
        rb = gameObject.AddComponent<Rigidbody2D>();
    }
}
