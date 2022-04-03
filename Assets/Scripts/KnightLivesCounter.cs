using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightLivesCounter : MonoBehaviour {

    public Sprite[] healthHearts; //variable that can hold onto multiple pieces of data

    public Image HealthUI; //create and image object to hold array images
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //make a connection to a data assigned to a game object in unity
     
        GameObject thePlayer = GameObject.Find("Knight");

        //create an object that will access Knight's health variable
        KnightHealth hp = thePlayer.GetComponent<KnightHealth>();

        //shows the health images that is in the array index according 
        //to current health points
        HealthUI.sprite = healthHearts[hp.hp];
	}
}
