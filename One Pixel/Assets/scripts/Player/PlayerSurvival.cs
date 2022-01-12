using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSurvival : Player {

	private float tempo_vivo = 0;
	
	void Update () {
		tempo_vivo += Time.deltaTime;
		if(pode_mover) {
			inputCheck ();
			move ();
		}
		texto.text = tempo_vivo.ToString("F0");
		Salvar();

		if(isGrounded) {
			podePor = false;
			podeVirar = false;
		} else {
			podePor = true;
			podeVirar = true;
		}
	}

	protected override void Salvar() {
		base.Salvar();
		if(tempo_vivo > PontuacaoSurvival.GetTempo()) {
			PlayerPrefs.SetInt("tempo", (int) tempo_vivo);
		}
	}

	public void posTirao() {
		rb2d.bodyType = RigidbodyType2D.Dynamic;
		anim.SetBool("super_tiro", false);
		pode_atirar = true;
	}

	void Tirao() {
        if(umTiro) {
			GameObject Super = Instantiate(superBullet, bulletSpawn.position, bulletSpawn.rotation);
			if(!lookingRight)
			Super.transform.eulerAngles = new Vector3(0, 0, 180);
			umTiro = false;
		}
	}
}
