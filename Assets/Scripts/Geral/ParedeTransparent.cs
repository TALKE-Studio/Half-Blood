using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeTransparent : MonoBehaviour {

	public Transform alvo;
	public RaycastHit hitpoint = new RaycastHit ();
	Touch touch;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance (gameObject.transform.position, alvo.transform.position) > 350) {
			GameObject.FindGameObjectWithTag ("Finish").GetComponent<Canvas> ().enabled = false;
		} else {
            if (SegundaFaseMecanica.gameOver == false) { 
                GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
            }
		}
		if (Physics.Linecast (transform.position, alvo.transform.position, out hitpoint)) {
			Debug.DrawLine (transform.position, alvo.transform.position);
		}
	}

}
