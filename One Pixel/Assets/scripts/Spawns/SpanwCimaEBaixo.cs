using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwCimaEBaixo : MonoBehaviour
{
    public Transform[] spawns_cima;
    public Transform[] spawns_baixo;

    public GameObject portal_de_baixo;
    public GameObject power_up_cima;   

    private float tempo_sem_lancar_baixo;
    private float tempo_sem_lancar_cima;

    private float tempo_demora_cima = 3f;
    private float tempo_demora_baixo = 4.5f; 

    public int valor_alet_baixo;
    public int valor_alet_cima; 

    private void Start() {
        valor_alet_baixo = 0;
        valor_alet_cima = 0;
    }
    void Update()
    {
        if(Pontuacao.GetPontos() >= 100 || PlayerSurvival.tempo_vivo >= 5f) {
            
            tempo_sem_lancar_baixo += Time.deltaTime;
            tempo_sem_lancar_cima += Time.deltaTime;

            if(tempo_sem_lancar_baixo >= tempo_demora_baixo) {
                valor_alet_baixo = Random.Range(0, 7);
                Instantiate(portal_de_baixo, spawns_baixo[valor_alet_baixo].position, spawns_baixo[valor_alet_baixo].rotation);
                tempo_sem_lancar_baixo = 0;
            }

            if(tempo_sem_lancar_cima >= tempo_demora_cima) {
                valor_alet_cima = Random.Range(0, 7);
                Instantiate(power_up_cima, spawns_cima[valor_alet_cima].position, spawns_cima[valor_alet_cima].rotation);
                tempo_sem_lancar_cima = 0;
            }
        }
    }
}
