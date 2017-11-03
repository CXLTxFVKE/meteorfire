using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject Wall;
	GameObject Wallclone;
	public bool canbuild;


	private GameObject player, weapon;
	private Vector3 offset;

	void Awake()
	{
		player = GameObject.FindWithTag("Player");
		offset = gameObject.transform.position - player.transform.position;
	}

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.position = player.transform.position + offset;

		var camerapos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		camerapos.z = 0;
		/*
		if (Input.GetKeyDown(KeyCode.B))
		{
			weapon.canshoot = !weapon.canshoot);
			canbuild = !canbuild;
		}

		if (Input.GetMouseButtonDown (0) && canbuild)
			
				Instantiate (Wall, camerapos, Quaternion.identity);
				*/
	}
	
}