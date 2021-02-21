using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioPulo : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            animator.SetBool("pulou", true);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) {
            animator.SetBool("pulou", false);
            CarinhaDoTreino.pulo = true;
        }

        if(CarinhaDoTreino.pulo) {
            StartCoroutine("esperar");
        }
    }

    IEnumerator esperar() {
        yield return new WaitForSeconds(1.5f);
        Instantiate(outra, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
