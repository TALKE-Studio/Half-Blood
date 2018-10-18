using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedraVerdeInv : MonoBehaviour {

	GameObject pedrinha;

	// Use this for initialization
	void Start () {
		pedrinha = GameObject.FindGameObjectWithTag("PedraVerdeInv");
		StartCoroutine(Pedra());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Pedra(){
		yield return new WaitForSeconds(1f);
		pedrinha.GetComponent<MeshRenderer>().enabled = false;
	}
}
