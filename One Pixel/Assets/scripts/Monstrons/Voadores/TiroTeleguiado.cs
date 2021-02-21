using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroTeleguiado : MonoBehaviour
{

    private float speed = 1.8f;
    private Animator anim;
    private BoxCollider2D collider;
    private bool nasceu;
    private int contador = 0;

    private Transform posicao_jogador;
    private SpriteRenderer sr;
    private Rigidbody2D corpo;
    // Start is called before the first frame update
    void Start()
    {
        nasceu = false;
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        posicao_jogador = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        corpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!nasceu) {
            transform.Translate(new Vector2(0, (speed - 0.65f) * Time.deltaTime));
            StartCoroutine("nascer");
        } else if(nasceu) {
            transform.position = Vector2.MoveTowards(transform.position, posicao_jogador.position,
            speed * Time.deltaTime);
            if(transform.position.x > posicao_jogador.position.x) {
                sr.flipX = false;
            } else {
                sr.flipX = true;
            }
        }
    }

     private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.tag == "monstro" || other.gameObject.tag == "mguenta" || 
            other.gameObject.tag == "mago" || other.gameObject.tag == "aguentao_tirao") {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("morreu", true);
            Morrer();
            StartCoroutine("morre");
        }
    }
    IEnumerator nascer() {
        yield return new WaitForSeconds(1.3f);
        nasceu = true;
        anim.SetBool("nasceu", true);
    }

    IEnumerator morre() {
		yield return new WaitForSeconds(1.8f);
        Destroy(this.gameObject);
	}

    private void Morrer() {
        anim.SetBool("atingiu", true);
        speed = 0;
        collider.isTrigger = true;
        corpo.gravityScale += 0.020f;
    }
}
