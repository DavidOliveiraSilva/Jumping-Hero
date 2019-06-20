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
            if (Input.GetMouseButtonDown(0)) {
                Vector3 pos = Input.mousePosition;
                print(pos);
                Vector3 posWorld = Camera.current.ScreenToWorldPoint(pos);
                Vector3 deltaPos = posWorld - transform.position;
                if (deltaPos.x > reactionRadius || deltaPos.y > reactionRadius) {
                    float angle = Mathf.Atan2(deltaPos.y, deltaPos.x);
                    rb.velocity = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));
                } else {
                    rb.velocity = new Vector2(0, 0);
                }
            }
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        
    }
}
//if (Input.touchCount > 0) {
//Vector2 pos = Input.GetTouch(0).position;