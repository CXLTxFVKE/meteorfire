using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunlightscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = Vector3.one * Random.Range (3.5f, 4f);
		Destroy (gameObject, Random.Range(0.02f,0.06f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
