using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarinhaDoTreino : MonoBehaviour
{

    public Animator painel_fala;
    public GameObject painel_fala_objeto;
    private Animator anim;
    private string[] falas = {"It's about time you got here", "Well, I will teach you how to war", 
        "To learn just look closely at the wall","Use the platform when jumping for a better result", "Pressing 'Esc' pauses the game", "In addition, you can use AWSD for movement. the mouse is also configured", "Now practice!, try pressing all the buttons or something like that." + 
        "I have to go, see you soon, bye!", "To get out of here just enter the portal, I almost forgot to tell you hehehehe"};

    private string[] falasJogo = {"Protect the army portal from more than 1,000 monsters from the white pixel emperor", "Remember that failure is not an option for you...", 
        "Do it right and you will be duly rewarded", 
        "I have to go, but know that I am watching you and waiting for your triumphant victory!"};

    // Falas Do Carinha do tutorial com a lingua portuguesa
    private string[] falas_br = {"Já estava na hora de você chegar aqui", "Bem, eu vou te ensinar como guerrear", 
        "Para aprender basta olhar atentamente para a parede","Use a plataforma ao pular para um melhor resultado", "Apertando 'Esc' você pausa o jogo", "Além disso você pode usar AWSD para movimentação. o mouse também esta configurado", 
        "Agora pratique!, Tente pressionar todos os botões ou algo parecido", 
        "Eu tenho que ir, até logo, tchau!", "Para sair daqui é só entrar no portal, quase esqueci de te falar hehehehe"}; 

    private string[] falas_jogo_br = {"Proteja o portal do exército de mais de 1.000 monstros do imperador de pixel branco", "Lembre-se de que o fracasso não é uma opção para você...", 
        "Faça certo e você será devidamente recompensado", "Tenho que ir, mas saiba que estou te observando e esperando sua vitória triunfante!"};    

    private string[] falas_chi = {"你该到这了", "好吧，我要教你如何发动战争", 
        "要学习，只需仔细看看墙","跳跃时使用平台以获得更好的效果", "按逃脱键可暂停游戏", "此外，您可以使用阿大布柳艾丝德进行移动。鼠标也已配置", 
        "现在练习！，尝试按所有按钮或其他按钮", 
        "我得走了，再见，再见！", "要离开这里，只需进入门户，我几乎忘了告诉你"};

    private string[] falas_jogo_chi = {"保护军队门户免受1000多个白像素皇帝怪兽的侵害", "请记住，失败不是您的选择...", 
        "正确做，您将得到适当的回报", "我必须走，但知道我在看着你，等待着你的胜利！"};    

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

    public Text pressione;
	private string pressione_br = "Pressione Q para avançar";
    private string pressione_chi = "按克前进"; 

    // Start is called before the first frame update
    void Start()
    {
        if(Application.systemLanguage == SystemLanguage.Portuguese) {
            pressione.text = pressione_br;
        }
        if(Application.systemLanguage == SystemLanguage.Chinese) {
            pressione.text = pressione_chi;
        }
        contagem = 1;
        PainelPause.vivo = true;
        cenaAtivada = SceneManager.GetActiveScene().buildIndex;
        anim = GetComponent<Animator>();
        Player.pode_mover = false;
        PlayerTutorial.pode_mover = false;
        StartCoroutine("painelAparece");
    }

    // Update is called once per frame
    void Update()
    {
        if(cenaAtivada == 1) {
            if(Quit.inicio == 1) {
            Quit.Continuar();
            Destroy(painel_fala_objeto);
            Destroy(this.gameObject);
        }
            switch(contagem) {
                case 1:
                    if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        txt_fala.text = falas_jogo_br[0];
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_jogo_chi[0];
                    } else {
                        txt_fala.text = falasJogo[0];
                    }
                    break;
                case 2:
                    if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        txt_fala.text = falas_jogo_br[1];
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_jogo_chi[1];
                    } else {
                        txt_fala.text = falasJogo[1];
                    }
                    break;
                case 3:
                    if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        txt_fala.text = falas_jogo_br[2];
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_jogo_chi[2];
                    } else {
                        txt_fala.text = falasJogo[2];
                    }
                    break;
                case 4:
                    if (Application.systemLanguage == SystemLanguage.Portuguese) {
                        txt_fala.text = falas_jogo_br[3];
                    } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_jogo_chi[3];
                    } else {
                        txt_fala.text = falasJogo[3];
                    }
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
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala.text = falas_br[0];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_chi[0];
                    } else {
                    txt_fala.text = falas[0];
                }
                break;
            case 2:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala.text = falas_br[1];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_chi[1];
                    } else {
                    txt_fala.text = falas[1];
                }
                break;
            case 3: 
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala.text = falas_br[2];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_chi[2];
                    } else {
                    txt_fala.text = falas[2];
                }
                break;
            case 4:
                painel_fala.SetBool("aparece", false);
                painel_fala.SetBool("desaparece", true);
                PlayerTutorial.pode_mover = true;
                break;     
            case 998:
                PainelAparece();
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala.text = falas_br[3];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_chi[3];
                    } else {
                    txt_fala.text = falas[3];
                }       
                break;
            case 999:
                painel_fala.SetBool("aparece", false);
                painel_fala.SetBool("desaparece", true);
                break;     
            case 1000:
                PainelAparece();
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala.text = falas_br[4];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_chi[4];
                    } else {
                    txt_fala.text = falas[4];
                }       
                break;
            case 1001:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala.text = falas_br[5];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_chi[5];
                    } else {
                    txt_fala.text = falas[5];
                }
                break;
            case 1002:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala.text = falas_br[6];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_chi[6];
                    } else {
                    txt_fala.text = falas[6];
                }
                break;
            case 1003:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala.text = falas_br[7];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_chi[7];
                    } else {
                    txt_fala.text = falas[7];
                }
                break;
            case 1004:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala.text = falas_br[8];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                        txt_fala.text = falas_chi[8];
                    } else {
                    txt_fala.text = falas[8];
                }
                break;             
            case 1005:
                PainelPause.vivo = false;
                painel_fala.SetBool("aparece", false);
                painel_fala.SetBool("desaparece", true);
                anim.SetBool("sumir", true);
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
