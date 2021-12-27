using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciaAudio : MonoBehaviour
{
    public AudioSource sair_som_sfx;
    public AudioSource sair_som_background;
    public AudioSource sair_som_monstros;
    public AudioClip[] sonsSfx;
    public AudioClip[] sonsBackground;
    public AudioClip[] sons_outras_cenas;
    public AudioClip[] sonsSfx_monstros;

    private string nome_cena;

    public static GerenciaAudio inst = null;

    void Awake() {

        if(inst == null) {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        } else if(inst != this) {
            Destroy(gameObject);
        }
        nome_cena = SceneManager.GetActiveScene().name;
    }

    private void Update() {

        if(SceneManager.GetActiveScene().name == nome_cena && !PainelPause.pausado) {
            if((SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Survival")) {
                EscolherSomBackground(2);
            } else if(SceneManager.GetActiveScene().name == "Menu") {
                EscolherSomBackground(1);
            } else if(SceneManager.GetActiveScene().name == "Tutorial") {
                EscolherSomBackground(3);
            }
        } else {
            sair_som_background.Stop();
            nome_cena = SceneManager.GetActiveScene().name;
        }
    }
        
    public void PlaySomSfx(int numeroSom, string oqueEIsso) {
        if(oqueEIsso == "SfxPlayer") {
            sair_som_sfx.clip = sonsSfx[numeroSom];
            sair_som_sfx.Play();
        } else if(oqueEIsso == "SfxMonstros") {
            sair_som_monstros.clip = sonsSfx_monstros[numeroSom];
            sair_som_monstros.Play();
        }
    }

    public void EscolherSomBackground(int qualCena) {
        if(!sair_som_background.isPlaying) {
                switch(qualCena) {
                    case 1:
                        sair_som_background.clip = sons_outras_cenas[0];
                        break;
                    case 2:
                        sair_som_background.clip = GetRandom();
                        break;
                    case 3:
                        sair_som_background.clip = sons_outras_cenas[1];
                        break;        
                }
                sair_som_background.Play();
            }
    }

    public void PausarSomBackGround() {
        sair_som_background.Pause();
    }

    public void DespausarSomBackGround() {
        sair_som_background.Play();
    }

    AudioClip GetRandom() {
        return sonsBackground[Random.Range(0, sonsBackground.Length)];
    }
}
