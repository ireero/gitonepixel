using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnChao : MonoBehaviour
{

    public GameObject monstro;
    public GameObject monstro2;
    public GameObject monstro3;
    public GameObject monstro4;

    public Transform lugar;

    private int valor;
    private float tempo;

    public static bool podeSopawn;
    public static bool pode_contar;

    private int cenaAtivada;

    // Start is called before the first frame update
    void Start()
    {
        pode_contar = false;
        cenaAtivada = SceneManager.GetActiveScene().buildIndex;
        podeSopawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        if(pode_contar) {
            Pontuacao.time += Time.deltaTime;
        }

        if(cenaAtivada == 3) {
            if(tempo >= 2f) {
            valor = Random.Range(1, 5);
            switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = -0.5f;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -1.5f; 
                        break;
                    case 4:
                        Instantiate(monstro4, lugar.position, lugar.rotation);
                        tempo = -1f;
                        break;           
                }
            }
        }

        if(tempo >= 2.5f && podeSopawn) {
            if(Pontuacao.GetPontos() >= 0 && Pontuacao.GetPontos() <= 300) {
                valor = SortearValor();
                switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = -1f;
                        Pontuacao.monstros++;
                        break;
                }

        } else if(Pontuacao.GetPontos() > 300 && Pontuacao.GetPontos() < 700) {
            valor = SortearValor();
            switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = -1f;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -2f; 
                        Pontuacao.monstros++;
                        break;       
                } } else if(Pontuacao.GetPontos() >= 700) {
            valor = SortearValor();
            switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = -1f;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -2f; 
                        Pontuacao.monstros++;
                        break;
                    case 4:
                        Instantiate(monstro4, lugar.position, lugar.rotation);
                        tempo = -1.5f;
                        Pontuacao.monstros++;
                        break;           
                }
        } else if(Pontuacao.GetPontos() > 700) {
            valor = SortearValor();
            tempo += 0.5f;
            switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = -0.5f;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -1.5f; 
                        Pontuacao.monstros++;
                        break;
                    case 4:
                        Instantiate(monstro4, lugar.position, lugar.rotation);
                        tempo = -1f;
                        Pontuacao.monstros++;
                        break;           
                }
        }
    }
}
    public int SortearValor() {
        int valorSorteado = 0;
        if(Pontuacao.GetPontos() >= 0 && Pontuacao.GetPontos() <= 300) {
            valorSorteado = Random.Range(1, 3);
        } else if(Pontuacao.GetPontos() > 300 && Pontuacao.GetPontos() < 700) {
            valorSorteado = Random.Range(1, 4);
        } else if(Pontuacao.GetPontos() >= 700) {
            valorSorteado = Random.Range(1, 5);
        }
        return valorSorteado;
    }
}
