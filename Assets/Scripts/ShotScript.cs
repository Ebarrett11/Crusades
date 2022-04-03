using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {


    //define what it can kill and how to kill it

    public int damage = 1; //how lethal your projectile is

    public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 20);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
