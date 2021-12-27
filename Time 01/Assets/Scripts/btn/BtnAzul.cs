using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAzul : Btn
{
    public GameObject objeto;
    private bool ativado;

    void Awake()
    {
        base.Awake();
        if(objeto.activeSelf == true) {
            ativado = true;
        } else {
            ativado = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MudarEstado(ativado);
    }

    private void MudarEstado(bool estado) {
        if(estado) {
            if(apertado == 1) {
                objeto.SetActive(false);
            } else {
                objeto.SetActive(true);
            }
        } else {
            if(apertado == 1) {
                objeto.SetActive(true);
            } else {
                objeto.SetActive(false);
            }
        }
    }


}
