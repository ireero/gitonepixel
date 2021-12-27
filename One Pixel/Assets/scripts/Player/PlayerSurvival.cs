using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSurvival : MonoBehaviour {
	public Transform groundCheck;
	public float speed = 4f;
	public float jumpForce = 200f;
	public LayerMask whatIsGround;

	public bool umTiro = true;

	[HideInInspector]
	public bool lookingRight = true;
	public bool pode_atirar;

	private Rigidbody2D rb2d;
	public bool isGrounded = false;
	private bool jump = false;

	//Variaveis do tiro
	public Transform bulletSpawn;
	public GameObject bulletObject;
	private SpriteRenderer spritePlayer;
	public AudioClip pulo;
	public AudioClip tiroAudio;

	public GameObject superBullet;

	// Animações
	private Animator anim;
	private float duracaoAnim;
	private bool caiu = false;

	public Text texto;
	private BoxCollider2D playerCollider;
	private PolygonCollider2D colliderAbaixado;

	// Spawn Chão
	public Transform chaoSpawn;
	public GameObject chao;
	private bool podePor = true;
	public AudioClip som_morte;

	// UI
	public Animator derrota;

	// Pode se mover
	public static bool pode_mover = true;

	//valores
	private int valor_entrada;

	// Survival
	private static float tempo_vivo;
	public AudioSource som_background;

	private float taxa_tiros;
	private float cont;

	private bool virado;
	private bool podeVirar;

	public Transform padrao;

	void Start () {
		podeVirar = false;
		virado = false;
		taxa_tiros = 0.25f;
		cont = 0;
		pode_atirar = true;
		Time.timeScale = 1;
		tempo_vivo = 0;
		valor_entrada = 0; 
		rb2d = GetComponent<Rigidbody2D> ();
		spritePlayer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		playerCollider = GetComponent<BoxCollider2D>();
	}
	
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

	void inputCheck (){

		if ((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetKeyDown(KeyCode.W) && isGrounded) || Input.GetMouseButtonDown(2) && isGrounded){
			jump = true;
		}

		if(Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(1)) {
			if(podePor) {
				SpawnPedra();
			}
		}

		if(Input.GetKeyDown(KeyCode.C)) {
			if(podeVirar) {
				spritePlayer.color = Color.red;
				Time.timeScale = 0.1f;
				transform.Rotate(0, 0, 90);
				virado = true;
				StartCoroutine("voltarTempo");
			}
		}

		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			anim.SetBool("abaixou", true);
		}

		if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) {
			anim.SetBool("abaixou", false);
		}

		if(pode_atirar) {
			umTiro = true;
			if(Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)) {
				Fire();
			} else if(Input.GetKey(KeyCode.Z) || Input.GetMouseButton(0)) {
				cont += Time.deltaTime;
				if(cont >= taxa_tiros) {
					Fire();
					cont = 0;
				}
			}
				if(Input.GetKey("space")) {
				rb2d.bodyType = RigidbodyType2D.Static;
				pode_atirar = false;
				anim.SetBool("super_tiro", true);
				Tirao();
				StartCoroutine("posTirao");
			
			} 
		}
	}

	void move(){

		float horizontalForceButton = Input.GetAxis ("Horizontal");
		rb2d.velocity = new Vector2 (horizontalForceButton * speed, rb2d.velocity.y);
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.215f, whatIsGround);

		Animar();

		if ((horizontalForceButton > 0 && !lookingRight) || (horizontalForceButton < 0 && lookingRight))
			Flip ();

		if (jump) {
			rb2d.AddForce(new Vector2(0, jumpForce));
			jump = false;
		}
	}

	void Flip(){
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

	void Fire() {


		GameObject cloneBullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);

		if(!lookingRight)
			cloneBullet.transform.eulerAngles = new Vector3(0, 0, 180);
	}

	private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("monstro") || other.gameObject.CompareTag("mguenta") 
			|| other.gameObject.CompareTag("bullet_inimiga") || other.gameObject.CompareTag("super_tiro") ||
				other.gameObject.CompareTag("aguenta_tirao")) {
			Morrer();
        } else if(other.gameObject.CompareTag("portal_voltar")) {
			SceneManager.LoadScene(0);
		} else if(other.gameObject.CompareTag("chao") || other.gameObject.CompareTag("pedras")) {
			if(virado) {
				transform.rotation = padrao.rotation;
				virado = false;
			}
		}
    }
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("mago")) {
			spritePlayer.color = Color.grey;
			speed -= 0.45f;
			jumpForce -= 7.5f;
			valor_entrada++;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("mago")) {
			speed += 0.45f;
			jumpForce += 7.5f;
			valor_entrada--;
			if(valor_entrada <= 0) {
				spritePlayer.color = Color.white;
			}
		}
	}

	private void Morrer() { // Tudo que rola quando morre
		som_background.Stop();
		playerCollider.isTrigger = true;
		rb2d.bodyType = RigidbodyType2D.Static;
        anim.SetBool("morreu", true);
		Destroy(bulletSpawn.gameObject);
		StartCoroutine("morrer");
	}

	private void Animar() { // Animações
		if(isGrounded) {
			anim.SetBool("caiu", true);
			anim.SetBool("pulando", false);
			StartCoroutine("animarCaida");
			if(caiu) {
				anim.SetBool("caiu", false);
				anim.SetBool("pulando", false);
				caiu = false;
			}
		} else if(!isGrounded) {
			anim.SetBool("pulando", true);
		}
	}

	IEnumerator animarCaida() { // Tempo após cair
		yield return new WaitForSeconds(0.25f);
		caiu = true;
	}

	IEnumerator voltarTempo() {
		yield return new WaitForSeconds(0.05f);
		spritePlayer.color = Color.white;
		Time.timeScale = 1;
	}

	IEnumerator morrer() { // Tempo após morrer
		yield return new WaitForSeconds(0.5f);
		derrota.SetBool("perdeu", true);
		yield return new WaitForSeconds(1.2f);
		Time.timeScale = 0;
		Destroy(this.gameObject);
	}

	private void SpawnPedra() { // Spawn da plataforma
		Instantiate(chao, chaoSpawn.transform.position, chao.transform.rotation);
	}

	private void Salvar() {
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
