using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMonstroAguentaEAtira : MonoBehaviour
{
    private float velocidade = -0.11f;
    private int dano = 0;
    private Animator anim;
    private BoxCollider2D collider_ag_atira;
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
       collider_ag_atira = GetComponent<BoxCollider2D>();
       corpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        tempo_parar += Time.deltaTime;
        if(tempo_parar >= 0 && tempo_parar <= 4.1f) {
            transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
            tiro_um = 1;
        } else {
            if(tiro_um == 1) {
                anim.SetBool("dormir", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.tag == "mguenta"
            || other.gameObject.tag == "monstro"){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("tomou_dano", true);
            dano++;
            StartCoroutine("tiro");
            if(dano >= 3) {
                Morrer();
            }
        } else if(other.gameObject.CompareTag("p_super_bullet")) {
            Morrer();
        }
    }

    IEnumerator tiro() {
		yield return new WaitForSeconds(0.3f);
        anim.SetBool("tomou_dano", false);
	}

    private void Morrer() {
        Pontuacao.Pontuar();
        anim.SetBool("morreu", true);
        collider_ag_atira.isTrigger = true;
        morto = true;
        corpo.bodyType = RigidbodyType2D.Static;
        velocidade = 0;
    }

    public void voltarAndar() {
        tempo_parar = 0;
    }

    public void Fire() {
        anim.SetBool("atirando", false);
		if(!morto) {
            GameObject cloneBullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
            tiro_um = 0;
        }
	}
}
