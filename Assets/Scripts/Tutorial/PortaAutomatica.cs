using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaAutomatica : MonoBehaviour {
	GameObject porta;
	// Use this for initialization
	void Start () {
		porta = GameObject.FindGameObjectWithTag("PortaTutorial");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			print("Olha so");
			porta.GetComponent<Animator>().SetBool("Abrir", true);
		}

	}
}
