using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedraChao : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D collider_pedra;
    public float tempo;
    private bool pode_eliminar;

    // Start is called before the first frame update
    void Start()
    {   
        pode_eliminar = false;
        tempo = 0f;
        collider_pedra = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        if(tempo >= 2.0f) {
            animator.SetBool("sumir", true);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && pode_eliminar) {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            animator.SetBool("pisou", true);
            pode_eliminar = true;
        } else if(other.gameObject.CompareTag("super_tiro") || other.gameObject.CompareTag("bullet_inimiga") ||
            other.gameObject.CompareTag("monstro")) {
            animator.SetBool("destruida", true);
            StartCoroutine("morrer");
        }    
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            pode_eliminar = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("mago")) {
            tempo += 0.35f;
        }
    }

    public void DestruirDeVez() {
        Destroy(this.gameObject);
    }

    IEnumerator morrer() {
        collider_pedra.isTrigger = true;
        tempo = 0;
        yield return new WaitForSeconds(0.9f);
        Destroy(this.gameObject);
    }
}
