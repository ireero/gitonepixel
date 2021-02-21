using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogar() {
        SceneManager.LoadScene(1);
    }

    public void Treinar() {
        SceneManager.LoadScene(2);
    }

    public void Survival() {
        SceneManager.LoadScene(3);
    }
}
