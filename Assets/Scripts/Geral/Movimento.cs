using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movimento : MonoBehaviour {

	public static Rigidbody rb;
	public static float x;
	public static float z;
    GameObject cam;
    AudioSource audioSrc;
	

	// Use this for initialization
	void Start () {
        audioSrc = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody> ();
        cam = GameObject.Find("MovimentoJogadorCamera");
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
               rb.velocity = cam.transform.TransformDirection(x, 0, z) * 30;
               // rb.velocity = new Vector3(x, 0, z) * 30;
            } else {
                rb.velocity = new Vector3(x, 0, z) * 15;
            }
		} else {
			rb.velocity = new Vector3(0,0,0);
		}
	}

    public void SomAndar() {
        audioSrc.Play();
    }

}
