using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoVelhinho : MonoBehaviour {

	public GameObject texto1;
	public GameObject texto2;
	public GameObject textoContinuar;
	bool podeavancar = false;
	public static bool avancou;
	Touch touch;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if((Input.GetKeyDown(KeyCode.Space)|| Input.touchCount > 0) && podeavancar == true){
			texto1.GetComponent<Animator>().SetBool("Proximo", true);
			texto1.GetComponent<Animator>().SetBool("Fechartexto", true);
			textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
			avancou = true;
			StartCoroutine(Texto2());
		}
		
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			StartCoroutine(Texto1());
			
		}
		
	}

	IEnumerator Texto1(){
		yield return new WaitForSeconds (2f);
		texto1.SetActive(true);
		StartCoroutine(Trava());
		StartCoroutine(Continuar());
	}

	IEnumerator Trava(){
		yield return new WaitForSeconds(6f);
		podeavancar = true;

	}

	IEnumerator Texto2(){
		yield return new WaitForSeconds(1.5f);
		texto2.SetActive(true);
		textoContinuar.SetActive(false);
		podeavancar = false;
	}

	IEnumerator Continuar(){
		yield return new WaitForSeconds (5f);
		textoContinuar.SetActive(true);
	}

}
