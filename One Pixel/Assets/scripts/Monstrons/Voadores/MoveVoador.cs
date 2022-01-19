using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVoador : Monstros
{

    protected override void Morrer() {
        anim.SetBool("morreu", true);
        velocidade = velocidade - (velocidade / 2);
        collider_monstro.isTrigger = true;
        corpo_monstro.bodyType = RigidbodyType2D.Dynamic;
        corpo_monstro.gravityScale += 0.25f;
    }
}
