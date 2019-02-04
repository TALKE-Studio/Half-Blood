using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadorDePedra : MonoBehaviour {
    public GameObject pedra;
    public float tempo;

	// Use this for initialization
	void Start () {
        StartCoroutine(Criar());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Criar() {
        if (MecanicaTochaAzul.tAzul == true) {
            print("A");
            Instantiate(pedra, gameObject.transform.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(tempo);
            StartCoroutine(Criar());
        } else {
            yield return new WaitUntil(() => MecanicaTochaAzul.tAzul == true);
            StartCoroutine(Criar());
        }

    }

}
