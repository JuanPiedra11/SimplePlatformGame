using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{

    //Movement variables
    public float runSpeed;
    public float walkSpeed;

    // Variables Coins

    public CoinCollection scriptcoinCollection;


    public Rigidbody myRB;
    Animator myAnim;

    bool facingRight;

    // for jumping
    public bool grounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    

    public float altura;
    public bool canMove;

    public AudioClip LoseCoin;


    public Transform respawnPoint;
    public GameObject myCamara;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody> ();
        myAnim = GetComponent<Animator> (); 
         scriptcoinCollection = GetComponent<CoinCollection> ();
        facingRight = true;
        canMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if (transform.position.y < -8)
        {

        if (scriptcoinCollection.Coin>0) {
                scriptcoinCollection.Coin--;
            }
           
            
            Respawn();
        }
        
    }

    void FixedUpdate(){

        if (canMove) { 

        if(grounded && UnityEngine.Input.GetAxis("Jump") > 0){
            grounded = false;
            myAnim.SetBool("grounded", grounded);
            myRB.AddForce(new Vector3(0, jumpHeight, 0));
        }

        



        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(groundCollisions.Length > 0) grounded = true;    
        else grounded = false;

        myAnim.SetBool("grounded", grounded);

        float move = UnityEngine.Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        
        float sneaking = UnityEngine.Input.GetAxisRaw("Fire3");
        myAnim.SetFloat("sneaking", sneaking);

        if (sneaking > 0 && grounded){
            
            myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0);
        }
        else
        {
            myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
        }



        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }

    void Respawn()
    {
        AudioSource.PlayClipAtPoint(LoseCoin, myCamara.transform.position, 3);
        myRB.velocity = Vector3.zero;
        myRB.angularVelocity = Vector3.zero;
        myRB.Sleep();
        transform.position = respawnPoint.position;
        if (facingRight == false) Flip();
        

    }
}
