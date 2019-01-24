using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimTutorial : MonoBehaviour {

	public GameObject Texto_Tutorial;
	public GameObject Imagem_Tutorial;
	public GameObject Tela_Final;
    public GameObject Tela_TextoFinal;
    public GameObject Texto8;
    public GameObject Texto9;
    public GameObject continuar;
    bool podeavancar = false;
    Touch touch;
    public GameObject telaBrancaTutorial;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetTouch(i).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)) && podeavancar == true)
            {
                Texto8.GetComponent<Animator>().SetBool("Proximo", true);
                continuar.GetComponent<Animator>().SetBool("Proximo", true);
                StartCoroutine(IrTexto9());
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && podeavancar == true)
        {
            Texto8.GetComponent<Animator>().SetBool("Proximo", true);
            continuar.GetComponent<Animator>().SetBool("Proximo", true);
            StartCoroutine(IrTexto9());
        }
        if(TextoFinal.tocou == true)
        {
            StartCoroutine(TelaBranca());
        }
    }

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			StartCoroutine(Conquista());
            StartCoroutine(TelaPretaFinal());
            StartCoroutine(Texto8Aparecer());
            StartCoroutine(Trava());
        }
	}

	IEnumerator Conquista(){
		yield return new WaitForSeconds(7f);
		Texto_Tutorial.SetActive(true);
		Imagem_Tutorial.SetActive(true);
	}

    IEnumerator TelaPretaFinal()
    {
        yield return new WaitForSeconds(14f);
        Tela_TextoFinal.SetActive(true);
    }

    IEnumerator Texto8Aparecer()
    {
        yield return new WaitForSeconds(15f);
        Texto8.SetActive(true);
        StartCoroutine(Continuar());

    }

    IEnumerator Continuar()
    {
        yield return new WaitForSeconds(5f);
        continuar.SetActive(true);
    }

    IEnumerator Trava()
    {
        yield return new WaitForSeconds(20f);
        podeavancar = true;

    }
    IEnumerator IrTexto9()
    {
        yield return new WaitForSeconds(2f);
        continuar.SetActive(false);
        podeavancar = false;
        Texto9.SetActive(true);
        Destroy(Texto8.gameObject);
    }

    IEnumerator TelaBranca(){
        TextoFinal.tocou = false;
        yield return new WaitForSeconds(1.5f);
        TextoFinal.tocou = false;
        telaBrancaTutorial.SetActive(true);
        GameObject.FindGameObjectWithTag("Botoes").GetComponent<Canvas>().sortingOrder = 60;
        TextoFinal.tocou = false;
        telaBrancaTutorial.GetComponent<Animator>().SetTrigger("gameOver");
    }
}
