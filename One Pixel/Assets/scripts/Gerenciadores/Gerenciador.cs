using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks.Data;
using Steamworks;

public class Gerenciador : MonoBehaviour
{
    public GameObject vilao;
    private int umaVez;
    public Animator painel_vitoria;

    public Text txt_pausado;
    public Text txt_perdeu;
    public Text txt_instrucao;

    public Text texto_pontuacao;

    // Portugues
    private string txt_pausado_br  = "Pausado";
    private string txt_perdeu_br = "Voce Perdeu";
    private string txt_instrucao_br = "Aperte 'Esc' para uma pausa rápida";

    private string txt_pausado_chi = "已暂停";
    private string txt_perdeu_chi = "你输了";
    private string txt_instrucao_chi = "按下排气可快速休息";

    private int conquista_olhos_vermelhos = 0;
    public static int mortes_player = 0;

    void Start()
    {
        mortes_player = PlayerPrefs.GetInt("conquista_morrer_20");
        conquista_olhos_vermelhos = PlayerPrefs.GetInt("conquista_olhos_vermelhos");
        umaVez = 0;
        if (Application.systemLanguage == SystemLanguage.Portuguese) {
            txt_pausado.text = txt_pausado_br;
            txt_perdeu.text = txt_perdeu_br;
            txt_instrucao.text = txt_instrucao_br;
        }

        if(Application.systemLanguage == SystemLanguage.Chinese) {
            txt_pausado.text = txt_pausado_chi;
            txt_perdeu.text = txt_perdeu_chi;
            txt_instrucao.text = txt_instrucao_chi;
        }
    }

    // Update is called once per frame
    void Update()
    {

        texto_pontuacao.text = Pontuacao.GetPontos().ToString();

        if(mortes_player == 20) {
            var ach = new Achievement("REALLY");
            ach.Trigger();
        }
        if(Pontuacao.monstros >= 1000 && SpawnChao.podeSopawn == false && umaVez == 0) {
            umaVez++;
            StartCoroutine("aparecerVilao");
        }

        Conquistas();

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

    public void Conquistas() {
        switch(Pontuacao.GetPontos()) {
            case 100:
                var ach1 = new Achievement("100");
                ach1.Trigger();
                break;
            case 200:
                var ach2 = new Achievement("200");
                ach2.Trigger();    
                break;
            case 300:
                var ach3 = new Achievement("300");
                ach3.Trigger();    
                break;
            case 400:
                var ach4 = new Achievement("400");
                ach4.Trigger();    
                break;
            case 500:
                var ach5 = new Achievement("500");
                ach5.Trigger();    
                break;
            case 600:
                var ach6 = new Achievement("600");
                ach6.Trigger();    
                break;
            case 700:
                var ach7 = new Achievement("700");
                ach7.Trigger();    
                break;
            case 800:
                var ach8 = new Achievement("800");
                ach8.Trigger();    
                break;
            case 900:
                var ach9 = new Achievement("900");
                ach9.Trigger();    
                break;
            case 1000:
                if(conquista_olhos_vermelhos == 0) {
                    var ach10 = new Achievement("RED_EYES");
                    ach10.Trigger();
                    conquista_olhos_vermelhos++;
                    PlayerPrefs.SetInt("conquista_olhos_vermelhos", conquista_olhos_vermelhos);
                }
                break;
        }
    }

    IEnumerator desaparecePainel() {
        yield return new WaitForSeconds(2.5f);
        painel_vitoria.SetBool("perdeu", true);
    }
}
