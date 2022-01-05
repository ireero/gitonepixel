using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeditador : MoveVoador
{
    private float tempo_atirar = 0;
    private float velocidade_de_sempre = -0.15f;

    // Variaveis de Tiro
    public Transform bulletSpawn;
	public GameObject bulletObject;
    private bool morto = false;
    private int tiro_um;
    // Start is called before the first frame update
    void Start()
    {
        tiro_um = 0;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        tempo_atirar += Time.deltaTime;
        if(tempo_atirar >= 5.0f) {
            tiro_um++;
            tempo_atirar = 0f;
        }

        if(tiro_um == 1) {
            velocidade = 0;
            anim.SetBool("atirando", true);
            Fire();
        }
    }

    IEnumerator tiro() {
		yield return new WaitForSeconds(0.4f);
        anim.SetBool("tomou_dano", false);
	}

    public void voltarAndar() {
        velocidade = velocidade_de_sempre;
        anim.SetBool("atirando", false);
    }

    void Fire() {
		if(!morto && tiro_um == 1) {
            GameObject cloneBullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
            tiro_um--;
        }
	}
}
