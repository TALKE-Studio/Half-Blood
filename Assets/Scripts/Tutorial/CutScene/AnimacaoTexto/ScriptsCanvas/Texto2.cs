using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texto2 : MonoBehaviour {

	public GameObject texto2;
	public GameObject textoContinuar;
	public GameObject texto3;
	bool podeavancar = false;
	Touch touch;

	// Use this for initialization
	void Start () {
		StartCoroutine(Trava());
		StartCoroutine(Continuar());
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
		if((Input.GetKeyDown(KeyCode.Space)|| Input.GetTouch(i).phase == TouchPhase.Began ||Input.GetMouseButtonDown (0) ) && podeavancar == true)
		{
			texto2.GetComponent<Animator>().SetBool("Proximo", true);
			textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
			StartCoroutine(IrTexto3());
		}
		}
	}



		IEnumerator Trava(){
		yield return new WaitForSeconds(6f);
		podeavancar = true;

	}

	IEnumerator Continuar(){
		yield return new WaitForSeconds (5f);
		textoContinuar.SetActive(true);
	}

	IEnumerator IrTexto3(){
		yield return new WaitForSeconds(2f);
		texto3.SetActive(true);
		textoContinuar.SetActive(false);
		podeavancar = false;
		StartCoroutine(Destroir());
	}

	IEnumerator Destroir(){
		yield return new WaitForSeconds(3f);
		texto2.SetActive(false);
	}
}
