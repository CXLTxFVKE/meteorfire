using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
	protected Vector3 mousepos;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousepos.z = 0;
		transform.position = mousepos;
	}
}
