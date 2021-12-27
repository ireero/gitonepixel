using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class Player : MonoBehaviour {
   public Transform groundCheck;
   public float speed = 1f;
   public float jumpForce = 90f;
   public LayerMask whatIsGround;
 
   [HideInInspector]
   public bool lookingRight = true;
 
   private Rigidbody2D rb2d;
   private bool isGrounded = false;
   private bool jump = false;

   private Animator anim;

   public static bool pode_mexer;

   private BoxCollider2D player_collider;

   private SpriteRenderer sr;

   private bool doubleJump;
   private bool podePor;
   public GameObject plataforma;
   public GameObject tiro_branco;
   public Transform spawn_tiro;
 
   void Start () {  
      podePor = false;
      pode_mexer = true;
      doubleJump = true;
      player_collider = GetComponent<BoxCollider2D>();
      anim = GetComponent<Animator>();
      rb2d = GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();
   }
 
   void Update () {
      
      if(pode_mexer) {
         inputCheck ();
         move ();
      }

      if(isGrounded) {
          doubleJump = true;
          podePor = false;
      } else {
         podePor = true;
      }
   }
 
   void inputCheck (){
      if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded){
      jump = true;
      } else if(((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)) {
         jump = true;
      } else if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !isGrounded && doubleJump) {
            jump = true;
            doubleJump = false;
      }

      if(Input.GetKeyDown(KeyCode.X) && podePor) {
         Instantiate(plataforma, groundCheck.position, groundCheck.rotation);
      }

      if(Input.GetKeyDown(KeyCode.Z)) {
         Instantiate(tiro_branco, spawn_tiro.position, spawn_tiro.rotation);
      }
   }
 
   void move(){
      float horizontalForceButton = Input.GetAxis ("Horizontal");
      rb2d.velocity = new Vector2 (horizontalForceButton * speed, rb2d.velocity.y);
      isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.05f, whatIsGround);
 
      if ((horizontalForceButton > 0  && !lookingRight) || (horizontalForceButton < 0 && lookingRight)) {
         Flip ();
      }

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

}