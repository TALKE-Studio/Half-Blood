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

	GameObject personagem;	
	public static bool olharValk = false;

	// Use this for initialization
	void Start () {
		
		personagem = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){
			print("PARA ESSA PORRA");
			olharValk = true;
			RotacaoPersonagem.x = 0;
			RotacaoPersonagem.z = 0;
			personagem.GetComponent<Animator>().SetFloat("Blend", 0);
			RotacaoPersonagem.naoMexer = true;
			StartCoroutine(AcenderTochas());
		}

	}

	IEnumerator AcenderTochas(){
		yield return new WaitForSeconds(3f);
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

}
