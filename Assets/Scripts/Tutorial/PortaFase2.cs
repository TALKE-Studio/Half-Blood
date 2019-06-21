using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaFase2 : MonoBehaviour {
	GameObject porta;
	public static bool pisocor = false;

	// Use this for initialization
	void Start () {

		porta = GameObject.Find("PortaTutorial2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "LoboTutoba"){
			pisocor = true;
			print("aloooooo");
			porta.GetComponent<Animator>().SetBool("Abrir", true);
			porta.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
