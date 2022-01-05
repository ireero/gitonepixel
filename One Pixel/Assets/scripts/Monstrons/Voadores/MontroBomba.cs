using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontroBomba : MoveVoador
{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            anim.SetBool("explode", true);
        }
    }

}
