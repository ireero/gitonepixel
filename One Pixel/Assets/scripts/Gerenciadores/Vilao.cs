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

    private string[] falasMonstro = {"What happened here ?", "Did you ... kill them all ???", "It is not possible, there were 1,000 soldiers.", 
        "How could you do that to your own people?", "In fact you shouldn't even be here! I'm sure I killed you ...", "You will pay for what you did.", 
        "Not now because apparently I'm not pareo for you,", "But very soon I swear I will kill you !", "You got it ? I swear on all this realm, for every pixel under my command that I will surely KILL YOU !!!!"};

    void Start()
    {
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
                txt_fala_inimigo.text = falasMonstro[0];
                imagem.sprite = sprite_duvida;
                break;
            case 1:
                txt_fala_inimigo.text = falasMonstro[1];   
                imagem.sprite = sprite_olhao;
                break;
            case 2:
                txt_fala_inimigo.text = falasMonstro[2];
                // mesmo
                break;
            case 3:
                txt_fala_inimigo.text = falasMonstro[3];
                imagem.sprite = sprite_irritado;
                break;
            case 4:
                txt_fala_inimigo.text = falasMonstro[4];
                imagem.sprite = sprite_duvida;
                break;
            case 5:
                txt_fala_inimigo.text = falasMonstro[5];
                imagem.sprite = sprite_irritado;
                break;
            case 6:
                txt_fala_inimigo.text = falasMonstro[6];
                imagem.sprite = sprite_normal;
                break;
            case 7:
                txt_fala_inimigo.text = falasMonstro[7];
                imagem.sprite = sprite_chorando;
                break;
            case 8:
                txt_fala_inimigo.text = falasMonstro[8];
                // mesmo
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
