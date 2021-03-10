using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuplicadorDireito : MonoBehaviour
{
    private Rigidbody2D corpo;
    private BoxCollider2D collider_esquerdo;
    private Animator anim;
    private EdgeCollider2D collider_trigger;
    private float speed = -0.35f;

    // Perseguir
    private float velocidade_apos_morte = 5.3f;
    private Transform posicao_jogador;
    private bool morreu = false;
    private bool olhando_esquerda = true;
    private SpriteRenderer sr;
    
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
        collider_esquerdo = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        collider_trigger = GetComponent<EdgeCollider2D>();
        posicao_jogador = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(morreu) {
            if(posicao_jogador.gameObject != null) {
            transform.position = Vector2.MoveTowards(transform.position, posicao_jogador.position,
            velocidade_apos_morte * Time.deltaTime);
            if(transform.position.x > posicao_jogador.position.x) {
                sr.flipY = false;
            } else {
                sr.flipY = true;
            }
        }
        } else {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("pedras")
            || other.gameObject.CompareTag("bullet_inimiga") || other.gameObject.CompareTag("mago")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if(other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("p_super_bullet")) {
            Pontuacao.Pontuar();
            if(morreu) {
                Morrer();
                StartCoroutine("morre");
            } else {
                MorrerIdle();
                StartCoroutine("morre");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("reacao", true);
            Destroy(collider_trigger);
            StartCoroutine("perseguir");
        }
    }
    IEnumerator morre() {
		yield return new WaitForSeconds(1.8f);
        Destroy(this.gameObject);
	}

    IEnumerator perseguir() {
        yield return new WaitForSeconds(1.3f);
        anim.SetBool("vingar", true);
        morreu = true;
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("perseguindo", true);
    }

    private void Morrer() {
        velocidade_apos_morte = 0.3f;
        anim.SetBool("morrer_perseguindo", true);
        collider_esquerdo.isTrigger = true;
        corpo.gravityScale += 0.014f;
    }

    private void MorrerIdle() {
        velocidade_apos_morte = 0.3f;
        anim.SetBool("morreu_idle", true);
        collider_esquerdo.isTrigger = true;
        corpo.gravityScale += 0.014f;
    }
}
