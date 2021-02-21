using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    private float timeDestroy;
    private Animator anim;
    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {   
        anim = GetComponent<Animator>();
        timeDestroy = 15.0f;
        Destroy(gameObject, timeDestroy);
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

     private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("monstro") || other.gameObject.CompareTag("mago")) {
            Morrer();
            Pontuacao.Pontuar();
            StartCoroutine("morre");
        } else if(other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("mguenta") || other.gameObject.CompareTag("bullet_inimiga") || 
            other.gameObject.CompareTag("aguenta_tirao") || other.gameObject.CompareTag("super_tiro") || 
            other.gameObject.CompareTag("boneco_treino")) {
            Morrer();
            StartCoroutine("morre");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("destruir_bala") || other.gameObject.CompareTag("portal")) {
            Destroy(this.gameObject);
        }
    }

    IEnumerator morre() {
		yield return new WaitForSeconds(0.58f);
        Destroy(this.gameObject);
	}

    private void Morrer() {
        speed = 0;
        collider.isTrigger = true;
        anim.SetBool("atingiu", true);
    }
}
