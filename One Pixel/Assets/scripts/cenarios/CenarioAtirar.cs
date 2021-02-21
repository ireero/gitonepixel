using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioAtirar : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.Z)) {
            animator.SetBool("atirou", true);
        }

        if(Input.GetKeyUp(KeyCode.Z)) {
            animator.SetBool("atirou", false);
            CarinhaDoTreino.atirou = true;
        }

        if(CarinhaDoTreino.atirou) {
            StartCoroutine("esperar");
        }
    }

    IEnumerator esperar() {
        yield return new WaitForSeconds(2.0f);
        Instantiate(outra, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
