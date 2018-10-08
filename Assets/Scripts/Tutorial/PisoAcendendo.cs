using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoAcendendo : MonoBehaviour {

GameObject piso;

	// Use this for initialization
	void Start () {
		
		piso = GameObject.FindGameObjectWithTag("acesso");
		
	}
	
	// Update is called once per frame
	void Update () {
			if(PortaFase2.pisocor == true){
			
			piso.GetComponent<Animator>().SetBool("Fixou", true);
		}
	}


}
