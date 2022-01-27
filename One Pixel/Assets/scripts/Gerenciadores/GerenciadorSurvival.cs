using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorSurvival : MonoBehaviour
{
    public Text txt_pausado;
    public Text txt_perdeu;
    public Text txt_instrucao;
    public Text txt_tempo;

    // Portugues
    private string txt_pausado_br  = "Pausado";
    private string txt_perdeu_br = "Voce Perdeu";
    private string txt_instrucao_br = "Aperte 'Esc' para uma pausa rápida";

    private string txt_pausado_chi = "已暂停";
    private string txt_perdeu_chi = "你输了";
    private string txt_instrucao_chi = "按下排气可快速休息";

    void Start()
    {

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

    void Update() {
        txt_tempo.text = PlayerSurvival.tempo_vivo.ToString("F0");
    }
}
