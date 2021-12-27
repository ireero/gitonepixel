using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVoador : Monstros
{

    protected virtual void Morrer() {
        base.Morrer();
        corpo_monstro.bodyType = RigidbodyType2D.Dynamic;
        corpo_monstro.gravityScale += 0.14f;
    }
}
