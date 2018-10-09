using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CutsScene : MonoBehaviour {


	public Light[] tocha1;
	public Light[] tocha2;
	public Light[] tocha3;
    public Light[] tocha4;
	public Light[] tocha5;

	GameObject valkVoando;
	GameObject personagem;
    GameObject porta;
	public static bool olharValk = false;

	// Use this for initialization
	void Start () {
		
		valkVoando = GameObject.FindGameObjectWithTag("ValkTutoba");
		personagem = GameObject.FindGameObjectWithTag("Player");
        porta = GameObject.FindGameObjectWithTag("PortaFase4");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            olharValk = true;
			porta.GetComponent<Animator>().SetFloat("Volta", -1.0f);
            personagem.GetComponent<Animator>().SetFloat("Blend", 0);
            StartCoroutine(FechouPorta());
			StartCoroutine(AcenderTochas());
			StartCoroutine(ValkiriaAnim());
        }

    }

    IEnumerator FechouPorta()
    {
        yield return new WaitForSeconds(2f);
        personagem.GetComponent<Animator>().SetTrigger("PortaFechou");
    }

    
	IEnumerator AcenderTochas(){
		yield return new WaitForSeconds(5f);
		personagem.GetComponent<Animator>().SetTrigger("AssustadoDeMais");
		foreach(Light luz in tocha1){
				luz.intensity = 1.3f;
			}
		yield return new WaitForSeconds(0.5f);
		foreach(Light luz in tocha2){
				luz.intensity = 1.3f;
			}
		yield return new WaitForSeconds(0.5f);
		foreach(Light luz in tocha3){
				luz.intensity = 1.3f;
			}
		yield return new WaitForSeconds(0.5f);
		foreach(Light luz in tocha4){
				luz.intensity = 1.3f;
			}
		yield return new WaitForSeconds(0.5f);
		foreach(Light luz in tocha5){
				luz.intensity = 1.3f;
			}
	}

	IEnumerator ValkiriaAnim(){
		yield return new WaitForSeconds(7.5f);
		valkVoando.GetComponent<Animator>().SetTrigger("InicioVoo");
	}

}
