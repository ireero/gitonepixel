using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroTeleguiado : MoveVoador
{

    private Transform posicao_jogador;
    private bool nasceu;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        nasceu = false;
        posicao_jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!nasceu) {
            transform.Translate(new Vector2(0, (velocidade - 0.65f) * Time.deltaTime));
            StartCoroutine("nascer");
        } else if(nasceu) {
            transform.position = Vector2.MoveTowards(transform.position, posicao_jogador.position,
            velocidade * Time.deltaTime);
            if(transform.position.x > posicao_jogador.position.x) {
                sr.flipX = false;
            } else {
                sr.flipX = true;
            }
        }
    }

    IEnumerator nascer() {
        yield return new WaitForSeconds(1.3f);
        nasceu = true;
        anim.SetBool("nasceu", true);
    }

    protected override void Morrer() {
        base.Morrer();
        velocidade = 0.2f;
    }
}
