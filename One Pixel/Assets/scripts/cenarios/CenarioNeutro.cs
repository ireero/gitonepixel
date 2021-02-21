using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioNeutro : MonoBehaviour
{
    public GameObject outra;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(CarinhaDoTreino.contagem == 4) {
            Instantiate(outra, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
