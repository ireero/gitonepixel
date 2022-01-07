using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnDosVoadores : MonoBehaviour
{
    public GameObject[] monstros;
    public Transform lugar;

    private float tempo;

    protected int valor;

    protected string cenaAtivada;
    public float tempo_para_comecar_survival;
    public float tempo_para_comecar_sobrevivencia;
    public float tempo_para_proxima_acao;

    void Start()
    {
        cenaAtivada = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {

        tempo += Time.deltaTime;

        if(cenaAtivada == "Survival") {
            if(tempo >= tempo_para_comecar_sobrevivencia) {
            valor = Random.Range(1, 9);
            switch(valor) {
                    case 1:
                        Instantiate(monstros[0], lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        break;
                    case 2:
                        Instantiate(monstros[1], lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        break;
                    case 3:
                        Instantiate(monstros[2], lugar.position, lugar.rotation);
                        tempo = -1.5f;
                        break;
                    case 4:
                        Instantiate(monstros[3], lugar.position, lugar.rotation);
                        tempo = -0.5f;
                        break; 
                    case 5:
                        Instantiate(monstros[4], lugar.position, lugar.rotation);
                        tempo = 1f;
                        break;
                    case 6:
                        Instantiate(monstros[5], lugar.position, lugar.rotation);
                        tempo = -0;
                        break;
                    case 7:
                        Instantiate(monstros[6], lugar.position, lugar.rotation);
                        tempo = 0.75f;
                        break;
                    case 8:
                        Instantiate(monstros[7], lugar.position, lugar.rotation);
                        tempo = -2f;
                        break;   
                }
            }
        }

        if(Pontuacao.time >= tempo_para_comecar_sobrevivencia && SpawnChao.podeSopawn) {
            SpawnsPorPontuacao(0, 100);
            SpawnsPorPontuacao(101, 199);
            SpawnsPorPontuacao(200, 400);
            SpawnsPorPontuacao(401, 500);
            SpawnsPorPontuacao(501, 600);
            SpawnsPorPontuacao(601, 800);
            SpawnsPorPontuacao(801, 900);
            SpawnsPorPontuacao(901, 20000);
        }

    }

    void SpawnsPorPontuacao(int minimo, int maximo) {
        if(Pontuacao.GetPontos() >= minimo && Pontuacao.GetPontos() <= maximo) {
            if(tempo >= tempo_para_proxima_acao) {
                valor = SortearValor();
                Pontuacao.monstros++;
                switch(valor) {
                    case 1:
                        Instantiate(monstros[0], lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        break;
                    case 2:
                         Instantiate(monstros[1], lugar.position, lugar.rotation);
                         tempo = 0.5f;
                        break;
                    case 3:
                         Instantiate(monstros[2], lugar.position, lugar.rotation);
                         tempo = -1.5f;
                        break;
                    case 4:
                         Instantiate(monstros[3], lugar.position, lugar.rotation);
                         tempo = -0.5f;
                        break;           
                    case 5:
                         Instantiate(monstros[4], lugar.position, lugar.rotation);
                         tempo = 1f;
                        break;    
                    case 6:
                         Instantiate(monstros[5], lugar.position, lugar.rotation);
                         tempo = 0.25f;
                        break;
                    case 7:
                         Instantiate(monstros[6], lugar.position, lugar.rotation);
                         tempo = 0.25f;
                        break;
                    case 8:
                        tempo = -2.5f;
                         Instantiate(monstros[7], lugar.position, lugar.rotation);
                        break;
                    default:
                        Instantiate(monstros[0], lugar.position, lugar.rotation);   
                        tempo = 0.5f;
                        break;             
                }
            }
        }
    }

    public int SortearValor() {
            int valorSorteado = 0;
        if(Pontuacao.GetPontos() >= 0 && Pontuacao.GetPontos() <= 100) {
            valorSorteado = Random.Range(1, 3);
        } else if(Pontuacao.GetPontos() > 100 && Pontuacao.GetPontos() < 200) {
            valorSorteado = Random.Range(1, 4);
        } else if(Pontuacao.GetPontos() >= 200 && Pontuacao.GetPontos() <= 400) {
            valorSorteado = Random.Range(1, 5);
        } else if(Pontuacao.GetPontos() <= 500 && Pontuacao.GetPontos() > 400) {
            valorSorteado = Random.Range(1, 6);
        } else if(Pontuacao.GetPontos() > 500 && Pontuacao.GetPontos() <= 600) {
            valorSorteado = Random.Range(1, 7);
        } else if(Pontuacao.GetPontos() > 600 && Pontuacao.GetPontos() <= 800) {
            valorSorteado = Random.Range(1, 8);
        } else if(Pontuacao.GetPontos() > 800) {
            valorSorteado = Random.Range(1, 9);
        }
        return valorSorteado;
    }
}
