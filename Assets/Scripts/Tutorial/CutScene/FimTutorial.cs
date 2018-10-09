using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimTutorial : MonoBehaviour {

	public GameObject Texto_Tutorial;
	public GameObject Imagem_Tutorial;
	public GameObject Tela_Final;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			StartCoroutine(Conquista());
			StartCoroutine(TelaBranca());
		}
	}

	IEnumerator Conquista(){
		yield return new WaitForSeconds(7f);
		Texto_Tutorial.SetActive(true);
		Imagem_Tutorial.SetActive(true);
	}
	IEnumerator TelaBranca(){
		yield return new WaitForSeconds(14f);
		Tela_Final.SetActive(true);
	}
}
