using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalChaoAtira : MonoBehaviour
{
    public GameObject tiro_do_portal;
    public Transform spawn_tiro;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator atirarESumir() {
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("sumir", true);
    }
    
    public void Sumir() {
        Destroy(this.gameObject);
    }

    public void Atirar() {
        Instantiate(tiro_do_portal, spawn_tiro.position, spawn_tiro.rotation);
        StartCoroutine(atirarESumir());
    }
}
