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

    public GameObject[] coisas;
    [Range(0.0f, 1.0f)]
    public float probabilidade;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed*multiplier);
        bc = GetComponent<BoxCollider2D>();
        //[gambis]
        player = GameObject.Find("Player");
        //[/gambis]
        if (coisas.Length > 0) {
            int posicaoLivre = Random.Range(0, 6);
            for (int i = 0; i < 12; i++) {
                if (i != posicaoLivre && i != posicaoLivre + 6) {
                    if (Random.Range(0.0f, 1.0f) < probabilidade) {
                        int j = Random.Range(0, coisas.Length);
                        GameObject coisa = Instantiate(coisas[j]);
                        coisa.transform.position = transform.GetChild(i).position;
                        if(i >= 6) {
                            coisa.transform.eulerAngles = new Vector3(0, 0, 180);
                        }
                        coisa.transform.SetParent(transform);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //[gambis]
        if(player != null) {
            if(player.transform.position.y > transform.position.y + 0.55f) {
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
