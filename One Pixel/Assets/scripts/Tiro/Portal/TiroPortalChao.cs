using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPortalChao : MonoBehaviour
{
    private Rigidbody2D corpo_tiro;
    private float velocidade = 4.8f;

    private void Start() {
        corpo_tiro = GetComponent<Rigidbody2D>();    
        StartCoroutine(morrer());
    }

    void Update()
    {
        corpo_tiro.velocity = Vector2.up * velocidade;
    }

    IEnumerator morrer() {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
