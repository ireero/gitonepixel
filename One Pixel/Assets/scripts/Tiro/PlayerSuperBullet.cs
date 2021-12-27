﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuperBullet : MonoBehaviour
{

    private float speed = 2.4f;
    private float timeDestroy;
    private Animator anim;
    private BoxCollider2D collider_super;
    private bool nasceu;
    private int contador = 0;
    public AudioClip tiro_som;
    // Start is called before the first frame update
    void Start()
    {
        nasceu = false;
        timeDestroy = 15f;
        Destroy(gameObject, timeDestroy);
        anim = GetComponent<Animator>();
        collider_super = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nasceu) {
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
            }
        } else if(other.gameObject.CompareTag("super_tiro")) {
            Morrer();
        }
    }
    public void nascido() {
        nasceu = true;
    }

    IEnumerator voltarIdle() {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("colidiu", false);
    }

    private void Morrer() {
        GerenciaAudio.inst.PlaySomSfx(0, "SfxMonstros");
        anim.SetBool("morreu", true);
        speed = 0;
        collider_super.isTrigger = true;
    }

    public void Ir() {
        Destroy(this.gameObject);
    }
}
