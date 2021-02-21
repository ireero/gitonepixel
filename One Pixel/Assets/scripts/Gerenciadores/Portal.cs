using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Animator derrota;
    public GameObject player;
    public Animator anim_player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("monstro") || other.gameObject.CompareTag("mguenta") || 
            other.gameObject.CompareTag("mago") || other.gameObject.CompareTag("aguenta_tirao")) {
            derrota.SetBool("perdeu", true);
            anim_player.SetBool("morreu", true);
        }
    }

    IEnumerator playerMorre() {
        yield return new WaitForSeconds(1.2f);
        Destroy(player);
    }
}
