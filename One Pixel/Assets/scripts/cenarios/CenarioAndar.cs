using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioAndar : MonoBehaviour
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
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            animator.SetBool("direita", true);
            CarinhaDoTreino.andou_direita = true;
        }

        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) {
            animator.SetBool("direita", false);
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            animator.SetBool("esquerda", true);
            CarinhaDoTreino.andou_esquerda = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) {
            animator.SetBool("esquerda", false);
        }

        if(CarinhaDoTreino.andou_direita && CarinhaDoTreino.andou_esquerda) {
            StartCoroutine("esperar");
        }
    }

    IEnumerator esperar() {
        yield return new WaitForSeconds(1.5f);
        Instantiate(outra, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
