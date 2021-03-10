using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vilao : MonoBehaviour
{

    private Animator anim;
    public Animator painelFala;
    public Animator player;
    public Text txt_fala_inimigo;
    private int falas = 0;
    public Animator painelVenceu;

    // Caras e bocas do vilão
    public Sprite sprite_normal;
    public Sprite sprite_olhao;
    public Sprite sprite_duvida;
    public Sprite sprite_chorando;
    public Sprite sprite_irritado;

    public Image imagem;

    public Transform spawn_vilao;

    private string[] falasMonstro = {"What happened here?", "Did you... kill them all???", "It is not possible, there were more than 1,000 soldiers", 
        "How could you do that to your own people?", "In fact you shouldn't even be here! I'm sure I killed you...", "You will pay for what you did", 
        "Not now because apparently I'm not pareo for you", "But very soon I swear I will kill you!", "You got it? I swear on all this realm, for every pixel under my command that I will surely KILL YOU!!!!"};

    // Falas do vilão em portugues 
    private string[] falas_monstro_br = {"O que aconteceu aqui?", "Você... Matou todos eles???", "Não é possível, eram mais de 1.000 soldados", 
        "Como você pôde fazer isso com seu próprio povo?", "Na verdade, você nem deveria estar aqui! Tenho certeza que te matei...", "Você vai pagar pelo que fez", 
        "Não agora porque aparentemente não sou páreo para você", "Mas logo eu juro que irei te matar!", "Você entendeu? Eu juro por todo esse reino, por cada pixel sob meu comando que com certeza vou MATAR VOCÊ!!!!"};

    private string[] falas_monstro_chi = {"这里发生了什么？", "..全部杀死了他们？？？", "不可能，有1000多名士兵", 
        "您怎么能对自己的人做到这一点？", "实际上，您甚至都不应该在这里！我确定我杀了你...", "您将为您所做的付出", 
        "现在不行，因为显然我不适合您", "但是不久我发誓我会杀了你！", "你说对了？我在整个领域发誓，对于我指挥下的每个像素，我一定会杀了你！！！！"};          

    public Text pressione;
	private string pressione_br = "Pressione Q para avançar";  
    private string pressione_chi = "按克前进";

    void Start()
    {
        if(Application.systemLanguage == SystemLanguage.Portuguese) {
            pressione.text = pressione_br;
        }
        if(Application.systemLanguage == SystemLanguage.Chinese) {
            pressione.text = pressione_chi;
        }
        transform.position = spawn_vilao.transform.position;
        falas = 0;
        painelFala.SetBool("aparecer", true);
        anim = GetComponent<Animator>();
        Player.pode_mover = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(falas) {
            case 0:
            if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala_inimigo.text = falas_monstro_br[0];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                    txt_fala_inimigo.text = falas_monstro_chi[0];
                }else {
                    txt_fala_inimigo.text = falasMonstro[0];
                    imagem.sprite = sprite_duvida;
                }
                break;
            case 1:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala_inimigo.text = falas_monstro_br[1];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                    txt_fala_inimigo.text = falas_monstro_chi[1];
                } else {
                    txt_fala_inimigo.text = falasMonstro[1];   
                    imagem.sprite = sprite_olhao;
                }
                break;
            case 2:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala_inimigo.text = falas_monstro_br[2];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                    txt_fala_inimigo.text = falas_monstro_chi[2];
                } else {
                    txt_fala_inimigo.text = falasMonstro[2];
                }
                break;
            case 3:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala_inimigo.text = falas_monstro_br[3];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                    txt_fala_inimigo.text = falas_monstro_chi[3];
                } else {
                    txt_fala_inimigo.text = falasMonstro[3];
                    imagem.sprite = sprite_irritado;
                }
                break;
            case 4:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala_inimigo.text = falas_monstro_br[4];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                    txt_fala_inimigo.text = falas_monstro_chi[4];
                } else {
                    txt_fala_inimigo.text = falasMonstro[4];
                    imagem.sprite = sprite_duvida;
                }
                break;
            case 5:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala_inimigo.text = falas_monstro_br[5];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                    txt_fala_inimigo.text = falas_monstro_chi[5];
                } else {
                    txt_fala_inimigo.text = falasMonstro[5];
                    imagem.sprite = sprite_irritado;
                }
                break;
            case 6:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala_inimigo.text = falas_monstro_br[6];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                    txt_fala_inimigo.text = falas_monstro_chi[6];
                } else {
                    txt_fala_inimigo.text = falasMonstro[6];
                    imagem.sprite = sprite_normal;
                }
                break;
            case 7:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala_inimigo.text = falas_monstro_br[7];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                    txt_fala_inimigo.text = falas_monstro_chi[7];
                } else {
                    txt_fala_inimigo.text = falasMonstro[7];
                    imagem.sprite = sprite_chorando;
                }
                break;
            case 8:
                if (Application.systemLanguage == SystemLanguage.Portuguese) {
                    txt_fala_inimigo.text = falas_monstro_br[8];
                } else if(Application.systemLanguage == SystemLanguage.Chinese) {
                    txt_fala_inimigo.text = falas_monstro_chi[8];
                } else {
                    txt_fala_inimigo.text = falasMonstro[8];
                }
                break;
            case 9:
                painelFala.SetBool("aparecer", false);
                Player.final = true;
                this.gameObject.SetActive(false);
                break;                                
        }
        if(Input.GetKeyDown(KeyCode.Q)) {
            falas++;
        }
    }
}
