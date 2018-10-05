using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(CutsScene.olharValk == true){
			Olhar();
		}
	}

	void Olhar(){
		transform.LookAt(target);
	}
}
