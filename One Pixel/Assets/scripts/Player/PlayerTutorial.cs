using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTutorial : Player {

	protected void Start () {
		base.Start();
		pode_mover = false;
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("portal_voltar")) {
			SceneManager.LoadScene(0);
		}
	}

}
