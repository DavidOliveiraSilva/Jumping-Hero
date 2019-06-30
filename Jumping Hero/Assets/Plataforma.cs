using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float multiplier;
    private BoxCollider2D bc;
    private GameMaster gm;

    //[gambis]
    private GameObject player;
    //[/gambis]

    public GameObject[] coisas;
    [Range(0.0f, 1.0f)]
    public float probabilidade;
    public bool started;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        rb = GetComponent<Rigidbody2D>();
        
        bc = GetComponent<BoxCollider2D>();
        
        
    }
    void ActionStart() {
        rb.velocity = new Vector2(0, -speed * multiplier);
        //[gambis]
        player = GameObject.Find("Player");
        //[/gambis]
        if (coisas.Length > 0) {
            int posicaoLivre = Random.Range(0, 6);
            for (int i = 0; i < 6; i++) {
                if (i != posicaoLivre && i != posicaoLivre + 6) {
                    if (Random.Range(0.0f, 1.0f) < probabilidade) {
                        int j = Random.Range(0, coisas.Length);
                        GameObject coisa = Instantiate(coisas[j]);
                        coisa.transform.position = transform.GetChild(i).position;
                        if (i >= 6) {
                            coisa.transform.eulerAngles = new Vector3(0, 0, 180);
                        }
                        coisa.transform.SetParent(transform);
                    }
                }
            }
        }
        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.playing) {
            if (!started) {
                ActionStart();
            }
            //[gambis]
            //if (player != null) {
                //if (player.transform.position.y > transform.position.y + 0.55f) {
                    //bc.enabled = true;
                //} else {
                   // bc.enabled = false;
                //}
            //}
            //[/gambis]
        }else{
            rb.velocity = new Vector2(0, 0);
        }
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
