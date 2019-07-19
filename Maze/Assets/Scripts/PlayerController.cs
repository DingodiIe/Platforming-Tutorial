using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;


    public AudioClip MusicClip;

    Animator anim;
    public AudioSource MusicSource;
    public Text countText;
    public Text winText;

    public Text livesText;
  //  public Transform groundcheck;
  //  bool grounded = false;
    public float speed;
    private int count;
    //private int score;

    private int teleport;

     private int lives;
    public float jumpforce;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();
       MusicSource.clip = MusicClip;
        lives = 3;
        teleport = 0;
        SetCountText ();
        
        SetLivesText ();
         

        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey (KeyCode.RightArrow)){
           
             anim.SetInteger("New Int", 1);
        }
        if(Input.GetKey (KeyCode.LeftArrow)){
            anim.SetInteger("New Int", 3);
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) <= 0.1){
             
        anim.SetInteger("New Int", 0);
       }
       if (Mathf.Abs(Input.GetAxis("Vertical")) >= .1){
             
        anim.SetInteger("New Int", 2);
       }
       if(Input.GetKey (KeyCode.UpArrow)){
           anim.SetInteger("New Int", 2);
       }

    }

 void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.CompareTag ("Pickup"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
         }

         if (other.gameObject.CompareTag("Enemy"))
     {
         other.gameObject.SetActive (false);
         
         
         lives = lives - 1;
         SetCountText ();
        
         SetLivesText ();
     }
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
              Application.Quit();

        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
       // grounded = Physics2D.Linecast(transform.position, groundcheck.position, 1<< LayerMask.NameToLayer("Ground"));
        if(collision.collider.tag == "Ground") {
            if(Input.GetKeyDown(KeyCode.UpArrow)) {

                rb2d.AddForce(new Vector2 (0, jumpforce), ForceMode2D.Impulse);
                //grounded = false;

            }
        }
         if(collision.collider.tag != "Ground"){
           
         }
    }

    void SetCountText(){

  countText.text = "Score: " + count.ToString ();
    
    if (count >= 4){
        if (teleport <= 0){
        transform.position = new Vector2(27.02f, 2.31f);
         teleport = teleport + 1;
         lives = 3;
         SetLivesText();}
    }
    if (count >= 8){
        winText.text = "You win!";
        gameObject.SetActive(false);
        MusicSource.Play();
    }
    }



    void SetLivesText(){
livesText.text = "Lives: " + lives.ToString ();
       if (lives <= 0)
        {winText.text = "You Lose!";
        gameObject.SetActive(false);
       
        }
}
}
