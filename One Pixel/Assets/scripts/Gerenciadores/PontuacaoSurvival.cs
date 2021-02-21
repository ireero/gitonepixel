using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PontuacaoSurvival : MonoBehaviour {

    private static float tempo_recorde = 0;
    public Text txt_survival_recorde;

    void Start()
    {
        tempo_recorde = PlayerPrefs.GetInt("tempo");
    }

    void Update() {
        txt_survival_recorde.text = tempo_recorde.ToString();
    }

    public static float GetTempo() {
        return tempo_recorde;
    }

}
