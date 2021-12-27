using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontroBomba : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D corpo;
    private BoxCollider2D collider_bomba;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      corpo = GetComponent<Rigidbody2D>();
      collider_bomba = GetComponent<BoxCollider2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("p_super_bullet")) {
            Pontuacao.Pontuar();
            anim.SetBool("morreu", true);
            collider_bomba.isTrigger = true;
            StartCoroutine("morre");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            anim.SetBool("explode", true);
            StartCoroutine("morre");
        }
    }

    IEnumerator morre() {
        yield return new WaitForSeconds(1.1f);
        Destroy(this.gameObject);
    }
}
