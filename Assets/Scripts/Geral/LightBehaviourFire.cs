using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviourFire : MonoBehaviour {

	Light thisLight;
	internal Color originalColor;
	float timePassed;
	float changeValue;

	// Use this for initialization
	void Start () {
		thisLight = gameObject.GetComponent<Light> ();
		if (thisLight != null) {
			originalColor = thisLight.color;
		} else {
			enabled = false;
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timePassed = Time.time;
		timePassed = timePassed - Mathf.Floor (timePassed);
		thisLight.color = originalColor * CalculateChange ();
	}

	float CalculateChange(){
		changeValue = -Mathf.Sin (timePassed * 12 * Mathf.PI) * 0.05f + Random.Range(0.95f,1.05f);
		return changeValue;
	}



}




