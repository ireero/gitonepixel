using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanhao : MonoBehaviour
{
    private float velocidade = -0.20f;
    private int dano = 0;
    private Animator anim;
    private PolygonCollider2D collider;
    private Rigidbody2D corpo;
    private float tempo_parar = 0;

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
        tempo_parar += Time.deltaTime;
        if(tempo_parar <= 2f) {
            transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
            tiro_um = 1;
        } else {
            if(tiro_um == 1) {
                anim.SetBool("atirando", true);
                Fire();
                tiro_um = 0;
            }
            StartCoroutine("voltarAndar");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.tag == "mguenta"
            || other.gameObject.tag == "monstro" || other.gameObject.CompareTag("mago")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("tomou_dano", true);
            dano++;
            StartCoroutine("tiro");
            if(dano >= 2) {
                Morrer();
                Pontuacao.Pontuar();
                StartCoroutine("morre");
            }
        } else if(other.gameObject.CompareTag("p_super_bullet")) {
            Morrer();
            Pontuacao.Pontuar();
            StartCoroutine("morre");
        }
    }

    IEnumerator tiro() {
		yield return new WaitForSeconds(0.4f);
        anim.SetBool("tomou_dano", false);
	}

    IEnumerator morre() {
		yield return new WaitForSeconds(2.1f);
        Destroy(this.gameObject);
	}

    IEnumerator voltarAndar() {
        yield return new WaitForSeconds(1f);
        anim.SetBool("atirando", false);
        tempo_parar = 0;
    }

    private void Morrer() {
        anim.SetBool("morreu", true);
        collider.isTrigger = true;
        morto = true;
        corpo.bodyType = RigidbodyType2D.Kinematic;
    }

    void Fire() {
		if(!morto) {
            Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
        }
	}
}
