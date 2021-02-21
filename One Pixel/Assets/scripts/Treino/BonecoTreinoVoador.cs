using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonecoTreinoVoador : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("bullet")) {
            anim.SetBool("tomou", true);
            StartCoroutine("voltar");
        }
    }

    IEnumerator voltar() {
        yield return new WaitForSeconds(0.75f);
        anim.SetBool("tomou", false);
    }
}
