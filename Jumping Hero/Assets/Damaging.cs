using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    private GameMaster gm;
    public int damage;
    public bool autodestroy;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AutoDestroy() {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (gm.playing) {
            if (collision.gameObject.tag == "Player") {
                float dy = transform.position.y - collision.transform.position.y;
                float dx = transform.position.x - collision.transform.position.x;
                float angle = Mathf.Atan2(dy, dx);
                bool success = collision.gameObject.GetComponent<Player>().TakeDamage(damage, angle + Mathf.PI);
                if (success && autodestroy) {
                    AutoDestroy();
                }
            }
        }
    }
}
