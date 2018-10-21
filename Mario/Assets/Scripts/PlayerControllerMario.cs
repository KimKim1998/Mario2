using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMario : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private bool facingRight = true;
    private Animator anim;
    public AudioSource MarioJump;
    public AudioSource Tongue;
    public AudioSource PickupCoin;
    public AudioSource PowerUp;

    public float speed;
    public float jumpforce;

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    private GameObject Player;




    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player"); // Name of the player object


    }

    void Awake()
    {

        // source = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("jump");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Tongue");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            anim.SetTrigger("Crouch");
        }

    }

    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("Horizontal");

        //Vector2 movement = new Vector2(movehorizontal, 0);

        // rb2d.AddForce(movement * speed);

        rb2d.velocity = new Vector2(movehorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        Debug.Log(isOnGround);


        if (facingRight == false && movehorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && movehorizontal < 0)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Tongue.Play();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            PickupCoin.Play();
        }

        if (other.gameObject.CompareTag("Mushrooms"))
        {
            other.gameObject.SetActive(false);

            PowerUp.Play();
        }

        if (other.gameObject.tag == "Player")
        {

            this.transform.position = new Vector3(0 - 1000, 0);

            Player.transform.localScale += new Vector3(0.2F, 0.2F, 0.2F);
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
                // rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpforce;

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    MarioJump.Play();
                }
            }


        }
    }
}