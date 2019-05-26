using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    private Rigidbody2D rb;
    public bool grounded;
    public bool onFloor;
    private bool dead;
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead) {
            float hor = Input.GetAxis("Horizontal");

            if (Mathf.Abs(hor) > 0) {
                rb.velocity = new Vector2(speed * Time.deltaTime * hor, rb.velocity.y);
            } else {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            if (Input.GetButtonDown("Jump") && grounded) {
                Jump();
                grounded = false;
                onFloor = false;
            }
        }
    }
    void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Floor") {
            grounded = true;
            onFloor = true;
        }
        if(collision.gameObject.tag == "Plataforma") {
            grounded = true;
            if (onFloor) {
                dead = true;
                gm.playerDead = true;
            }
        }
    }
}
