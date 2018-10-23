using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoSala2 : MonoBehaviour {

	public GameObject texto5;
	public GameObject texto6;
	public GameObject textoContinuar;
	bool podeavancar = false;
	public static bool avancou;
	Touch touch;
	GameObject colissor;
	GameObject canvasBotoes;

	
	// Use this for initialization
	void Start () {
		canvasBotoes = GameObject.FindGameObjectWithTag("Botoes");
		colissor = GameObject.FindGameObjectWithTag("Colissor3");
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
		if((Input.GetKeyDown(KeyCode.Space)|| Input.GetTouch(i).phase == TouchPhase.Began ||Input.GetMouseButtonDown (0) ) && podeavancar == true)
		{
			texto5.GetComponent<Animator>().SetBool("Proximo", true);
			texto5.GetComponent<Animator>().SetBool("Fechartexto", true);
			textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
			avancou = true;
			StartCoroutine(Texto6());
		}
		}
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){
			
			StartCoroutine(Texto5());
			
		}
		
	}

		IEnumerator Texto5(){
		yield return new WaitForSeconds (0.3f);
		texto5.SetActive(true);
		canvasBotoes.GetComponent<Canvas>().enabled = false;
		StartCoroutine(Trava());
		StartCoroutine(Continuar());
	}

	IEnumerator Trava(){
		yield return new WaitForSeconds(6f);
		podeavancar = true;

	}

	IEnumerator Texto6(){
		yield return new WaitForSeconds(2f);
		texto6.SetActive(true);
		textoContinuar.SetActive(false);
		podeavancar = false;
		StartCoroutine(Destruir());
	}

	IEnumerator Continuar(){
		yield return new WaitForSeconds (5f);
		textoContinuar.SetActive(true);
	}

	IEnumerator Destruir(){
		yield return new WaitForSeconds (2f);
		texto5.SetActive(false);
		Destroy(colissor.gameObject);
	}
}
