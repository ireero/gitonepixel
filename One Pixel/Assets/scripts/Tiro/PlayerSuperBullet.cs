﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuperBullet : MonoBehaviour
{

    private float speed = 2.4f;
    private float timeDestroy;
    private Animator anim;
    private BoxCollider2D collider;
    private bool nasceu;
    private int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        nasceu = false;
        timeDestroy = 15f;
        Destroy(gameObject, timeDestroy);
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!nasceu) {
            StartCoroutine("nascer");
        } else if(nasceu) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

     private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("portal")) {
            Morrer();
            StartCoroutine("morre");
        } else if(other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("pedras")) {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if(other.gameObject.CompareTag("bullet_inimiga") || other.gameObject.CompareTag("monstro") || other.gameObject.CompareTag("mguenta") || 
            other.gameObject.CompareTag("mago") || other.gameObject.CompareTag("aguenta_tirao")) {
            anim.SetBool("colidiu", true);
            contador++;
            StartCoroutine("voltarIdle");
            if(contador >= 4) {
                Morrer();
                StartCoroutine("morre");
            }
        } else if(other.gameObject.CompareTag("super_tiro")) {
            Morrer();
            StartCoroutine("morre");
        }
    }
    IEnumerator nascer() {
        yield return new WaitForSeconds(1.2f);
        nasceu = true;
        anim.SetBool("nasceu", true);
    }

    IEnumerator voltarIdle() {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("colidiu", false);
    }

    IEnumerator morre() {
		yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
	}

    private void Morrer() {
        anim.SetBool("morreu", true);
        speed = 0;
        collider.isTrigger = true;
    }
}