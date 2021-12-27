using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMonstroAguenta : Monstros
{

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == this.gameObject.tag || other.gameObject.CompareTag("monstro")){
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("idle", false);
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
        anim.SetBool("idle", true);
	}
}
