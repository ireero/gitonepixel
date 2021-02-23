using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorSurvival : MonoBehaviour
{
    public Text txt_pausado;
    public Text txt_perdeu;
    public Text txt_instrucao;

    // Portugues
    private string txt_pausado_br  = "Pausado";
    private string txt_perdeu_br = "Voce Perdeu";
    private string txt_instrucao_br = "Para pause automático clique E. ";

    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Portuguese) {
            txt_pausado.text = txt_pausado_br;
            txt_perdeu.text = txt_perdeu_br;
            txt_instrucao.text = txt_instrucao_br;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
