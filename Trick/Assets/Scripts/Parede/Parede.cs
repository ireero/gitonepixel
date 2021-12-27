using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cameraPrincipal;
    [SerializeField] private Transform spawn_parede;
    [SerializeField] private GameObject prefab_parede;

    private bool estaDentro;
    private bool estaArrastando;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estaDentro && Input.GetKeyDown(KeyCode.Mouse0))
        {
            estaArrastando = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            estaArrastando = false;
        }
    }

    private void FixedUpdate()
    {        
        if(estaArrastando)
        {
            rb.MovePosition(cameraPrincipal.ScreenToWorldPoint(Input.mousePosition));            
        }
    }

    private void OnMouseOver()
    {
        estaDentro = true;
    }

    private void OnMouseExit()
    {
        estaDentro = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("final")) {
            Instantiate(prefab_parede, spawn_parede.position, spawn_parede.rotation);
            Destroy(gameObject);
        }
    }

}
