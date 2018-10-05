using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzesFase3Apagando : MonoBehaviour {

	public Light[] luzesFase3;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){
			foreach(Light luz in luzesFase3){
				luz.intensity = 0f;
			}
		}

	}
}
