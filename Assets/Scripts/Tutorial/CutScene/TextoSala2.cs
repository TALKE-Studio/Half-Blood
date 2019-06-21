using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoSala2 : MonoBehaviour {

	public GameObject texto5;
	public GameObject textoContinuar;
	bool podeavancar = false;
	public static bool avancou;
	Touch touch;
	GameObject colissor;
	GameObject canvasBotoes;

	
	// Use this for initialization
	void Start () {
		canvasBotoes = GameObject.FindGameObjectWithTag("Finish");
		colissor = GameObject.FindGameObjectWithTag("Texto2Collider");
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
		if((Input.GetKeyDown(KeyCode.Space)|| Input.GetTouch(i).phase == TouchPhase.Began ||Input.GetMouseButtonDown (0) ) && podeavancar == true)
		{
			texto5.GetComponent<Animator>().SetBool("Proximo", true);
			texto5.GetComponent<Animator>().SetBool("Fechartexto", true);
			textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
			StartCoroutine(Voltarbotao());
			StartCoroutine(Destruir());
			avancou = true;
			
		}
		}
		if(Input.GetKeyDown(KeyCode.Space)&& podeavancar == true)
		{
			texto5.GetComponent<Animator>().SetBool("Proximo", true);
			texto5.GetComponent<Animator>().SetBool("Fechartexto", true);
			textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
			StartCoroutine(Voltarbotao());
			StartCoroutine(Destruir());
			avancou = true;
		}
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){
			
			StartCoroutine(Texto5());
			
		}
		
	}

		IEnumerator Voltarbotao(){
			yield return new WaitForSeconds(1f);
			canvasBotoes.GetComponent<Canvas>().enabled = true;
			RotacaoPersonagem.naoMexer = false;
		}

		IEnumerator Texto5(){
		yield return new WaitForSeconds (0.2f);
		texto5.SetActive(true);
		canvasBotoes.GetComponent<Canvas>().enabled = false;
		RotacaoPersonagem.naoMexer = true;
        RotacaoPersonagem.x = 0;
        RotacaoPersonagem.z = 0;
		StartCoroutine(Trava());
		StartCoroutine(Continuar());
	}

	IEnumerator Trava(){
		yield return new WaitForSeconds(6f);
		podeavancar = true;

	}

	IEnumerator Continuar(){
		yield return new WaitForSeconds (5f);
		textoContinuar.SetActive(true);
	}

	IEnumerator Destruir(){
		yield return new WaitForSeconds (2f);
		texto5.SetActive(false);
		textoContinuar.SetActive(false);
		Destroy(colissor.gameObject);
	}
}
