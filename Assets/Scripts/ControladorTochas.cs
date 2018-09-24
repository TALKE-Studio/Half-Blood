using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTochas : MonoBehaviour {

	GameObject[] tochas;
	float distancia;
	bool ligar = false;
	bool desligar = false;
	bool coroutineAtiva1 = false;
	bool coroutineAtiva2 = false;
	float size;
	int i;
	Coroutine luzLiga;
	Coroutine luzDesliga;
	// Use this for initialization
	void Start () {
		tochas = GameObject.FindGameObjectsWithTag ("Tocha1");
		size = TamanhoDoChaoX ();
		i = GetNearestTorch ();
	}
	
	// Update is called once per frame
	void Update () {
		//print (ligar);
		//print(desligar);
		if (ligar == true)	 {
			//if (coroutineAtiva1 == false) {
			luzLiga = StartCoroutine (LigarLuz());
			//}
		}
		if (desligar == true) {
			//if (coroutineAtiva2 == false) {
			luzDesliga = StartCoroutine (DesligarLuz());
		//	}
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			//print ("Entrou");
			foreach(GameObject t in tochas){
				distancia = Vector3.Distance (gameObject.transform.position, t.gameObject.transform.position);
				//print(distancia);
				if (distancia < size) {
					if (t.GetComponent<Light> ().intensity < 6) {
						ligar = true;
					}
				}
			}
		}
	}

	void OnCollisionExit (Collision other){
		if (other.gameObject.tag == "Player") {
		//	print ("saiu");
		//	foreach(GameObject t in tochas){
		//		distancia = Vector3.Distance (gameObject.transform.position, t.gameObject.transform.position);
		//		if(distancia < size) {
			if (tochas [i].gameObject.GetComponent<Light> ().intensity >= 0) {
						desligar = true;
					}
				}
			}

	IEnumerator LigarLuz(){
		if (coroutineAtiva2 == true) {
			StopCoroutine (luzDesliga);
			//print ("HUEHEU");
			//print (gameObject);
			coroutineAtiva2 = false;
		//	ligar = false;
			//coroutineAtiva1 = false;
		} if(coroutineAtiva2 == false){
			ligar = false;
			coroutineAtiva1 = true;
			//print ("Ativei");
			foreach (GameObject t in tochas) {
				distancia = Vector3.Distance (gameObject.transform.position, t.gameObject.transform.position);
				if (distancia < size) {
				//	if (t.GetComponent<Light> ().intensity < 6) {
						t.GetComponent<Light> ().intensity += 0.5f;
				//	}
				}
			}
			//print ("FDSFD");
			yield return new WaitForSeconds (0.05f);
			if (tochas [i].gameObject.GetComponent<Light> ().intensity < 6 && coroutineAtiva1 == true) {
				StartCoroutine (LigarLuz());
			} else {
				//print ("Desliguei");
				ligar = false;
				coroutineAtiva1 = false;
			}
		}
	}


	IEnumerator DesligarLuz(){
		if (coroutineAtiva1 == true) {
			StopCoroutine (luzLiga);
		//	print ("DSDS");
		//	print (gameObject);
			coroutineAtiva1 = false;

	//		desligar = false;
	//		coroutineAtiva2 = false;
		} else if(coroutineAtiva1 == false){

			//print ("Comecei");
			desligar = false;
			coroutineAtiva2 = true;
			//print (desligar);
			foreach (GameObject t in tochas) {
				distancia = Vector3.Distance (gameObject.transform.position, t.gameObject.transform.position);
				if (distancia < size) {
					if (t.GetComponent<Light> ().intensity > 1) {
						t.GetComponent<Light> ().intensity -= 0.5f;
					} else {
						t.GetComponent<Light> ().intensity += 0.5f;
					}
				}
			}
			yield return new WaitForSeconds (0.05f);

			if (tochas [i].gameObject.GetComponent<Light> ().intensity > 1 && coroutineAtiva2 == true) {
				//print ("FUI CHAMADO");
				StartCoroutine (DesligarLuz());
			} else {
				desligar = false;
				coroutineAtiva2 = false;
			}
		}
	}

	int  GetNearestTorch()
	{
		float minDist = float.MaxValue;
		int index = -1;
		for (int i = 0; i < tochas.Length; i++) {
			float dist = Vector3.Distance (transform.position, tochas [i].transform.position);
			//if (dist < size) {
				if (dist < minDist) {
					index = i;
					minDist = dist;
				}
			//}
		}
		//print (index);
		return index;
	}

	int  GetOtherRoomTorch()
	{
		float minDist = float.MaxValue;
		float maxDist = TamanhoDoChaoX();
		int index = -1;
		for (int i = 0; i < tochas.Length; i++) {
			float dist = Vector3.Distance (transform.position, tochas [i].transform.position);
			if (tochas [i].GetComponent<Light> ().intensity > 1) {
				if (dist < minDist && maxDist < dist) {
					index = i;
					minDist = dist;
				}
			}
		}
		//print (index);
		return index;
	}

	float TamanhoDoChaoX(){
		Vector3 tamanho;
		tamanho = gameObject.GetComponent<Renderer> ().bounds.size;
		//print (gameObject.GetComponent<Renderer> ().bounds.size);
		//print (tamanho.x / 2);
		//print (Mathf.Sqrt ((tamanho.x / 2 * tamanho.x / 2) + (tochas [GetNearestTorch ()].gameObject.transform.position.y * tochas [GetNearestTorch ()].gameObject.transform.position.y)));
			return Mathf.Sqrt ((tamanho.x / 2 * tamanho.x / 2) + ((tochas [GetNearestTorch ()].gameObject.transform.position.y - gameObject.transform.position.y) * (tochas [GetNearestTorch ()].gameObject.transform.position.y - gameObject.transform.position.y)));
		}

}
