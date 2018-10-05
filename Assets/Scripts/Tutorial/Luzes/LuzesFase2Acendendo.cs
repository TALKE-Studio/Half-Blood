using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzesFase2Acendendo : MonoBehaviour {

	public Light[] luzesFase2;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){
			foreach(Light luz in luzesFase2){
				luz.intensity = 1.3f;
			}
		}

	}

}
