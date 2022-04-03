using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotScript : MonoBehaviour {


    //define what it can kill and how to kill it

    public int damage = 1; //how lethal your projectile is

    public bool isPlayerShot = false;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 4);
    }
}
