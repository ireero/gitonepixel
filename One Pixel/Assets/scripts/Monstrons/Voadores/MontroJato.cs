using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontroJato : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D corpo;
    private PolygonCollider2D collider;
    private float velocidade = 5f;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      corpo = GetComponent<Rigidbody2D>();
      collider = GetComponent<PolygonCollider2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, velocidade * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("morreu", true);
            collider.isTrigger = true;
            StartCoroutine("morre");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("parar_velocidade")) {
            anim.SetBool("chegou", true);
            velocidade = 0.1f;
        }
    }

    IEnumerator morre() {
        yield return new WaitForSeconds(1.75f);
        Destroy(this.gameObject);
    }
}
