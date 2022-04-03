using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnightHealth : MonoBehaviour {

    //global variables
    //accesible by any method in this class/script
    public int hp = 3;
    public bool isPlayer = true; //IDs character as an enemy

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
        EnemyWeaponScript enemyCount = GetComponent<EnemyWeaponScript>();

        hp -= damageCount; //decreases the health by damage of weapon

        if (hp <= 0)
        {
            Destroy(gameObject);//destroy this character
            SceneManager.LoadScene(2);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //creating an connection to the shot script so we can 
        //acces its methods and variables 
        EnemyShotScript shot = col.gameObject.GetComponent<EnemyShotScript>();

        if (shot != null) //if there is a shot
        {
            if (shot.isPlayerShot != isPlayer)//if the enemy hasn't been shot 
            {
                Damage(shot.damage); //apply damge to enemy
                Destroy(shot.gameObject);//remove the projectile from the screen
            }
        }
    }


    //method will print data on the screen
    /*void OnGUI()
    {
        //gui that will make labels and images appear
        GUI.color = Color.yellow;
        GUIStyle textStyle = new GUIStyle();
        textStyle.normal.textColor = Color.yellow;
        textStyle.fontSize = 40;
        GUI.Label(new Rect(400, 10, 100, 100), "Health: " + hp, textStyle);
    }*/

}
