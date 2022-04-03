using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    //cooldown rate, how to know wherre to shoot
    //which direction the pojectile should go

    //variables here
    public Transform shotPrefab;

    public float shootingRate = 0.25f;

    private float shootCoolDown;

    private SpriteRenderer projectileRenderer;
    // Use this for initialization
    void Start()
    {
        shootCoolDown = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        //---------------------------------------------------------------
        //2. cooldown section
        //---------------------------------------------------------------

        //if there is a shootCoolDown wait time
        //start counting down to zero
        if (shootCoolDown > 0)
        {
            shootCoolDown -= Time.deltaTime;

        }
    }
    //-------------------------------------------------------------------
    //3. Shooting from another script
    //-------------------------------------------------------------------

    //is there an enemy to attack
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCoolDown = shootingRate;

            //create a new weapon instance
            var shotTransform = Instantiate(shotPrefab) as Transform;

            //assign position for the new weapon instance
            shotTransform.position = transform.position;

            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;

            }
            //Make the weapon shoot towards the anemy and away from the main character
            ShotMoveScript move = shotTransform.gameObject.GetComponent<ShotMoveScript>();

            //making a connection to charactermovement script to determine which way
            //your character is facing
            CharacterMovement facingDirection = GetComponent<CharacterMovement>();
            if (move != null)
            {
                if (facingDirection.facingRight)
                {
                    move.direction = this.transform.right; //right
                }
                else
                {
                    //projectileRenderer.flipX = true;
                    move.direction = this.transform.right * -1; //left

                }
            }
        }
    }//end of attack method


    public bool CanAttack
    {
        get
        {
            //
            return shootCoolDown <= 0f;
        }


    }
}
