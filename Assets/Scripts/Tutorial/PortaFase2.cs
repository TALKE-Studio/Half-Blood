using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaFase2 : MonoBehaviour {
	GameObject porta;
	// Use this for initialization
	void Start () {
		porta = GameObject.FindGameObjectWithTag("PortaTutorial2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "LoboTutoba"){
			print("aloooooo");
			porta.GetComponent<Animator>().SetBool("Abrir", true);
		}
	}
}
