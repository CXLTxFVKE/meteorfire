using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {
	
	public int killcount = 0;
	public int gold = 0;
	private GameObject thePlayer; 
	private PlayerMovement playerScript;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find("Player");
		playerScript = thePlayer.GetComponent<PlayerMovement>();
	}


	// Update is called once per frame
	void Update () {
		//var playerScript = thePlayer.GetComponent<PlayerMovement>();
		if (playerScript.playerlevel == killcount)
		killcount = 0;
		playerScript.playerlevel++;
	}
}
