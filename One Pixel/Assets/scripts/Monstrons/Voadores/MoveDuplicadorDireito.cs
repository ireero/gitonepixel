using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuplicadorDireito : MoveVoador
{

    private EdgeCollider2D collider_trigger;

    // Perseguir
    private float velocidade_apos_morte = 5.3f;
    private Transform posicao_jogador;
    private bool morreu;
    private SpriteRenderer sr;
    
    protected override void Start()
    {
        base.Start();
        morreu = false;
        collider_trigger = GetComponent<EdgeCollider2D>();
        posicao_jogador = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(morreu) {
            if(posicao_jogador.gameObject != null) {
            transform.position = Vector2.MoveTowards(transform.position, posicao_jogador.position,
            velocidade_apos_morte * Time.deltaTime);
            velocidade = 0;
            if(transform.position.x > posicao_jogador.position.x) {
                sr.flipY = false;
            } else {
                sr.flipY = true;
            }
        }
        } else {
            Andar(velocidade);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("pedras")
            || other.gameObject.CompareTag("bullet_inimiga") || other.gameObject.CompareTag("mago")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if(other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("p_super_bullet")) {
            Morrer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("reacao", true);
            Destroy(collider_trigger);
            StartCoroutine("perseguir");
        }
    }

    IEnumerator perseguir() {
        yield return new WaitForSeconds(1.3f);
        anim.SetBool("vingar", true);
        morreu = true;
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("perseguindo", true);
    }

    protected override void Morrer() {
        base.Morrer();
        if(morreu) {
            anim.SetBool("morrer_perseguindo", true);
        } else {
            anim.SetBool("morreu_idle", true);
        }
        velocidade_apos_morte = 0.3f;
        collider_monstro.isTrigger = true;
        corpo_monstro.gravityScale += 0.014f;
    }
}
