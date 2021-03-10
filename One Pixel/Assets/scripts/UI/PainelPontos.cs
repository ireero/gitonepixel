using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PainelPontos : MonoBehaviour
{

    public Animator animPainelPontos;
    private bool on;
    public static bool vivo;
    public Text fala;
    private int umaVez;
    public Text pressione;

    public AudioSource som_background;

    private string fala100_chi = "您已经走了很长一段路，作为奖励媒体空间，并使用了新的功能";
    private string fala100_br = "Você já chegou longe, como recompensa aperte espaço e use um novo poder";
    private string fala100 = "You have already gone far, as a reward press space and use a new power";

    private string fala200_chi = "我永远不会忘记他们是多么愚蠢";
    private string fala200_br = "Nunca irei me esquecer do quão burro eles foram";
    private string fala200 = "I will never forget how dumb they were";

    private string fala300_chi = "一切都如此黑，白，灰..令人作呕！";
    private string fala300_br = "Tudo tão preto, branco e cinza.... NOJENTO!";
    private string fala300 = "Everything so black, white and gray .... DISGUSTING!";

    private string fala400_chi = "我最喜欢的血液是蓝色，尝起来像神圣。";
    private string fala400_br = "Meu sangue favorito é o azul, tem gosto de Divindade.";
    private string fala400 = "My favorite blood is blue, it tastes like Divinity.";

    private string fala500_chi = "我记得一切都很顺利，看到他们的战斗真是太好了";
    private string fala500_br = "Eu lembro muito bem de tudo, a luta dos dois foi maravilhosa de se ver";
    private string fala500 = "I remember everything very well, their fight was wonderful to see";

    private string fala600_chi = "一座城堡，两个民族和两个皇帝，这显然是错的";
    private string fala600_br = "um castelo, dois povos e dois imperadores, era óbvio que ia dar errado";
    private string fala600 = "a castle, two peoples and two emperors, it was obvious that it was going to go wrong";

    private string fala700_chi = "你在那里，你以为我不知道你在这里吗？";
    private string fala700_br = "Você ai, acha que não sei que está aqui?";
    private string fala700 = "You there, do you think I don't know you're here?";

    private string fala800_chi = "您是否真的认为可以做到这一点？";
    private string fala800_br = "Acha mesmo que consegue chegar até o final?";
    private string fala800 = "Do you really think you can make it to the end?";

    private string fala900_chi = "像你这样的人惹我生气，懂吗？人们";
    private string fala900_br = "Pessoas como você me dão raiva, você entendeu? P E S S O A S";
    private string fala900 = "People like you make me angry, do you understand? P E O P L E";

    private string fala1000_chi = "我想在那之前，玩家...";
    private string fala1000_br = "Acho que até logo então, Jogador....";
    private string fala1000 = "I think until then, Player...";

    private string pressione_br = "Pressione Q para avançar";
    private string pressione_chi = "按克前进";

    // Start is called before the first frame update
    void Start()
    {
        umaVez = 0;
        if(Application.systemLanguage == SystemLanguage.Portuguese) {
            pressione.text = pressione_br;
        }

        if(Application.systemLanguage == SystemLanguage.Chinese) {
            pressione.text = pressione_chi;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Quit.decorrer == 1) {
            Destroy(this.gameObject);
        }
        if(Pontuacao.GetPontos() >= 100 && umaVez == 0) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    fala.text = fala100_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala100_chi;
                        umaVez++;
                    } else {
                        fala.text = fala100;
                        umaVez++;
                    }       
        }

        if(Pontuacao.GetPontos() >= 200 && umaVez == 1) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        fala.text = fala200_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala200_chi;
                        umaVez++;
                    } else {
                        fala.text = fala200;
                        umaVez++;
                    } 
        }

        if(Pontuacao.GetPontos() >= 300 && umaVez == 2) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    fala.text = fala300_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala300_chi;
                        umaVez++;
                    } else {
                        fala.text = fala300;
                        umaVez++;
                    } 
        }

        if(Pontuacao.GetPontos() >= 400 && umaVez == 3) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        fala.text = fala400_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala400_chi;
                        umaVez++;
                    } else {
                        fala.text = fala400;
                        umaVez++;
                    } 
        }

         if(Pontuacao.GetPontos() >= 500 && umaVez == 4) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        fala.text = fala500_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala500_chi;
                        umaVez++;
                    } else {
                        fala.text = fala500;
                        umaVez++;
                    } 
        }

        if(Pontuacao.GetPontos() >= 600 && umaVez == 5) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        fala.text = fala600_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala600_chi;
                        umaVez++;
                    } else {
                        fala.text = fala600;
                        umaVez++;
                    } 
        }

        if(Pontuacao.GetPontos() >= 700 && umaVez == 6) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        fala.text = fala700_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala700_chi;
                        umaVez++;
                    } else {
                        fala.text = fala700;
                        umaVez++;
                    } 
        }

        if(Pontuacao.GetPontos() >= 800 && umaVez == 7) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        fala.text = fala800_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala800_chi;
                        umaVez++;
                    } else {
                        fala.text = fala800;
                        umaVez++;
                    } 
        }

        if(Pontuacao.GetPontos() >= 900 && umaVez == 8) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        fala.text = fala900_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala900_chi;
                        umaVez++;
                    } else {
                        fala.text = fala900;
                        umaVez++;
                    } 
        }

        if(Pontuacao.GetPontos() >= 1000 && umaVez == 9) {
            Pausar();
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        fala.text = fala1000_br;
                    umaVez++;
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        fala.text = fala1000_chi;
                        umaVez++;
                    } else {
                        fala.text = fala1000;
                        umaVez++;
                    } 
        }

        if(Input.GetKeyDown(KeyCode.Q) && on) {
                Continuar();
            } 
    }

    public void Pausar() {
        PainelPause.pausado = true;
        som_background.Pause();
        animPainelPontos.SetBool("aparecer", true);
        animPainelPontos.SetBool("desaparecer", false);
        SpawnChao.podeSopawn = false;
        Player.pode_mover = false;
        StartCoroutine("esperar");
        on = true;
    }

    public void Continuar() {
        PainelPause.pausado = false;
        som_background.Play();
        Time.timeScale = 1;
        animPainelPontos.SetBool("aparecer", false);
        animPainelPontos.SetBool("desaparecer", true);
        if(vivo == false) {
            SpawnChao.podeSopawn = true;
        }
        Player.pode_mover = true;
        on = false;
    }

    IEnumerator esperar() {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0.2f;
    }
}
