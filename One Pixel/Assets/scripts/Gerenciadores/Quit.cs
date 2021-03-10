using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public Toggle tirarFalasIniciais;
    public Toggle tirarFalasDurante;
    public static int inicio = 0;
    public static int decorrer = 0;

    public Text fala_toggle_inicio;
    public Text fala_toggle_decorrer;
    public Button fala_btn_sair;
    public Button fala_btn_menu;

    private string toggle_inicio_br = "Desativar conversa inicial";
    private string toggle_durante_br = "Desativar falas a cada 100 pontos";
    private string btn_ir_para_menu = "Voltar ao menu";
    private string sair_do_jogo = "Sair do jogo";

    private string toggle_inicio_chi = "禁用初始对话";
    private string toggle_durante_chi = "每100点禁用线路";
    private string btn_ir_para_menu_chi = "返回菜单";
    private string sair_do_jogo_chi = "离开游戏";

    void Start()
    {
        inicio = PlayerPrefs.GetInt("inicioValor");
        decorrer = PlayerPrefs.GetInt("decorrerValor");
        if(Application.systemLanguage == SystemLanguage.Portuguese) {
            fala_toggle_inicio.text = toggle_inicio_br;
            fala_toggle_decorrer.text = toggle_durante_br;
            fala_btn_menu.GetComponentInChildren<Text>().text = btn_ir_para_menu;
            fala_btn_sair.GetComponentInChildren<Text>().text = sair_do_jogo;
        }

        if(Application.systemLanguage == SystemLanguage.Chinese) {
            fala_toggle_inicio.text = toggle_inicio_chi;
            fala_toggle_decorrer.text = toggle_durante_chi;
            fala_btn_menu.GetComponentInChildren<Text>().text = btn_ir_para_menu_chi;
            fala_btn_sair.GetComponentInChildren<Text>().text = sair_do_jogo_chi;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inicio == 1) {
            tirarFalasIniciais.isOn = true; 
        } else if(inicio == 0) {
            tirarFalasIniciais.isOn = false;
        }

        if(decorrer == 1) {
            tirarFalasDurante.isOn = true;
        } else if(decorrer == 0) {
            tirarFalasDurante.isOn = false;
        } 
    }

    public void FinalizarJogo() {
            Application.Quit();
    }

    public void MudarIniciais() {
        if(tirarFalasIniciais.isOn == true) {
            inicio = 1;
        } else {
            inicio = 0;
        }
        PlayerPrefs.SetInt("inicioValor", inicio);
    }

    public void MudarDecorrer() {
        if(tirarFalasDurante.isOn == true) {
            decorrer = 1;
        } else {
            decorrer = 0;
        }
        PlayerPrefs.SetInt("decorrerValor", decorrer);
    }

    public static void Continuar() {
        Player.pode_atirar = true;
        SpawnChao.podeSopawn = true;
        Player.pode_mover = true;
        SpawnChao.pode_contar = true;
        PainelPause.vivo = false;
    }
}
