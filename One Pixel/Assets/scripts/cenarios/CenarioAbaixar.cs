using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioAbaixar : MonoBehaviour
{

    private Animator animator;
    public GameObject outra;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            animator.SetBool("abaixou", true);
        }

        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) {
            animator.SetBool("abaixou", false);
            CarinhaDoTreino.abaixou = true;
        }

        if(CarinhaDoTreino.abaixou) {
            StartCoroutine("esperar");
        }
    }

    IEnumerator esperar() {
        yield return new WaitForSeconds(1.5f);
        Instantiate(outra, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
