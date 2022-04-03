using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    //declare global variables
    private Rigidbody2D playerRigidBody2D;

    //keeping track of the characters coordinates
    public int x = 10;
    
    public int y = 10;

    private float movePlayerVector;

    public float speed = .5f;//max speed

    public float jumpPower = 1f;

    public float jumpTime = 1.5f;

    public bool facingRight;

    private Animator anim;

    private float canJump;

    public int coinCounter = 0;

    public AudioClip coinSound; //collect the sound effect from Unity
    private AudioSource source; //allows us to play to sound using Unity methods


    // Use this for initialization
    void Start()
    {
        //initializezs all items that must be working when the scene loads
        //when scene loads

        //connect RB variable to the Unity Object
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        //will get clip from object that also shares this script
        source = GetComponent<AudioSource>(); //getting clip from object sharing this script
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlayerVector = Input.GetAxis("Horizontal");
        playerRigidBody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidBody2D.velocity.y);

        //if requesting to go right and artwork facing right
        if (movePlayerVector > 0 && !facingRight)
        {
            Flip();
        }
        else if (movePlayerVector < 0 && facingRight)
        {
            Flip();
        }
        
        //logic for jumping
        if (Input.GetKeyDown("space") && Time.time > canJump)
        {
            //transform.Translate(Vector3.up * jumpPower * Time.deltaTime, Space.World);

            //more natural jump requiring ground touch
            canJump = Time.time + jumpTime; //add 1.5 seconds onto current tim
            //playerRigidBody2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            playerRigidBody2D.velocity = new Vector3(0, jumpPower, 0);

        }
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));


        ////////////////////////////////////////////////
        ///Weapon logic
        ////////////////////////////////////////////////

        bool shoot = Input.GetKeyDown(KeyCode.Mouse0);
        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if(weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }
    //flipping the artwork of our character across the y axis
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Balloons")
        {
            coinCounter++;
            Destroy(col.gameObject);
        }
        if(col.gameObject.name == "Pumpkin")
        {
            coinCounter++;
            //tell Unity to play the sound clip using source methods
            source.PlayOneShot(coinSound);
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "RightWall")
        {
            Debug.Log("made it");
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
    //void OnCollisionEnter(Collision collision)
    //{
       
    //}

    void OnGUI()
    {
        //gui that will make labels and images appear

        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 40;
        textStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(x, y, 100, 20), "" + coinCounter, textStyle);
    }
   
}