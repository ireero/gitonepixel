using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpanwVoador1 : MonoBehaviour
{
    public GameObject monstro;
    public GameObject monstro2;
    public GameObject monstro3;
    public GameObject monstro4;
    public GameObject monstro5;
    public GameObject monstro6;
    public GameObject monstro7;
    public GameObject monstro8;

    public Transform lugar;
    public static float tempo;
    
    private int valor;

    private int cenaAtivada;

    // Start is called before the first frame update
    void Start()
    {
        cenaAtivada = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;

         if(cenaAtivada == 3) {
            if(tempo >= 3f) {
            valor = Random.Range(1, 9);
            switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -1.5f;
                        break;
                    case 4:
                        Instantiate(monstro4, lugar.position, lugar.rotation);
                        tempo = -0.5f;
                        break; 
                    case 5:
                        Instantiate(monstro5, lugar.position, lugar.rotation);
                        tempo = 1f;
                        break;
                    case 6:
                        Instantiate(monstro6, lugar.position, lugar.rotation);
                        tempo = -0;
                        break;
                    case 7:
                        Instantiate(monstro7, lugar.position, lugar.rotation);
                        tempo = 0.75f;
                        break;
                    case 8:
                        Instantiate(monstro8, lugar.position, lugar.rotation);
                        tempo = -2f;
                        break;   
                }
            }
        }

        if(Pontuacao.time >= 8.0f && SpawnChao.podeSopawn) {
            if(Pontuacao.GetPontos() >= 0 && Pontuacao.GetPontos() <= 100) {
                if(tempo >= 4f) {
                    valor = SortearValor();
                    switch(valor) {
                        case 1:
                            Instantiate(monstro, lugar.position, lugar.rotation);
                            tempo = 0;
                            Pontuacao.monstros++;
                            break;
                        case 2:
                            Instantiate(monstro2, lugar.position, lugar.rotation);
                            tempo = 0;
                            Pontuacao.monstros++;
                            break;
                    }
                }
            }
        if(Pontuacao.GetPontos() > 100 && Pontuacao.GetPontos() < 200) {
            if(tempo >= 4f) {
                valor = SortearValor();
                switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -2f;
                        Pontuacao.monstros++;
                        break;
                }  
            }
        }

        if(Pontuacao.GetPontos() >= 200 && Pontuacao.GetPontos() <= 400) {
            if(tempo >= 4f) {
                valor = SortearValor();
                switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -2f;
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

        if(Pontuacao.GetPontos() <= 500 && Pontuacao.GetPontos() > 400) {
            if(tempo >= 4f) {
                valor = SortearValor();
                switch(valor) {
                case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -2f;
                        Pontuacao.monstros++;
                        break;
                    case 4:
                        Instantiate(monstro4, lugar.position, lugar.rotation);
                        tempo = -1f;
                        Pontuacao.monstros++;
                        break; 
                    case 5:
                        Instantiate(monstro5, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        Pontuacao.monstros++;
                        break;
                }
            }
        }

        if(Pontuacao.GetPontos() > 500 && Pontuacao.GetPontos() <= 600) {
            if(tempo >= 4f) {
                valor = SortearValor();
                switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -2f;
                        Pontuacao.monstros++;
                        break;
                    case 4:
                        Instantiate(monstro4, lugar.position, lugar.rotation);
                        tempo = -1f;
                        Pontuacao.monstros++;
                        break; 
                    case 5:
                        Instantiate(monstro5, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        Pontuacao.monstros++;
                        break;
                    case 6:
                        Instantiate(monstro6, lugar.position, lugar.rotation);
                        tempo = -0.5f;
                        Pontuacao.monstros++;
                        break;
                }
            }
        }

        if(Pontuacao.GetPontos() > 600 && Pontuacao.GetPontos() <= 800) {
            if(tempo >= 4f) {
                valor = SortearValor();
                switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -2f;
                        Pontuacao.monstros++;
                        break;
                    case 4:
                        Instantiate(monstro4, lugar.position, lugar.rotation);
                        tempo = -1f;
                        Pontuacao.monstros++;
                        break; 
                    case 5:
                        Instantiate(monstro5, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        Pontuacao.monstros++;
                        break;
                    case 6:
                        Instantiate(monstro6, lugar.position, lugar.rotation);
                        tempo = -0.5f;
                        Pontuacao.monstros++;
                        break;
                    case 7:
                        Instantiate(monstro7, lugar.position, lugar.rotation);
                        tempo = 0.25f;
                        Pontuacao.monstros++;
                        break;
                }
            }
        }

        if(Pontuacao.GetPontos() > 800 && Pontuacao.GetPontos() <= 900) {
            if(tempo >= 4f) {
                valor = SortearValor();
                switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = 0;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -2f;
                        Pontuacao.monstros++;
                        break;
                    case 4:
                        Instantiate(monstro4, lugar.position, lugar.rotation);
                        tempo = -1f;
                        Pontuacao.monstros++;
                        break; 
                    case 5:
                        Instantiate(monstro5, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        Pontuacao.monstros++;
                        break;
                    case 6:
                        Instantiate(monstro6, lugar.position, lugar.rotation);
                        tempo = -0.5f;
                        Pontuacao.monstros++;
                        break;
                    case 7:
                        Instantiate(monstro7, lugar.position, lugar.rotation);
                        tempo = 0.25f;
                        Pontuacao.monstros++;
                        break;
                    case 8:
                        Instantiate(monstro8, lugar.position, lugar.rotation);
                        tempo = -2.5f;
                        Pontuacao.monstros++;
                        break;   
                }
            }
        }

        if(Pontuacao.GetPontos() > 900) {
            if(tempo >= 3f) {
                valor = SortearValor();
                switch(valor) {
                    case 1:
                        Instantiate(monstro, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        Pontuacao.monstros++;
                        break;
                    case 2:
                        Instantiate(monstro2, lugar.position, lugar.rotation);
                        tempo = 0.5f;
                        Pontuacao.monstros++;
                        break;
                    case 3:
                        Instantiate(monstro3, lugar.position, lugar.rotation);
                        tempo = -1.5f;
                        Pontuacao.monstros++;
                        break;
                    case 4:
                        Instantiate(monstro4, lugar.position, lugar.rotation);
                        tempo = -0.5f;
                        Pontuacao.monstros++;
                        break; 
                    case 5:
                        Instantiate(monstro5, lugar.position, lugar.rotation);
                        tempo = 1f;
                        Pontuacao.monstros++;
                        break;
                    case 6:
                        Instantiate(monstro6, lugar.position, lugar.rotation);
                        tempo = -0;
                        Pontuacao.monstros++;
                        break;
                    case 7:
                        Instantiate(monstro7, lugar.position, lugar.rotation);
                        tempo = 0.75f;
                        Pontuacao.monstros++;
                        break;
                    case 8:
                        Instantiate(monstro8, lugar.position, lugar.rotation);
                        tempo = -2f;
                        Pontuacao.monstros++;
                        break;   
                }
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
