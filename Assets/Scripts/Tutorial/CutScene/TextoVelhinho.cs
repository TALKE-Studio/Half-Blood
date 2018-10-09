using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoVelhinho : MonoBehaviour {

	public GameObject texto1;
	public GameObject texto2;
	public GameObject texto3;
	



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			StartCoroutine(Texto1());
			
		}
	}

	IEnumerator Texto1(){
		yield return new WaitForSeconds (2f);
		texto1.SetActive(true);
		StartCoroutine(Texto2());
	}

	IEnumerator Texto2(){
		yield return new WaitForSeconds (17f);
		texto2.SetActive(true);
		StartCoroutine(Texto3());
	}

	IEnumerator Texto3(){
		yield return new WaitForSeconds (32f);
		texto3.SetActive(true);
	}

}
