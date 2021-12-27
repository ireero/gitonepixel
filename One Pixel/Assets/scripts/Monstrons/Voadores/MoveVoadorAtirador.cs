using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVoadorAtirador : MoveVoador
{
    // Variaveis de tiro
    public Transform bulletSpawn;
	public GameObject bulletObject;
	protected float nextFire;
    private bool podeAtirar;

    protected override void Start() {
        base.Start();
        nextFire = 0;
        podeAtirar = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(!podeAtirar) {
            nextFire += Time.deltaTime;
            if(nextFire >= 1.52f) {
                podeAtirar = true;
                Fire();
                nextFire = 0;
            }
        }

    }

    void Fire() {
        if(podeAtirar) {
            GameObject cloneBullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
            podeAtirar = false;
        }
	}

    protected override void PontuarAgr() {
        base.PontuarAgr();
        nextFire = 0;
        podeAtirar = false;
    }
}
