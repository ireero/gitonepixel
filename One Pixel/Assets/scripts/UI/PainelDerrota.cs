using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelDerrota : MonoBehaviour
{

    int y;
    // Start is called before the first frame update
    void Start()
    {
        y = SceneManager.GetActiveScene().buildIndex;
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
