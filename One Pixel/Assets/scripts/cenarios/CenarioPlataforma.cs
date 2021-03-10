using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioPlataforma : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonUp(1)) {
            animator.SetBool("spawn", true);
        }

        if(Input.GetKeyUp(KeyCode.X) || Input.GetMouseButtonUp(1)) {
            animator.SetBool("spawn", false);
            CarinhaDoTreino.spawn_plataforma = true;
        }

        if(CarinhaDoTreino.spawn_plataforma) {
            StartCoroutine("esperar");
        }
    }

    IEnumerator esperar() {
        yield return new WaitForSeconds(2.5f);
        Instantiate(outra, gameObject.transform.position, gameObject.transform.rotation);
        CarinhaDoTreino.contagem = 1000;
        Destroy(gameObject);
    }
}
