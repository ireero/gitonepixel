using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInimiga : MonoBehaviour
{

    public float speed;
    private float timeDestroy;
    private Animator anim;
    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        timeDestroy = 15.2f;
        Destroy(gameObject, timeDestroy);
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector2.right * speed * Time.deltaTime);
    }

     private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            Morrer();
            StartCoroutine("morre");
        } else if(other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("monstro") || other.gameObject.CompareTag("mguenta") || 
            other.gameObject.CompareTag("mago")  || other.gameObject.CompareTag("aguenta_tirao")) {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if(other.gameObject.CompareTag("bullet") || other.gameObject.tag == "pedras") {
            Morrer();
            StartCoroutine("morre");
        }
    }

    IEnumerator morre() {
		yield return new WaitForSeconds(0.65f);
        Destroy(this.gameObject);
	}

    private void Morrer() {
        speed = 0;
        collider.isTrigger = true;
        anim.SetBool("atingiu", true);
    }
}
