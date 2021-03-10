using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVoadorGirador : MonoBehaviour
{
    private float velocidade = -1.3f;
    private Rigidbody2D corpo;
    private Animator anim;
    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("mago") || other.gameObject.CompareTag("bullet_inimiga") || 
            other.gameObject.CompareTag("mguenta") || other.gameObject.CompareTag("super_tiro")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if(other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("p_super_bullet")) {
            Pontuacao.Pontuar();
            Morrer();
            StartCoroutine("morre");
        }
    }

    IEnumerator morre() {
		yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
	}

    private void Morrer() {
        anim.SetBool("morreu", true);
        collider.isTrigger = true;
        corpo.gravityScale += 0.1f;
    }
}
