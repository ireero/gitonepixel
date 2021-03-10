using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioNeutro : MonoBehaviour
{
    public GameObject outra;
    public GameObject outra_portugues;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(CarinhaDoTreino.contagem == 4) {
            if(Application.systemLanguage == SystemLanguage.Portuguese) {
                Instantiate(outra_portugues, gameObject.transform.position, gameObject.transform.rotation);
            } else {
                Instantiate(outra, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
