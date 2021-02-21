using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSurvival : MonoBehaviour {
	public Transform groundCheck;
	public float speed = 4f;
	public float jumpForce = 200f;
	public LayerMask whatIsGround;

	[HideInInspector]
	public bool lookingRight = true;

	private Rigidbody2D rb2d;
	public bool isGrounded = false;
	private bool jump = false;

	//Variaveis do tiro
	public Transform bulletSpawn;
	public GameObject bulletObject;
	private SpriteRenderer spritePlayer;
	public AudioClip pulo;
	public AudioClip tiroAudio;

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

	void Start () {
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
	}

	void inputCheck (){

		if ((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetKeyDown(KeyCode.W) && isGrounded)){
			jump = true;
		}

		if(Input.GetKeyDown(KeyCode.X)) {
			if(podePor) {
				SpawnPedra();
			}
		}

		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			anim.SetBool("abaixou", true);
		}

		if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) {
			anim.SetBool("abaixou", false);
		}

		if(Input.GetKeyDown(KeyCode.Z)) {
			Fire();
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
			GerenciadorAudio.inst.PlayPulo(pulo);
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

		GerenciadorAudio.inst.PlayTiro(tiroAudio);

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
		GerenciadorAudio.inst.PlayMorte(som_morte);
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

	IEnumerator morrer() { // Tempo após morrer
		yield return new WaitForSeconds(0.5f);
		derrota.SetBool("perdeu", true);
		yield return new WaitForSeconds(1.2f);
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
}
