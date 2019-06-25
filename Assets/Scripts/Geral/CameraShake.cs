using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	public Transform camTransform;
	internal float shakeDuration = 3f;
	float shakeAmount = 1f;
	float decreaseFactor = 1.0f;
	Vector3 originalPos;
    Vector3 novaPos;

	// Use this for initialization
	 
	void Start(){
		originalPos = camTransform.localPosition;
	}
	// Update is called once per frame
	void Update () {
		if (shakeDuration > 0) {
            novaPos = originalPos + Random.insideUnitSphere * shakeAmount;
            camTransform.localPosition = new Vector3(novaPos.x,camTransform.localPosition.y,novaPos.z);
			shakeDuration -= Time.deltaTime * decreaseFactor;
		} else {
			shakeDuration = 0;
			camTransform.localPosition = originalPos;
		}
	}
}
