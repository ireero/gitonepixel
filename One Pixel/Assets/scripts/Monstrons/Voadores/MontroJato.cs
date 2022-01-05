using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontroJato : MoveVoador
{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("parar_velocidade")) {
            anim.SetBool("chegou", true);
            velocidade = -0.1f;
        }
    }
}
