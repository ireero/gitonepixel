using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public Transform groundCheck;
	public float speed = 4f;
	public float jumpForce = 200f;
	public LayerMask whatIsGround;
	public bool umTiro = true;

	[HideInInspector]
	public bool lookingRight = true;

	protected Rigidbody2D rb2d;
	public bool isGrounded = false;
	protected bool jump = false;

	//Variaveis do tiro
	public Transform bulletSpawn;
	public GameObject bulletObject;
	protected SpriteRenderer spritePlayer;

	// Animações
	protected Animator anim;
	protected bool caiu = false;

	public Text texto;
	protected BoxCollider2D playerCollider;
	protected PolygonCollider2D colliderAbaixado;

	// Spawn Chão
	public Transform chaoSpawn;
	public GameObject chao;
	protected bool podePor = true;

	// UI
	public Animator derrota;
	protected int recorde;

	// Pode se mover
	public static bool pode_mover = true;
	public static bool pode_atirar;
	public GameObject superBullet;

	//valores
	protected int valor_entrada;

	public static bool final = false;

	public Button btn_pausar;

	protected int umaVez = 0;
	protected int umaVez2 = 0;

	protected float taxa_tiros;
	protected float cont;

	protected bool virado;
	protected bool podeVirar;

	public Transform padrao;

	protected virtual void Start () {
		podeVirar = false;
		virado = false;
		taxa_tiros = 0.25f;
		cont = 0;
		pode_atirar = true;
		Time.timeScale = 1;
		final = false;
		valor_entrada = 0; 
		rb2d = GetComponent<Rigidbody2D> ();
		spritePlayer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		playerCollider = GetComponent<BoxCollider2D>();
		recorde = PlayerPrefs.GetInt("recorde");
		Pontuacao.ZerarPontos();
		Pontuacao.monstros = 0;
		Pontuacao.time = 0;
	}
	
	protected virtual void Update () {

		Final();
		Pontuacoes();
		
		if(pode_mover) {
			inputCheck ();
			move ();
		}
		texto.text = Pontuacao.GetPontos().ToString();

		if(isGrounded) {
			podePor = false;
			podeVirar = false;
		} else {
			podeVirar = true;
			podePor = true;
		}

		Salvar();
	}

	protected void inputCheck (){

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

			if(Pontuacao.GetPontos() >= 100) {
				if(Input.GetKeyDown(KeyCode.Space)) {
				rb2d.bodyType = RigidbodyType2D.Static;
				pode_atirar = false;
				anim.SetBool("super_tiro", true);
			}
			} 
		}
	}

	void Pontuacoes() {
		if(Pontuacao.monstros >= 1000 && umaVez == 0) {
			btn_pausar.gameObject.SetActive(false);
			PainelPause.final = true;
            SpawnChao.podeSopawn = false;
			umaVez++;
        }
	}

	void Final() {
		if(final) {
			if(umaVez2 == 0) {
				anim.SetBool("objeto", true);
				StartCoroutine("cairObjeto");
				umaVez2++;
			}
			StartCoroutine("finalJogo");
		}
	}

	protected void move(){

		float horizontalForceButton = Input.GetAxis ("Horizontal");
		rb2d.velocity = new Vector2 (horizontalForceButton * speed, rb2d.velocity.y);
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.215f, whatIsGround);

		Animar();

		if ((horizontalForceButton > 0 && !lookingRight) || (horizontalForceButton < 0 && lookingRight))
			Flip ();

		if (jump) {
			GerenciaAudio.inst.PlaySomSfx(1, "SfxPlayer");
			rb2d.AddForce(new Vector2(0, jumpForce));
			jump = false;
		}
	}

	protected void Flip(){
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

	protected void Fire() {

		GerenciaAudio.inst.PlaySomSfx(2, "SfxPlayer");

		GameObject cloneBullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);

		if(!lookingRight)
			cloneBullet.transform.eulerAngles = new Vector3(0, 0, 180);
	}

	private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("monstro") || other.gameObject.CompareTag("mguenta") 
			|| other.gameObject.CompareTag("bullet_inimiga") || other.gameObject.CompareTag("super_tiro") ||
				other.gameObject.CompareTag("aguenta_tirao")) {
			Gerenciador.mortes_player++;
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
			speed -= 0.6f;
			jumpForce -= 9f;
			valor_entrada++;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("mago")) {
			speed += 0.6f;
			jumpForce += 9f;
			valor_entrada--;
			if(valor_entrada <= 0) {
				spritePlayer.color = Color.white;
			}
		}
	}

	protected void Morrer() { // Tudo que rola quando morre
		PlayerPrefs.SetInt("conquista_morrer_20", Gerenciador.mortes_player);
		GerenciaAudio.inst.PlaySomSfx(0, "SfxPlayer");
		playerCollider.isTrigger = true;
		rb2d.bodyType = RigidbodyType2D.Static;
        anim.SetBool("morreu", true);
		Destroy(bulletSpawn.gameObject);
		StartCoroutine("morrer");
	}

	protected void Animar() { // Animações
		if(isGrounded) {
			anim.SetBool("caiu", true);
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

	protected void SpawnPedra() { // Spawn da plataforma
		Instantiate(chao, chaoSpawn.transform.position, chao.transform.rotation);
	}

	protected virtual void Salvar() { // Salvar o recorde do jogador se pontos for maior que recorde
		if(Pontuacao.GetPontos() > Pontuacao.GetRecorde()) {
			recorde = Pontuacao.GetPontos();
			PlayerPrefs.SetInt("recorde", recorde);
		}
	}

	IEnumerator finalJogo() {
		yield return new WaitForSeconds(8.0f);
		anim.SetBool("acabou", true);
	}

	IEnumerator cairObjeto() {
		yield return new WaitForSeconds(0.7f);
		anim.SetBool("objeto", false);
	}

	protected void posTirao() {
		rb2d.bodyType = RigidbodyType2D.Dynamic;
		anim.SetBool("super_tiro", false);
		pode_atirar = true;
	}

	protected void Tirao() {
        if(umTiro) {
			GameObject Super = Instantiate(superBullet, bulletSpawn.position, bulletSpawn.rotation);
			if(!lookingRight)
			Super.transform.eulerAngles = new Vector3(0, 0, 180);
			umTiro = false;
		}
	}
}
