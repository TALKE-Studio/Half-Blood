using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LugarDasEstatuas : MonoBehaviour {

    public Sprite Ifase1;
    Renderer rend;
	bool teste;
	float dist;
	public static bool posicionado1;
	public static bool posicionado2;
	public static bool posicionado3;
	public static bool posicionado4;
    bool pedraFinal = false;

	// Use this for initialization
	IEnumerator Start () {
		rend = GetComponent<Renderer> ();
        GameObject.Find("TelaDoCapitulo").GetComponent<Image>().sprite = Ifase1;
        GameObject.FindGameObjectWithTag("Botoes").GetComponent<Canvas>().enabled = true;
        GameObject.Find("ARCamera").GetComponent<ParedeTransparent>().enabled = false;
        GameObject.Find("ARCamera").GetComponent<ParedeTransparent>().enabled = true;
        GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
        yield return new WaitForSeconds (0.1f);
        rend.material.DisableKeyword("_EMISSION");
        GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("Fase1ImageTarget").transform);
        GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFase1").transform.localPosition;
        GameObject.FindGameObjectWithTag("Player").transform.localRotation = GameObject.Find("LugarFase1").transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {
		if (posicionado1 == true && posicionado2 == true && posicionado3 == true && posicionado4 == true) {
			GameObject.FindGameObjectWithTag ("Porta").GetComponent<Animator> ().SetBool ("Abrir", true);
			GameObject.FindGameObjectWithTag ("Porta").GetComponent<BoxCollider> ().enabled = false;
            if(pedraFinal == false) {
                PedraFinalScript();
            }
        }
		EncaixarEstatua ();
	}

    private void PedraFinalScript() {
        CameraShake.shakeDuration =  1f;
        GameObject.Find("Fase1ImageTarget").GetComponent<CameraShake>().enabled = true;
        pedraFinal = true;
        GameObject.Find("courage_pedra").GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        GameObject.Find("courage_pedra").GetComponentInChildren<Light>().enabled = true;
        GameObject.Find("courage_pedra").AddComponent<LightBehaviourStone>();
    }

    void EncaixarEstatua(){
		if (gameObject.tag == "ChaoRoxo") {
			GameObject loboRoxo = GameObject.FindGameObjectWithTag ("LoboRoxo");
			dist = Vector3.Distance (gameObject.transform.position, loboRoxo.transform.position);
			if (dist < 12) {
                rend.material.EnableKeyword("_EMISSION");
                if (RotacaoPersonagem.onTrigger == false) {
					loboRoxo.transform.SetParent (gameObject.transform, true);
					if (dist > 0.1f) {
						StartCoroutine (MoverEstatua (loboRoxo));
					}
					if (loboRoxo.transform.rotation.eulerAngles.y > 135f) {
						StartCoroutine (RodarEstatua (loboRoxo));
					}
					if (dist < 0.1f ) {
						posicionado1 = true;
					}
				}
			} else {
                rend.material.DisableKeyword("_EMISSION");
            }
		}else if (gameObject.tag == "ChaoVermelho") {
			GameObject loboVermelho = GameObject.FindGameObjectWithTag ("LoboVermelho");
			dist = Vector3.Distance (gameObject.transform.position, loboVermelho.transform.position);
			if (dist < 12) {
                rend.material.EnableKeyword("_EMISSION");
                if (RotacaoPersonagem.onTrigger == false) {
					loboVermelho.transform.SetParent (gameObject.transform, true);
					if (dist > 0.1f) {
						StartCoroutine (MoverEstatua (loboVermelho));
					}
					if (loboVermelho.transform.rotation.eulerAngles.y < 313f) {
						StartCoroutine (RodarEstatua (loboVermelho));
					}
					if (dist < 0.1f) {
						posicionado2 = true;
					}
				}
			} else {
                rend.material.DisableKeyword("_EMISSION");
            }
		} else if (gameObject.tag == "ChaoVerde") {
			GameObject loboVerde = GameObject.FindGameObjectWithTag ("LoboVerde");
			dist = Vector3.Distance (gameObject.transform.position, loboVerde.transform.position);
			if (dist < 12) {
                rend.material.EnableKeyword("_EMISSION");
                if (RotacaoPersonagem.onTrigger == false) {
					loboVerde.transform.SetParent (gameObject.transform, true);
					if (dist > 0.1f) {
						StartCoroutine (MoverEstatua (loboVerde));
					}
					if (loboVerde.transform.rotation.eulerAngles.y > 46f) {
						StartCoroutine (RodarEstatua (loboVerde));
					}
					if (dist < 0.1f) {
						posicionado3 = true;
					}
				}
			} else {
                rend.material.DisableKeyword("_EMISSION");
            }
		} else if (gameObject.tag == "ChaoAzul") {
			GameObject loboAzul = GameObject.FindGameObjectWithTag ("LoboAzul");
			dist = Vector3.Distance (gameObject.transform.position, loboAzul.transform.position);
			if (dist < 12) {
                rend.material.EnableKeyword("_EMISSION");
                if (RotacaoPersonagem.onTrigger == false) {
					loboAzul.transform.SetParent (gameObject.transform, true);
					if (dist > 0.1f) {
						StartCoroutine (MoverEstatua (loboAzul));
					}
					if (loboAzul.transform.rotation.eulerAngles.y < 223f) {
						StartCoroutine (RodarEstatua (loboAzul));
					}
					if (dist < 0.1f) {
						posicionado4 = true;
					}
				}
			} else {
                rend.material.DisableKeyword("_EMISSION");
            }
		}
	}
		
	IEnumerator MoverEstatua(GameObject lobo){
		BoxCollider[] col = lobo.gameObject.GetComponents<BoxCollider> ();

		float tempo = 0;
		tempo += 0.5f * Time.deltaTime;
		lobo.transform.position = Vector3.LerpUnclamped (lobo.transform.position, gameObject.transform.position, tempo);
		yield return new WaitForSeconds (0.1f);
		if (dist>0.1f) {
			foreach (BoxCollider c in col) {
				if (c.isTrigger == false) {
					teste = true;
					c.enabled = false;
				} else {
					c.enabled = false;
				}
			}
			StartCoroutine (MoverEstatua (lobo));
		} else {
			foreach (BoxCollider c in col) {
				if (c.isTrigger == false) {
					if (teste == true) {
						c.enabled = true;
					}
				}
			}
		}
	}

	IEnumerator RodarEstatua(GameObject lobo){
		float tempo = 0;
		tempo += 0.5f * Time.deltaTime;
		lobo.transform.rotation = Quaternion.LerpUnclamped (lobo.transform.rotation, gameObject.transform.rotation, tempo);
		yield return new WaitForSeconds (0.1f);
		if(lobo.gameObject.tag == "LoboRoxo"){
			if (lobo.transform.rotation.eulerAngles.y > 135f) {
				StartCoroutine (RodarEstatua (lobo));
			}
		}else if(lobo.gameObject.tag == "LoboVermelho"){
			if (lobo.transform.rotation.eulerAngles.y < 313f) {
				StartCoroutine (RodarEstatua (lobo));
			}
		}else if(lobo.gameObject.tag == "LoboVerde"){
			if (lobo.transform.rotation.eulerAngles.y > 46f) {
				StartCoroutine (RodarEstatua (lobo));
			}
		}else if(lobo.gameObject.tag == "LoboAzul"){
			if (lobo.transform.rotation.eulerAngles.y < 223f) {
				StartCoroutine (RodarEstatua (lobo));
			}
		}
	}

}
