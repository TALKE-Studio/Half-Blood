using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SegundaFaseMecanica : MonoBehaviour {
	public GameObject[] pedras;
	float dist = 100;
	bool pedraAColetada = false;
	bool pedraRColetada = false;
    bool pedraCColetada = false;
    bool pedraPColetada = false;
    public GameObject[] garras;
	float dist2 = 100;
	public static bool pedraAColocada = false;
	public static bool pedraRColocada = false;
    public static bool pedraCColocada = false;
    public static bool pedraPColocada = false;
    bool pedraFinal = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ColetarPedra ();
		ColocarPedra ();

        if (pedraAColocada == true && pedraRColocada == true)
        {
            if (pedraFinal == false)
            {
                PedraFinalScript();
            }
        }

    }

    private void PedraFinalScript()
    {
        pedraFinal = true;
        GameObject.FindGameObjectWithTag("Porta").GetComponent<Animation>().Play();
        GameObject.Find("death_pedra").GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        GameObject.Find("death_pedra").GetComponentInChildren<Light>().enabled = true;
        GameObject.Find("death_pedra").AddComponent<LightBehaviourStone>();
    }

    void ColetarPedra(){
		if (Input.GetKeyDown (KeyCode.Space) == true|| CrossPlatformInputManager.GetButtonDown ("Jump")== true) {
			foreach (GameObject p in pedras) {
				if (p != null) {
					dist = Vector3.Distance (gameObject.transform.position, p.gameObject.transform.position);
				}
				if (dist < 15) {
                    if (p.name == "PedraRosa") {
                        pedraRColetada = true;
                        dist = 100;
                        p.GetComponent<MeshRenderer>().enabled = false;
                    } else if (p.name == "PedraAzul") {
                        pedraAColetada = true;
                        dist = 100;
                        p.GetComponent<MeshRenderer>().enabled = false;
                    } else if(p.name == "courage_pedra"){
                        pedraCColetada = true;
                        dist = 100;
                        p.GetComponent<MeshRenderer>().enabled = false;
                        p.GetComponentInChildren<Light>().enabled = false;
                    }
                    else if (p.name == "death_pedra")
                    {
                        pedraPColetada = true;
                        dist = 100;
                        p.GetComponent<MeshRenderer>().enabled = false;
                        p.GetComponentInChildren<Light>().enabled = false;
                    }
                }
			}
		}
	}

	void ColocarPedra(){
		if (Input.GetKeyDown (KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown ("Jump") == true) {
			foreach (GameObject g in garras) {
				dist2 = Vector3.Distance (gameObject.transform.position, g.gameObject.transform.position);
				if (dist2 < 20) {
					if (g.name == "GarraAzul" && pedraAColetada == true && pedraAColocada == false) {
						GameObject.Find ("PedraAzul").GetComponent<MeshRenderer> ().enabled = true;
						GameObject.Find ("PedraAzul").gameObject.transform.SetParent (g.transform);
						GameObject.Find ("PedraAzul").gameObject.transform.localPosition = GameObject.Find ("Pedra_Garras").transform.localPosition;
						GameObject.Find ("PedraAzul").gameObject.transform.localRotation = GameObject.Find ("Pedra_Garras").transform.localRotation;
						GameObject.Find ("PedraAzul").AddComponent<LightBehaviourStone> ();
						pedraAColocada = true;
					}
                    if (g.name == "GarraRosa" && pedraRColetada == true && pedraRColocada ==false) {
						GameObject.Find ("PedraRosa").GetComponent<MeshRenderer> ().enabled = true;
						GameObject.Find ("PedraRosa").gameObject.transform.SetParent (g.transform);
						GameObject.Find ("PedraRosa").gameObject.transform.localPosition = GameObject.Find ("Pedra_Garras").transform.localPosition;
						GameObject.Find ("PedraRosa").gameObject.transform.localRotation = GameObject.Find ("Pedra_Garras").transform.localRotation;
						GameObject.Find ("PedraRosa").AddComponent<LightBehaviourStone> ();
						pedraRColocada = true;
					}
                    if (g.name == "courage_base" && pedraCColetada == true && pedraCColocada == false) {
                        GameObject.Find("courage_pedra").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("courage_pedra").GetComponentInChildren<Light>().enabled = true;
                        pedraCColocada = true;
                        GameObject.Find("courage_pedra").GetComponent<Animation>().Play();
                        TelaBranca.colidiu = true;
                        RotacaoPersonagem.naoMexer = true;
                        RotacaoPersonagem.x = 0;
                        RotacaoPersonagem.z = 0;
                        Movimento.rb.velocity = new Vector3(0, 0, 0);
                        RotacaoPersonagem.animator.SetBool("Andando", false);
                        GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = false;
                        GameObject.FindGameObjectWithTag("TelaBranca").GetComponent<Animation>().Play();
                    }
                    if (g.name == "death_base" && pedraPColetada == true && pedraPColocada == false)
                    {
                        GameObject.Find("death_pedra").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("death_pedra").GetComponentInChildren<Light>().enabled = true;
                        pedraPColocada = true;
                        GameObject.Find("death_pedra").GetComponent<Animation>().Play();
                        TelaBranca.colidiu = true;
                        RotacaoPersonagem.naoMexer = true;
                        RotacaoPersonagem.x = 0;
                        RotacaoPersonagem.z = 0;
                        Movimento.rb.velocity = new Vector3(0, 0, 0);
                        RotacaoPersonagem.animator.SetBool("Andando", false);
                        GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = false;
                        GameObject.FindGameObjectWithTag("TelaBranca").GetComponent<Animation>().Play();
                    }
                }
			}
		}
	}

}
