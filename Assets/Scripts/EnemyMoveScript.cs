using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMoveScript : MonoBehaviour {
    public bool check = true;
    public bool lateral = true;
    public Rigidbody2D ghostRB2D;
    public float ghostInput = -1;
    private float movePlayerVector;
    public float ghostSpeed = 1f;
    public bool facingRight = false;
    private Animator anim;
    private SpriteRenderer ghostSpriteRenderer;
    public bool enemyShootInput = true;
	// Use this for initialization
	void Start () {
        ghostRB2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ghostSpriteRenderer = GetComponent<SpriteRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {
        movePlayerVector = ghostInput;
        ghostRB2D.velocity = new Vector2(ghostRB2D.velocity.x, movePlayerVector * ghostSpeed);
        if (check == true){
            anim.Play("Ghost Move");
        }
        

         ////////////////////////////////////////////////
        ///Weapon logic
        ////////////////////////////////////////////////

        bool shoot = enemyShootInput;
        if (shoot)
        {
            EnemyWeaponScript weapon = GetComponent<EnemyWeaponScript>();
            if(weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }

    void Flip()
    {
        if (lateral == true)
        {
            facingRight = !facingRight;
        }
        if(ghostSpriteRenderer.flipX == true)
        {
            if (lateral == true)
            {
                ghostSpriteRenderer.flipX = false;
            } 
            ghostInput *= -1;
        }
        else
        {
            if (lateral == true)
            {
                ghostSpriteRenderer.flipX = true;
            }
            ghostInput *= -1;
        }
    }
    //function to identify and react to whatever the enemy
    //just collided with
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "LeftWall") {

            Flip();
        }
        else if (col.gameObject.name == "RightWall")
        {
                Flip();
        }
    }
}


