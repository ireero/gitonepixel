using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuplicador : MoveVoador
{
    private EdgeCollider2D collider_trigger;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        collider_trigger = GetComponent<EdgeCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("bullet")) {
            StartCoroutine("suicidio");
        }
    }

    IEnumerator suicidio() {
        anim.SetBool("direito_morreu", true);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
