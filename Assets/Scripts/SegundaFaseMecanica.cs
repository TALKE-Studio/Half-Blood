﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SegundaFaseMecanica : MonoBehaviour {
	public GameObject[] pedras;
	float dist = 100;
    public static bool pedraAColetada = false;
    public static bool pedraRColetada = false;
    public static bool pedraCColetada = false;
    public static bool pedraPColetada = false;
    public GameObject[] garras;
	float dist2 = 100;
	public static bool pedraAColocada = false;
	public static bool pedraRColocada = false;
    public static bool pedraCColocada = false;
    public static bool pedraPColocada = false;
    bool pedraFinal = false;
    public static bool tutorial = true;
    public static bool  fase1 = true;
    public static bool fase2 = false;

    // Use this for initialization
    void Start () {

     pedraAColocada = false;
     pedraRColocada = false;
     pedraCColocada = false;
     pedraPColocada = false;
}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(ColetarPedra ());
		StartCoroutine(ColocarPedra ());

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
        GameObject.FindGameObjectWithTag("Porta2").GetComponent<Animation>().Play();
        GameObject.Find("death_pedra").GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        GameObject.Find("death_pedra").GetComponentInChildren<Light>().enabled = true;
        GameObject.Find("death_pedra").AddComponent<LightBehaviourStone>();
    }

    IEnumerator ColetarPedra(){
		if (Input.GetKeyDown (KeyCode.Space) == true|| CrossPlatformInputManager.GetButtonDown ("Jump")== true) {
			foreach (GameObject p in pedras) {
				if (p != null) {
					dist = Vector3.Distance (gameObject.transform.position, p.gameObject.transform.position);
				}
				if (dist < 15) {
                    if (p.name == "PedraRosa") {
                        if (pedraRColetada == false && pedraRColocada == false) {
                            pedraRColetada = true;
                            RotacaoPersonagem.naoMexer = true;
                            RotacaoPersonagem.x = 0;
                            RotacaoPersonagem.z = 0;
                            Movimento.rb.velocity = new Vector3(0, 0, 0);
                            Vector3 alvo = new Vector3(p.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, p.transform.position.z);
                            GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
                            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("PegouChao");
                            yield return new WaitForSecondsRealtime(1);
                            RotacaoPersonagem.naoMexer = false;
                            dist = 100;
                            p.GetComponent<MeshRenderer>().enabled = false;
                            p.transform.localPosition = new Vector3(p.transform.localPosition.x, p.transform.localPosition.y - 5, p.transform.localPosition.z);
                        }
                    } else if (p.name == "PedraAzul") {
                        if (pedraAColetada == false && pedraAColocada == false) {
                            pedraAColetada = true;
                            RotacaoPersonagem.naoMexer = true;
                            RotacaoPersonagem.x = 0;
                            RotacaoPersonagem.z = 0;
                            Movimento.rb.velocity = new Vector3(0, 0, 0);
                            Vector3 alvo = new Vector3(p.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, p.transform.position.z);
                            GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
                            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("PegouChao");
                            yield return new WaitForSecondsRealtime(1);
                            RotacaoPersonagem.naoMexer = false;
                            dist = 100;
                            p.GetComponent<MeshRenderer>().enabled = false;
                            p.transform.localPosition = new Vector3(p.transform.localPosition.x, p.transform.localPosition.y - 5, p.transform.localPosition.z);
                        }
                    } else if(p.name == "courage_pedra"){
                        if (pedraCColetada == false && pedraCColocada == false) {
                            pedraCColetada = true;
                            RotacaoPersonagem.naoMexer = true;
                            RotacaoPersonagem.x = 0;
                            RotacaoPersonagem.z = 0;
                            Movimento.rb.velocity = new Vector3(0, 0, 0);
                            Vector3 alvo = new Vector3(p.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, p.transform.position.z);
                            GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
                            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("PegouChao");
                            yield return new WaitForSecondsRealtime(1);
                            RotacaoPersonagem.naoMexer = false;
                            dist = 100;
                            p.GetComponent<MeshRenderer>().enabled = false;
                            p.transform.localPosition = new Vector3(p.transform.localPosition.x, p.transform.localPosition.y - 5, p.transform.localPosition.z);
                            p.GetComponentInChildren<Light>().enabled = false;
                        }
                    }
                    else if (p.name == "death_pedra"){
                        if (pedraPColetada == false && pedraPColocada == false) {
                            pedraPColetada = true;
                            RotacaoPersonagem.naoMexer = true;
                            RotacaoPersonagem.x = 0;
                            RotacaoPersonagem.z = 0;
                            Movimento.rb.velocity = new Vector3(0, 0, 0);
                            Vector3 alvo = new Vector3(p.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, p.transform.position.z);
                            GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
                            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("PegouChao");
                            yield return new WaitForSecondsRealtime(1);
                            RotacaoPersonagem.naoMexer = false;
                            dist = 100;
                            p.GetComponent<MeshRenderer>().enabled = false;
                            p.transform.localPosition = new Vector3(p.transform.localPosition.x, p.transform.localPosition.y - 5, p.transform.localPosition.z);
                            p.GetComponentInChildren<Light>().enabled = false;
                        }
                    }
                }
			}
		}
	}

	IEnumerator ColocarPedra(){
		if (Input.GetKeyDown (KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown ("Jump") == true) {
			foreach (GameObject g in garras) {
				dist2 = Vector3.Distance (gameObject.transform.position, g.gameObject.transform.position);
				if (dist2 < 20) {
                    if (g.name == "GarraAzul" && pedraAColetada == true && pedraAColocada == false) {
                        pedraAColocada = true;
                        RotacaoPersonagem.naoMexer = true;
                        RotacaoPersonagem.x = 0;
                        RotacaoPersonagem.z = 0;
                        Movimento.rb.velocity = new Vector3(0, 0, 0);
                        Vector3 alvo = new Vector3(g.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, g.transform.position.z);
                        GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("TocouParede");
                        yield return new WaitForSecondsRealtime(1);
                        RotacaoPersonagem.naoMexer = false;
                        GameObject.Find ("PedraAzul").GetComponent<MeshRenderer> ().enabled = true;
						GameObject.Find ("PedraAzul").gameObject.transform.SetParent (g.transform);
						GameObject.Find ("PedraAzul").gameObject.transform.localPosition = GameObject.Find ("Pedra_Garras").transform.localPosition;
						GameObject.Find ("PedraAzul").gameObject.transform.localRotation = GameObject.Find ("Pedra_Garras").transform.localRotation;
						GameObject.Find ("PedraAzul").AddComponent<LightBehaviourStone> ();
					}
                    if (g.name == "GarraRosa" && pedraRColetada == true && pedraRColocada ==false) {
                        pedraRColocada = true;
                        RotacaoPersonagem.naoMexer = true;
                        RotacaoPersonagem.x = 0;
                        RotacaoPersonagem.z = 0;
                        Movimento.rb.velocity = new Vector3(0, 0, 0);
                        Vector3 alvo = new Vector3(g.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, g.transform.position.z);
                        GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("TocouParede");
                        yield return new WaitForSecondsRealtime(1);
                        RotacaoPersonagem.naoMexer = false;
                        GameObject.Find ("PedraRosa").GetComponent<MeshRenderer> ().enabled = true;
						GameObject.Find ("PedraRosa").gameObject.transform.SetParent (g.transform);
						GameObject.Find ("PedraRosa").gameObject.transform.localPosition = GameObject.Find ("Pedra_Garras").transform.localPosition;
						GameObject.Find ("PedraRosa").gameObject.transform.localRotation = GameObject.Find ("Pedra_Garras").transform.localRotation;
						GameObject.Find ("PedraRosa").AddComponent<LightBehaviourStone> ();
                    }
                    if (g.name == "courage_base" && pedraCColetada == true && pedraCColocada == false) {
                        pedraCColocada = true;
                        RotacaoPersonagem.naoMexer = true;
                        RotacaoPersonagem.x = 0;
                        RotacaoPersonagem.z = 0;
                        Movimento.rb.velocity = new Vector3(0, 0, 0);
                        Vector3 alvo = new Vector3(g.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, g.transform.position.z);
                        GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("TocouParede");
                        yield return new WaitForSecondsRealtime(1);
                        RotacaoPersonagem.naoMexer = false;
                        GameObject.Find("courage_pedra").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("courage_pedra").GetComponentInChildren<Light>().enabled = true;
                        GameObject.Find("courage_pedra").GetComponent<Animation>().Play();
                        TelaBranca.colidiu = true;
                        RotacaoPersonagem.naoMexer = true;
                        RotacaoPersonagem.x = 0;
                        RotacaoPersonagem.z = 0;
                        Movimento.rb.velocity = new Vector3(0, 0, 0);
                        RotacaoPersonagem.animator.SetBool("Andando", false);
                        GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = false;
                        GameObject.FindGameObjectWithTag("TelaBranca").GetComponent<Animator>().SetTrigger("gameOver");
                    }
                    if (g.name == "death_base" && pedraPColetada == true && pedraPColocada == false){
                        pedraPColocada = true;
                        RotacaoPersonagem.naoMexer = true;
                        RotacaoPersonagem.x = 0;
                        RotacaoPersonagem.z = 0;
                        Movimento.rb.velocity = new Vector3(0, 0, 0);
                        Vector3 alvo = new Vector3(g.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, g.transform.position.z);
                        GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("TocouParede");
                        yield return new WaitForSecondsRealtime(1);
                        RotacaoPersonagem.naoMexer = false;
                        GameObject.Find("death_pedra").GetComponent<MeshRenderer>().enabled = true;
                        GameObject.Find("death_pedra").GetComponentInChildren<Light>().enabled = true;
                        GameObject.Find("death_pedra").GetComponent<Animation>().Play();
                        TelaBranca.colidiu = true;
                        RotacaoPersonagem.naoMexer = true;
                        RotacaoPersonagem.x = 0;
                        RotacaoPersonagem.z = 0;
                        Movimento.rb.velocity = new Vector3(0, 0, 0);
                        RotacaoPersonagem.animator.SetBool("Andando", false);
                        GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = false;
                        GameObject.FindGameObjectWithTag("TelaBranca").GetComponent<Animator>().SetTrigger("gameOver");
                    }
                }
			}
		}
	}

}
