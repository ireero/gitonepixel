using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstros : MonoBehaviour
{
    public float velocidade;
    public int valorVida;
    protected Rigidbody2D corpo_monstro;
    protected Collider2D collider_monstro;
    protected Animator anim;
    protected SpriteRenderer sr;

    protected virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        corpo_monstro = GetComponent<Rigidbody2D>();
        collider_monstro = GetComponent<Collider2D>();
    }

    protected virtual void Update() {
        Andar(this.velocidade);
    }

    protected virtual void PontuarAgr() {
        Pontuacao.Pontuar();
    }

    public void SumirDeVez() {
        Destroy(this.gameObject);
    }

    public void Andar(float velocidade) {
        corpo_monstro.velocity = new Vector2(velocidade, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("mguenta") || other.gameObject.CompareTag("monstro")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if(other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("p_super_bullet")) {
            valorVida--;
            if(valorVida <= 0) {
                Morrer();
            }
        }
    }

    protected virtual void Morrer() {
        anim.SetBool("morreu", true);
        velocidade = 0;
        collider_monstro.isTrigger = true;
        corpo_monstro.bodyType = RigidbodyType2D.Static;
    }
}
