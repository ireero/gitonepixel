using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D corpo_bola;
    private float forca;

    void Start()
    {
        forca = 875f;
        corpo_bola = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("chao")) {
            corpo_bola.AddForce(new Vector3(0, forca, 0));
        } else if(other.gameObject.CompareTag("parede")) {
            Destroy(gameObject);
        }
    }
}
