using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour {
	public float health;


	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			if (gameObject.tag == "Enemy") {
				Destroy (gameObject);
				GameObject thePlayer = GameObject.Find("ThePlayer");
				var playerScript = thePlayer.GetComponent<PlayerMovement>();
				playerScript.killcount++;
			}

		}
			//gameObject.SetActive(false);
	}

	public void takeDam(int dam) {
		if (health - dam < 0)
			health = 0;
		else
			health -= dam;
	}

	public void takeHeal(int heal) {
		if (health + heal > 100)
			health = 100;
		else
			health += heal;
	}
}
