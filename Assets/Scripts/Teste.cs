using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour {

    GameObject cam;
    float x;
    float z;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("ARCamera");
        x = transform.eulerAngles.x;
        z = transform.eulerAngles.z;

    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.eulerAngles = new Vector3(x, cam.transform.rotation.eulerAngles.y, z);
	}
}
