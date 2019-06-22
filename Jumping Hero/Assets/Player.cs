using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private bool dead;
    private GameMaster gm;
    public float reactionRadius;
    public bool pressing;
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

            //using mouse
            if (Input.GetMouseButtonDown(0)) {
                pressing = true;
            }
            if(Input.GetMouseButtonUp(0)){
                pressing = false;
            }

            //using touch
            if (Input.touchCount > 0) {
                pressing = true;
            } else {
                pressing = false;
            }

            if (pressing) {
                //using mouse
                //Vector3 pos = Input.mousePosition;

                //using touch
                Vector2 pos = Input.GetTouch(0).position;

                Vector3 posWorld = Camera.main.ScreenToWorldPoint(pos);
                Vector3 deltaPos = posWorld - transform.position;
                float dist = distance(posWorld, transform.position);
                if (dist > reactionRadius) {
                    float angle = Mathf.Atan2(deltaPos.y, deltaPos.x);
                    rb.velocity = new Vector2(speed * Mathf.Cos(angle)*Mathf.Sqrt(dist - reactionRadius), speed * Mathf.Sin(angle) * Mathf.Sqrt(dist - reactionRadius));
                } else {
                    rb.velocity = new Vector2(0, 0);
                }
            } else {
                rb.velocity = new Vector2(0, 0);
            }
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        
    }
    private float distance(Vector2 first, Vector2 second) {
        return Mathf.Sqrt(Mathf.Pow(first.x - second.x, 2) + Mathf.Pow(first.y - second.y, 2));
    }
}
//if (Input.touchCount > 0) {
//Vector2 pos = Input.GetTouch(0).position;