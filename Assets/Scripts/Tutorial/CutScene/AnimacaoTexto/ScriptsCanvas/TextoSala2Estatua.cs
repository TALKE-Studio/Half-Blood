using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoSala2Estatua : MonoBehaviour {

	public GameObject texto7;	
	public GameObject textoContinuar;
	GameObject canvasBotoes;
	Touch touch;
	GameObject colissor;
	bool podeavancar = false;

	// Use this for initialization
	void Start () {

		
		canvasBotoes = GameObject.FindGameObjectWithTag("Finish");
		colissor = GameObject.Find("Texto2Collider2");
		}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
		if((Input.GetKeyDown(KeyCode.Space)|| Input.GetTouch(i).phase == TouchPhase.Began ||Input.GetMouseButtonDown (0) ) && podeavancar == true)
		{
			print("QQQQQQQQQQQQQQQQQQQQQQ");
			texto7.GetComponent<Animator>().SetBool("Proximo", true);
			textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
			StartCoroutine(Voltarbotao());
			StartCoroutine(Destroir());
		}
		}
		if(Input.GetKeyDown(KeyCode.Space)&& podeavancar == true)
		{
			texto7.GetComponent<Animator>().SetBool("Proximo", true);
			textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
			StartCoroutine(Voltarbotao());
			StartCoroutine(Destroir());
		}
		
	}

		void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){
			
			StartCoroutine(Texto7());
			
		}
	}

	IEnumerator Texto7(){
		yield return new WaitForSeconds (0.3f);
		texto7.SetActive(true);
		canvasBotoes.GetComponent<Canvas>().enabled = false;
		RotacaoPersonagem.naoMexer = true;
        RotacaoPersonagem.x = 0;
        RotacaoPersonagem.z = 0;
		StartCoroutine(Trava());
		StartCoroutine(Continuar());
	}

	IEnumerator Voltarbotao(){
			yield return new WaitForSeconds(3f);
			canvasBotoes.GetComponent<Canvas>().enabled = true;
			RotacaoPersonagem.naoMexer = false;
		}

	IEnumerator Trava(){
		yield return new WaitForSeconds(6f);
		podeavancar = true;

	}

	IEnumerator Continuar(){
		yield return new WaitForSeconds (5f);
		textoContinuar.SetActive(true);
	}

	IEnumerator Destroir(){
		yield return new WaitForSeconds(3f);
		texto7.SetActive(false);
		textoContinuar.SetActive(false);
		Destroy(colissor.gameObject);
	}
}
