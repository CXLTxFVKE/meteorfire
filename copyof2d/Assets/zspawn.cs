using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zspawn : MonoBehaviour {

	public bool canspawn;
	public GameObject Zombie;
	public Vector3 thepos;

	// Use this for initialization
	void Start () {
		thepos = transform.position;
		StartCoroutine (spawnwave ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnwave()
	{
		while (true){
			Instantiate (Zombie,thepos, Quaternion.identity);
		yield return new WaitForSeconds (3);
	}
	//	StartCoroutine (spawnwave ());
	}
}
