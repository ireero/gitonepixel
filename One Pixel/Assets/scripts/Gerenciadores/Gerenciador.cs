using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour
{
    public GameObject vilao;
    private int umaVez;
    public Animator painel_vitoria;

    void Start()
    {
        umaVez = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Pontuacao.monstros >= 1000 && SpawnChao.podeSopawn == false && umaVez == 0) {
            umaVez++;
            StartCoroutine("aparecerVilao");
        }

        if(Player.final == true) {
            StartCoroutine("desaparecePainel");
        }
    }

    IEnumerator aparecerVilao() {
        yield return new WaitForSeconds(20f);
        if(umaVez == 1) {
            vilao.gameObject.SetActive(true);
        }
    }

    IEnumerator desaparecePainel() {
        yield return new WaitForSeconds(2.5f);
        painel_vitoria.SetBool("perdeu", true);
    }
}
