using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarinhaDoTreino : MonoBehaviour
{

    public Animator painel_fala;
    private Animator anim;
    private string[] falas = {"It's about time you got here", "Well, I will teach you how to war", 
        "To learn just look closely at the wall", "Now practice !, try pressing all the buttons or something like that." + 
        "I have to go, see you soon, bye !", "To get out of here, just enter the portal. I almost forgot to tell you hehehehe"};
    private string[] falasJogo = {"Protect the portal from the white pixel emperor's army of 1,000 monsters.", "Remember that failure is not an option for you...", 
        "Do it right and you will be duly rewarded...", 
        " I have to go, but know that I am watching you and waiting for your triumphant victory !"};
    public Text txt_fala;
    public static int contagem;

    // Variaveis de conexão com as cenas de treino
    public static bool andou_direita = false;
    public static bool andou_esquerda = false;
    public static bool pulo = false;
    public static bool abaixou = false;
    public static bool atirou = false;
    public static bool spawn_plataforma = false;

    // cenas
    private int cenaAtivada;

    // Start is called before the first frame update
    void Start()
    {
        SpawnChao.pode_contar = true;
        PainelPause.vivo = true;
        cenaAtivada = SceneManager.GetActiveScene().buildIndex;
        Player.pode_mover = false;
        anim = GetComponent<Animator>();
        contagem = 1;
        StartCoroutine("painelAparece");
    }

    // Update is called once per frame
    void Update()
    {
        if(cenaAtivada == 1) {
            switch(contagem) {
                case 1:
                    txt_fala.text = falasJogo[0];
                    break;
                case 2:
                    txt_fala.text = falasJogo[1];
                    break;
                case 3:
                    txt_fala.text = falasJogo[2];
                    break;
                case 4:
                    txt_fala.text = falasJogo[3];
                    break;
                case 5:
                    SpawnChao.pode_contar = true;
                    PainelPause.vivo = false;
                    painel_fala.SetBool("aparece", false);
                    painel_fala.SetBool("desaparece", true);
                    anim.SetBool("sumir", true);
                    Player.pode_mover = true;
                    SpawnChao.podeSopawn = true;
                    StartCoroutine("esperaSumir");
                    break;
            }
        } else {
            switch(contagem) {
            case 1:
                txt_fala.text = falas[0];
                break;
            case 2:
                txt_fala.text = falas[1];
                break;
            case 3: 
                txt_fala.text = falas[2];
                break;
            case 4:
                painel_fala.SetBool("aparece", false);
                painel_fala.SetBool("desaparece", true);
                Player.pode_mover = true;
                break;     
            case 1000:
                Player.pode_mover = false;
                PainelAparece();
                txt_fala.text = falas[3];       
                break;
            case 1001:
                txt_fala.text = falas[4];
                break;
            case 1002:
                PainelPause.vivo = false;
                painel_fala.SetBool("aparece", false);
                painel_fala.SetBool("desaparece", true);
                anim.SetBool("sumir", true);
                Player.pode_mover = true;
                StartCoroutine("esperaSumir");
                break;          
        }
        }

        if(Input.GetKeyDown(KeyCode.Q)) {
            contagem++;
        }
    }

    IEnumerator painelAparece() {
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("nasceu", true);
        painel_fala.SetBool("aparece", true);
    }

    private void PainelAparece() {
        painel_fala.SetBool("desaparece", false);
        painel_fala.SetBool("aparece", true);
    }

    IEnumerator esperaSumir() {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
