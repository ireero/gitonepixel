using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVoador : MonoBehaviour
{
    private float velocidade = -0.42f;
    private Rigidbody2D corpo;
    private BoxCollider2D collider;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("mago")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if(other.gameObject.CompareTag("bullet")) {
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
