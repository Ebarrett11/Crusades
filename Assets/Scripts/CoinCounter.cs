using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour {

    int coinCounter;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //connect the cm class in order to get coins collided with 

        GameObject kn = GameObject.Find("Knight");

        CharacterMovement Knight = kn.GetComponent<CharacterMovement>();

        //assign mario's coin collsiosn to local coin counter variable
        coinCounter = Knight.coinCounter;

        GameObject coinCount = GameObject.Find("Pumpkin");
    }

  
}
