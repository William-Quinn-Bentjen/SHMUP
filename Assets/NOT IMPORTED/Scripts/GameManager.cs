using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameObject Player;
	// Use this for initialization
	void Start () {
        //originally the player told the game manager what it was but that causes null reference exeptions in some cases (for more info see the player controller script)
        //Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
