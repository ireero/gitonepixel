using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gerenciador : MonoBehaviour
{
    public GameObject vilao;
    private int umaVez;
    public Animator painel_vitoria;

    public Text txt_pausado;
    public Text txt_perdeu;
    public Text txt_instrucao;

    // Portugues
    private string txt_pausado_br  = "Pausado";
    private string txt_perdeu_br = "Voce Perdeu";
    private string txt_instrucao_br = "Para pause automático clique E. ";

    void Start()
    {
        umaVez = 0;
        if (Application.systemLanguage == SystemLanguage.Portuguese) {
            txt_pausado.text = txt_pausado_br;
            txt_perdeu.text = txt_perdeu_br;
            txt_instrucao.text = txt_instrucao_br;
        }
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
