using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoSala3 : MonoBehaviour {

	public GameObject texto7;
	public GameObject texto8;
	public GameObject textoContinuar;
	bool podeavancar = false;
	public static bool avancou;
	Touch touch;
	GameObject colissor;
	GameObject canvasBotoes;


	// Use this for initialization
	void Start () {
		canvasBotoes = GameObject.FindGameObjectWithTag("Finish");
		colissor = GameObject.Find("Texto2Collider3");
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
		if((Input.GetKeyDown(KeyCode.Space)|| Input.GetTouch(i).phase == TouchPhase.Began ||Input.GetMouseButtonDown (0) ) && podeavancar == true)
		{
			texto7.GetComponent<Animator>().SetBool("Proximo", true);
			texto7.GetComponent<Animator>().SetBool("Fechartexto", true);
			textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
			
			StartCoroutine(Destroir());
			StartCoroutine(IrTexto8());
			avancou = true;
			
		}
		}
		if(Input.GetKeyDown(KeyCode.Space)&& podeavancar == true)
		{
			texto7.GetComponent<Animator>().SetBool("Proximo", true);
			texto7.GetComponent<Animator>().SetBool("Fechartexto", true);
			textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
			
			StartCoroutine(Destroir());
			StartCoroutine(IrTexto8());
			avancou = true;
		}
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){
			
			StartCoroutine(Texto7());
			
		}
		
	}

	IEnumerator Texto7(){
		yield return new WaitForSeconds (0.2f);
		texto7.SetActive(true);
		canvasBotoes.GetComponent<Canvas>().enabled = false;
		RotacaoPersonagem.naoMexer = true;
        RotacaoPersonagem.x = 0;
        RotacaoPersonagem.z = 0;
		StartCoroutine(Trava());
		StartCoroutine(Continuar());
	}

	IEnumerator IrTexto8(){
		yield return new WaitForSeconds(2f);
		texto8.SetActive(true);
		textoContinuar.SetActive(false);
		podeavancar = false;
		StartCoroutine(Destroir());
	}

	IEnumerator Continuar(){
		yield return new WaitForSeconds (5f);
		textoContinuar.SetActive(true);
	}

	IEnumerator Trava(){
		yield return new WaitForSeconds(6f);
		podeavancar = true;
	}

	IEnumerator Destroir(){
		yield return new WaitForSeconds(3f);
        texto7.SetActive(false);
        
		Destroy(colissor.gameObject);
	}

}
