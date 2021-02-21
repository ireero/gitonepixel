using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PainelPause : MonoBehaviour
{

    public Animator animPainelPause;
    public Button btn_pausar;
    private bool pausado;
    public static bool final = false;
    public static bool vivo;
    public AudioSource som_background;
    // Start is called before the first frame update
    void Start()
    {
        pausado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!final) {
            if(Input.GetKeyDown(KeyCode.E)) {
                if(!pausado) {
                    Pausar();
                } else {
                    Continuar();
                }
            }
        }
    }

    public void Pausar() {
        som_background.Pause();
        animPainelPause.SetBool("pausou", true);
        SpawnChao.podeSopawn = false;
        Player.pode_mover = false;
        StartCoroutine("esperar");
        btn_pausar.gameObject.SetActive(false);
        pausado = true;
    }

    public void Continuar() {
        som_background.Play();
        Time.timeScale = 1;
        animPainelPause.SetBool("pausou", false);
        if(vivo == false) {
            SpawnChao.podeSopawn = true;
        }
        Player.pode_mover = true;
        btn_pausar.gameObject.SetActive(true);
        pausado = false;
    }

    IEnumerator esperar() {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0;
    }
}
