using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCima : MonoBehaviour
{
    protected PolygonCollider2D collider_power_up;
    public Animator anim;

    void Start()
    {
        collider_power_up = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("monstro") || other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("mguenta")) {
            anim.SetBool("morte_louca", true);
            collider_power_up.isTrigger = true;
        }
    }

    public void SumirDeVez() {
        Destroy(this.gameObject);
    }
}
