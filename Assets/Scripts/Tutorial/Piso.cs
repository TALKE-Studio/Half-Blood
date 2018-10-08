using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour {

	GameObject piso;

	// Use this for initialization
	void Start () {
		
		piso = GameObject.FindGameObjectWithTag("apagado");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PortaFase2.pisocor == true){
			piso.GetComponent<Renderer>().enabled = false;
		}
	}
}
