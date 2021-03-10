using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMonstroAguenta : MonoBehaviour
{
    private float velocidade = -0.25f;
    private int dano = 0;
    private Animator anim;
    private BoxCollider2D collider;
    private Rigidbody2D corpo;
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
       anim.SetBool("idle", true);
       collider = GetComponent<BoxCollider2D>();
       corpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("monstro")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("idle", false);
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
        anim.SetBool("idle", true);
	}

    IEnumerator morre() {
		yield return new WaitForSeconds(1.2f);
        Destroy(this.gameObject);
	}

    private void Morrer() {
        anim.SetBool("morreu", true);
        collider.isTrigger = true;
        corpo.bodyType = RigidbodyType2D.Kinematic;
    }
}
