using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontroMago: MoveVoador
{

    private Animator anim;
    private Rigidbody2D corpo;
    private PolygonCollider2D collider_mago;
    private CircleCollider2D collider_trigger;
    private float speed = -0.09f;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      corpo = GetComponent<Rigidbody2D>();
      collider_mago = GetComponent<PolygonCollider2D>();  
      collider_trigger = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("p_super_bullet")) {
            Pontuacao.Pontuar();
            speed = 0;
            collider_mago.isTrigger = true;
            corpo.gravityScale += 0.01f;
            anim.SetBool("morreu", true);
            Destroy(collider_trigger);
        } else if(other.gameObject.tag == this.gameObject.tag || other.gameObject.tag == "mguenta"
            || other.gameObject.tag == "monstro") {
                Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
