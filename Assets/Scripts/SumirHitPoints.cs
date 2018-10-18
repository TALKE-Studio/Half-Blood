using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumirHitPoints : MonoBehaviour {

	GameObject hit;
	GameObject hit2;

	// Use this for initialization
	void Start () {
		hit = GameObject.FindGameObjectWithTag("Hit");
		hit2 = GameObject.FindGameObjectWithTag("Hit2");
		StartCoroutine(Pedra());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Pedra(){
		yield return new WaitForSeconds(1f);
		hit.GetComponent<MeshRenderer>().enabled = false;
		hit2.GetComponent<MeshRenderer>().enabled = false;
	}
}
