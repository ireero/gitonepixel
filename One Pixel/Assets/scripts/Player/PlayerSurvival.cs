using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSurvival : Player {

	private float tempo_vivo = 0;
	
	protected override void Update () {
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
}
