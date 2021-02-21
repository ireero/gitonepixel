using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuplicador : MonoBehaviour
{
    private Rigidbody2D corpo;
    private BoxCollider2D collider_esquerdo;
    private Animator anim;
    private EdgeCollider2D collider_trigger;
    private float speed = -0.35f;
    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
        collider_esquerdo = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        collider_trigger = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("bullet_inimiga") 
            || other.gameObject.CompareTag("pedras") || other.gameObject.CompareTag("mago")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if(other.gameObject.CompareTag("bullet")) {
            Morrer();
            StartCoroutine("morre");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("bullet")) {
            StartCoroutine("suicidio");
        }
    }

    IEnumerator morre() {
		yield return new WaitForSeconds(1.8f);
        Destroy(this.gameObject);
	}

    IEnumerator suicidio() {
        anim.SetBool("direito_morreu", true);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    private void Morrer() {
        anim.SetBool("morreu", true);
        collider_esquerdo.isTrigger = true;
        corpo.gravityScale += 0.04f;
    }
}
