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
			for (int i = 0; i < Input.touchCount; i++) {
				if (Input.GetTouch(i).phase == TouchPhase.Began ||Input.GetMouseButtonDown (0)) {
				    if (Vector3.Distance (gameObject.transform.position, GameObject.FindGameObjectWithTag ("VikingAp").gameObject.transform.position) < 100) {
					GameObject.FindGameObjectWithTag ("VikingAp").GetComponent<Animator> ().SetBool ("TocouTela", true);
				    }
			    }
				if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0)) {
				    if (Vector3.Distance (gameObject.transform.position, GameObject.FindGameObjectWithTag ("VikingAp").gameObject.transform.position) < 100) {
					GameObject.FindGameObjectWithTag ("VikingAp").GetComponent<Animator> ().SetBool ("TocouTela", false);
				    }
				    if (Vector3.Distance (gameObject.transform.position, GameObject.FindGameObjectWithTag ("ValkiriaAp").gameObject.transform.position) < 100) {
					GameObject.FindGameObjectWithTag ("ValkiriaAp").GetComponent<Animator> ().SetTrigger ("TocouTela");
				    }
			    }
		    }
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
