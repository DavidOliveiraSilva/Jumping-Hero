using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float multiplier;
    private BoxCollider2D bc;

    //[gambis]
    private GameObject player;
    //[/gambis]

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed*multiplier);
        bc = GetComponent<BoxCollider2D>();
        //[gambis]
        player = GameObject.Find("Player");
        //[/gambis]
    }

    // Update is called once per frame
    void Update()
    {
        //[gambis]
        if(player != null) {
            if(player.transform.position.y > transform.position.y + 1) {
                bc.enabled = true;
            } else {
                bc.enabled = false;
            }
        }
        //[/gambis]
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Destroyer") {
            AutoDestroy();
        }
    }
    void AutoDestroy() {
        Destroy(gameObject);
    }
}
