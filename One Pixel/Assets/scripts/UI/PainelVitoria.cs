using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PainelVitoria : MonoBehaviour
{

    int y;
    public Text venceu;
    public Button sim;

    private string venceu_br = "Voce venceu?";
    private string sim_br = "Sim";

    private string venceu_chi = "你赢了？";
    private string sim_chi = "是的";
    // Start is called before the first frame update
    void Start()
    {
        y = SceneManager.GetActiveScene().buildIndex;
        if(Application.systemLanguage == SystemLanguage.Portuguese) {
            venceu.text = venceu_br;
            sim.GetComponentInChildren<Text>().text = sim_br;
        }

        if(Application.systemLanguage == SystemLanguage.Chinese) {
            venceu.text = venceu_chi;
            sim.GetComponentInChildren<Text>().text = sim_chi;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Repetir() {
        SceneManager.LoadScene(y);  
    }

    public void IrParaOMenu() {
        SceneManager.LoadScene(0);
    }
}
