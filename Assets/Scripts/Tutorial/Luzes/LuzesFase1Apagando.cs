using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzesFase1Apagando : MonoBehaviour {

	public Light[] luzesFase1;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){
			foreach(Light luz in luzesFase1){
				luz.intensity = 0f;
			}
		}

	}


}
