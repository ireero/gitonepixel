using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{

    public Button txt_play;
    public Button txt_tutorial;
    public Button txt_sobreviver;
    public Text txt_recorde_sobreviver;
    public Text txt_recorde;

    // Potugues
    private string txt_play_br = "Jogar";
    private string txt_tutorial_br = "Tutorial";
    private string txt_sobreviver_br = "Sobreviver";
    private string txt_recorde_br = "Recorde: ";
    private string txt_recorde_sobreviver_br = "Recorde Sobreviver: ";

    private string txt_play_chi = "玩";
    private string txt_tutorial_chi = "教程";
    private string txt_sobreviver_chi = "存活";
    private string txt_recorde_chi = "记录：";
    private string txt_recorde_sobreviver_chi = "生存记录：";
        
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Application.systemLanguage == SystemLanguage.Portuguese) {

            txt_play.GetComponentInChildren<Text>().text = txt_play_br;
            txt_tutorial.GetComponentInChildren<Text>().text = txt_tutorial_br;
            txt_sobreviver.GetComponentInChildren<Text>().text = txt_sobreviver_br;

            txt_recorde_sobreviver.text = txt_recorde_sobreviver_br;
            txt_recorde.text = txt_recorde_br;
        }

        if (Application.systemLanguage == SystemLanguage.Chinese) {

            txt_play.GetComponentInChildren<Text>().text = txt_play_chi;
            txt_tutorial.GetComponentInChildren<Text>().text = txt_tutorial_chi;
            txt_sobreviver.GetComponentInChildren<Text>().text = txt_sobreviver_chi;

            txt_recorde_sobreviver.text = txt_recorde_sobreviver_chi;
            txt_recorde.text = txt_recorde_chi;
        }

    }

    public void Jogar() {
        SceneManager.LoadScene(1);
    }

    public void Treinar() {
        SceneManager.LoadScene(2);
    }

    public void Survival() {
        SceneManager.LoadScene(3);
    }
}
