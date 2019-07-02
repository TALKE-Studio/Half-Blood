using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirecaoDeMovimento : MonoBehaviour {

    GameObject cam;

    // Use this for initialization
    void Start() {
        cam = GameObject.Find("ARCamera");

    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.eulerAngles = new Vector3(0, cam.transform.rotation.eulerAngles.y, 0);
    }
}
