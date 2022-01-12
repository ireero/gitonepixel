using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanhao : Monstros
{
    private float tempo_parar = 0;
    // Variaveis de Tiro
    public Transform bulletSpawn;
	public GameObject bulletObject;
    private bool morto = false;
    private int tiro_um = 0;

    

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        tempo_parar += Time.deltaTime;
        if(tempo_parar <= 2f) {
            transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
            tiro_um = 1;
        } else {
            if(tiro_um == 1) {
                anim.SetBool("atirando", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.tag == "mguenta"
            || other.gameObject.tag == "monstro" || other.gameObject.CompareTag("mago")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("tomou_dano", true);
            valorVida--;
            StartCoroutine("tiro");
            if(valorVida <= 0) {
                Morrer();
            }
        } else if(other.gameObject.CompareTag("p_super_bullet")) {
            Morrer();
        }
    }

    IEnumerator tiro() {
		yield return new WaitForSeconds(0.4f);
        anim.SetBool("tomou_dano", false);
	}

    public void voltarAndar() {
        tempo_parar = 0;
    }

    void Fire() {
        anim.SetBool("atirando", false);
		if(!morto) {
            Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
            tiro_um = 0;
        }
	}
}
