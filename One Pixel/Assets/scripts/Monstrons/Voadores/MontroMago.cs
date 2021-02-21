using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontroMago: MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D corpo;
    private PolygonCollider2D collider;
    private CircleCollider2D collider_trigger;
    private float speed = -0.09f;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      corpo = GetComponent<Rigidbody2D>();
      collider = GetComponent<PolygonCollider2D>();  
      collider_trigger = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("morreu", true);
            Destroy(collider_trigger);
            StartCoroutine("morre");
        } else if(other.gameObject.tag == this.gameObject.tag || other.gameObject.tag == "mguenta"
            || other.gameObject.tag == "monstro") {
                Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    IEnumerator morre() {
        collider.isTrigger = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
