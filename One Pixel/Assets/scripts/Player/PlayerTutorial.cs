using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTutorial : MonoBehaviour {
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

	private BoxCollider2D playerCollider;

	// Spawn Chão
	public Transform chaoSpawn;
	public GameObject chao;
	private bool podePor = true;

	// Pode se mover
	public static bool pode_mover = true;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		spritePlayer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		playerCollider = GetComponent<BoxCollider2D>();
	}
	
	void Update () {
		if(pode_mover) {
			inputCheck ();
			move ();
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

		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			anim.SetBool("abaixou", true);
		}

		if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) {
			anim.SetBool("abaixou", false);
		}

		if(Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)) {
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

	private void Morrer() { // Tudo que rola quando morre
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

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("portal_voltar")) {
			SceneManager.LoadScene(0);
		}
	}

	IEnumerator animarCaida() { // Tempo após cair
		yield return new WaitForSeconds(0.25f);
		caiu = true;
	}

	private void SpawnPedra() { // Spawn da plataforma
		Instantiate(chao, chaoSpawn.transform.position, chao.transform.rotation);
	}

}
