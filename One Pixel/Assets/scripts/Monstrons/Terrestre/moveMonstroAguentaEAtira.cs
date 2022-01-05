using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMonstroAguentaEAtira : Monstros
{
    private float tempo_parar = 0;

    // Variaveis de Tiro
    public Transform bulletSpawn;
	public GameObject bulletObject;
    private bool morto = false;
    private int tiro_um = 0;
    private float velocidade_de_sempre = -0.15f;

    protected override void Update()
    {
        base.Update();
        tempo_parar += Time.deltaTime;
        if(tempo_parar >= 0 && tempo_parar <= 4.1f) {
            Andar(this.velocidade);
            tiro_um = 1;
        } else {
            if(tiro_um == 1) {
                velocidade = 0;
                anim.SetBool("dormir", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.tag == "mguenta"
            || other.gameObject.tag == "monstro"){
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

    public void Fire() {
        if(tiro_um == 1) {
            Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
            tiro_um = 0;
        }
    }

    public void voltarAndar() {
        velocidade = velocidade_de_sempre;
        anim.SetBool("dormir", false);
    }

    IEnumerator tiro() {
		yield return new WaitForSeconds(0.3f);
        anim.SetBool("tomou_dano", false);
	}
}
