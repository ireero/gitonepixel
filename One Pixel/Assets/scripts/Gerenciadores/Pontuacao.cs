using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pontuacao : MonoBehaviour {

    private static int pontos = 0;
    public Text txt_recorde;
    private static int recorde;
    public static float time = 0f;
    public static int monstros = 0;

    public Button botao_sobreviver;

    void Start()
    {
        recorde = PlayerPrefs.GetInt("recorde");
        time = 0;
        monstros = 0;
    }

    void Update() {
        txt_recorde.text = recorde.ToString();
        if(recorde >= 1000) {
            botao_sobreviver.interactable = true;
        }
    }

    public static void Pontuar() {
        pontos++;
    }

    public static int GetPontos() {
        return pontos;
    }

    public static int GetRecorde() {
        return recorde;
    }

    public static void ZerarPontos() {
        pontos = 0;
    }

}
