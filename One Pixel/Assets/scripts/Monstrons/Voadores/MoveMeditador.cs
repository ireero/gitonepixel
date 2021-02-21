using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeditador : MonoBehaviour
{
    private float velocidade = -0.15f;
    private int dano = 0;
    private Animator anim;
    private PolygonCollider2D collider;
    private Rigidbody2D corpo;
    private float tempo_atirar = 0;

    // Variaveis de Tiro
    public Transform bulletSpawn;
	public GameObject bulletObject;
    private bool morto = false;
    private int tiro_um = 0;
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
       collider = GetComponent<PolygonCollider2D>();
       corpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
        tempo_atirar += Time.deltaTime;
        if(tempo_atirar >= 5.0f) {
            tiro_um++;
            tempo_atirar = 0f;
        }

        if(tiro_um == 1) {
            velocidade = 0;
            anim.SetBool("atirando", true);
            Fire();
            StartCoroutine("voltarAndar");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.tag == "mguenta"
            || other.gameObject.tag == "monstro" || other.gameObject.CompareTag("mago") || other.gameObject.CompareTag("super_tiro") || 
            other.gameObject.CompareTag("bullet_inimiga")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("tomou_dano", true);
            dano++;
            StartCoroutine("tiro");
            if(dano >= 3) {
                Morrer();
                Pontuacao.Pontuar();
                StartCoroutine("morre");
            }
        }
    }

    IEnumerator tiro() {
		yield return new WaitForSeconds(0.4f);
        anim.SetBool("tomou_dano", false);
	}

    IEnumerator morre() {
		yield return new WaitForSeconds(2.2f);
        Destroy(this.gameObject);
	}

    IEnumerator voltarAndar() {
        yield return new WaitForSeconds(2f);
        anim.SetBool("atirando", false);
        velocidade = -0.15f;
    }

    private void Morrer() {
        anim.SetBool("morreu", true);
        collider.isTrigger = true;
        morto = true;
        corpo.bodyType = RigidbodyType2D.Kinematic;
    }

    void Fire() {
		if(!morto && tiro_um == 1) {
            GameObject cloneBullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
            tiro_um--;
        }
	}
}
