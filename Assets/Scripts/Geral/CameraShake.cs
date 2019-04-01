using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	public Transform camTransform;
	public static float shakeDuration = 3f;
	float shakeAmount = 1f;
	float decreaseFactor = 1.0f;
	Vector3 originalPos;

	// Use this for initialization
	 
	void Start(){
		originalPos = camTransform.localPosition;
	}
	// Update is called once per frame
	void Update () {
		if (shakeDuration > 0) {
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime * decreaseFactor;
		} else {
			shakeDuration = 0;
			camTransform.localPosition = originalPos;
		}
	}
}
