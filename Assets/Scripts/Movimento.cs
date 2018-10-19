using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movimento : MonoBehaviour {

	public static Rigidbody rb;
	public static float x;
	public static float z;

	

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled == true) {
            Andar();
        }
	}

	void Andar(){
		if (RotacaoPersonagem.naoMexer == false) {
				x = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
				z = CrossPlatformInputManager.GetAxisRaw ("Vertical");
		} else {
			x = 0;
			z = 0;
		}

		//x = -Input.GetAxis ("Horizontal");
		//z = -Input.GetAxis ("Vertical");
		if (x != 0 || z != 0) {
            if (RotacaoPersonagem.segurando == false) {
                rb.velocity = new Vector3(x, 0, z) * 30;
            } else {
                rb.velocity = new Vector3(x, 0, z) * 15;
            }
		} else {
			rb.velocity = new Vector3(0,0,0);
		}
	}
}
