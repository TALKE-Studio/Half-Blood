using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararDeAndar : MonoBehaviour {

	GameObject personagem;
	public static bool pare;
	

	// Use this for initialization
	void Start () {
		personagem = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			print("PARA DE ANDAR PORRA");
			pare = true;
			Sala3.animacaoAndar = false;
		}
	}

}
