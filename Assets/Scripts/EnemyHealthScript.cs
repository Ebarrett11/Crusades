using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour {
    //global variables
    //accesible by any method in this class/script
    public int hp = 1;
    public bool isEnemy = true; //IDs character as an enemy

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {    
		
	}

    void Damage(int damageCount)
    {
        //creates an object that has access to WeaponScript 
        //methods and variables
        WeaponScript enemyCount = GetComponent<WeaponScript>();

        hp -= damageCount; //decreases the health by damage of weapon

        if(hp <= 0)
        {
            Destroy(gameObject);//destroy this character
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //creating an connection to the shot script so we can 
        //acces its methods and variables 
        ShotScript shot = col.gameObject.GetComponent<ShotScript>();

        if(shot != null) //if there is a shot
        {
            if(shot.isEnemyShot != isEnemy)//if the enemy hasn't been shot 
            {
                Damage(shot.damage); //apply damge to enemy
                Destroy(shot.gameObject);//remove the projectile from the screen
            }
        }
    }
}
