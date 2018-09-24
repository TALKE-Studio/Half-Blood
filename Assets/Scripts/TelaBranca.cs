using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TelaBranca : MonoBehaviour {

    public static bool colidiu = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(Vector3.Distance(GameObject.Find("courage_base").transform.position, GameObject.FindGameObjectWithTag("Player").transform.position));
        if (CrossPlatformInputManager.GetButtonDown("Jump") == true || Input.GetKeyDown(KeyCode.Space) == true){
            if (Vector3.Distance(GameObject.Find("courage_base").transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 20)
            {

                GameObject.Find("courage_pedra").GetComponent<Animation>().Play();
            }
        }
        }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            colidiu = true;
            Movimento.x = 0;
            Movimento.z = 0;
            Movimento.rb.velocity = new Vector3(0,0,0);
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = false;
        }
    }


}
