using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptdeteste : MonoBehaviour {
	GameObject lampada;
	// Use this for initialization
	void Start () {
		lampada = GameObject.FindGameObjectWithTag("teste");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			lampada.GetComponentInChildren<Light>().intensity = 1.3f;
		}
	}

}
