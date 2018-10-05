using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Sala3 : MonoBehaviour {
	GameObject pedra;
	GameObject pedrainv;
	GameObject porta;
	bool coletoupedra = false;
	bool abriuporta = false;
	static public bool colocoupedra;


	// Use this for initialization
	void Start () {
		pedra = GameObject.FindGameObjectWithTag("PedraVerde");
		pedrainv = GameObject.FindGameObjectWithTag("PedraVerdeInv");
		porta = GameObject.FindGameObjectWithTag("PortaFase4");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "PedraVerde" && Input.GetKeyDown (KeyCode.Space) == true){
			coletoupedra = true;
			print("Moco Colidiu aqui");
			gameObject.GetComponent<Animator>().SetBool("PegouChao", true);
			StartCoroutine(PegandoPedra());
			StartCoroutine (TerminarAnim());
		}
		if(other.gameObject.tag == "GarraTutorial" && Input.GetKeyDown (KeyCode.Space) == true){
			if(coletoupedra == true){
				gameObject.GetComponent<Animator>().SetBool("TocouParede", true);
				abriuporta = true;
				colocoupedra = true;
				StartCoroutine(AbrindoPorta());
				StartCoroutine(TocandoParede());
				StartCoroutine(TerminarAnim());
			}

			
		}
	}

	IEnumerator TocandoParede(){
		yield return new WaitForSeconds(1f);
		pedrainv.GetComponent<MeshRenderer>().enabled = true;
	}

	IEnumerator AbrindoPorta(){
		yield return new WaitForSeconds(2f);
		porta.GetComponent<Animator>().SetBool("Abrir", true);
	}

	IEnumerator PegandoPedra(){
		yield return new WaitForSeconds(1f);
		pedra.GetComponent<MeshRenderer>().enabled = false;
	}

	IEnumerator TerminarAnim(){
		yield return new WaitForSeconds(0.6f);
		gameObject.GetComponent<Animator>().SetBool("TocouParede", false);
		gameObject.GetComponent<Animator>().SetBool("PegouChao", false);
	}
}
