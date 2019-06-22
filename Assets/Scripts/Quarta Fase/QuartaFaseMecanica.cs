using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuartaFaseMecanica : MonoBehaviour {

    bool rodando = false;
    bool caiu = false;
    CameraShake shake;

	// Use this for initialization
	void Start () {
        shake = GetComponent<CameraShake>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos() {
        if (gameObject.tag == "PlacaVermelha") {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 10f);
        } else if (gameObject.tag == "PlacaCinza") {
            Gizmos.color = Color.gray;
            Gizmos.DrawWireSphere(transform.position, 10f);
        } else if (gameObject.tag == "PlacaVerde") {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 10f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (gameObject.tag == "PlacaVermelha") {
                print("PiSOU VERMELHO");
                shake.camTransform = gameObject.transform.GetChild(0);
                shake.shakeDuration = 1;
                if (rodando == false) {
                    StartCoroutine(Vermelha());
                }
            } else if (gameObject.tag == "PlacaCinza") {
                print("PiSOU CINZA");
                shake.camTransform = gameObject.transform.GetChild(0);
                shake.shakeDuration = 1;
                if (rodando == false) {
                    StartCoroutine(Cinza());
                }
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            if(caiu == true) {
                //RODAR ANIMACAO DO VIKING CAINDO QUANDO COMECAR A VIBRAR 
                RotacaoPersonagem.naoMexer = true;
                other.transform.Translate(Vector3.down*0.4f);
                
            }

        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            if(caiu == true) {
                print("ASDASD");
                // DEIXAR ELE INVISIVEL QUANDO CAIR
                GameObject.Find("Viking_LowPoly").GetComponent<Renderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                GameObject.Find("Viking_LowPoly").GetComponent<Renderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                GameObject.Find("Viking_LowPoly").GetComponent<Renderer>().material.SetInt("_ZWrite", 0);
                GameObject.Find("Viking_LowPoly").GetComponent<Renderer>().material.DisableKeyword("_ALPHATEST_ON");
                GameObject.Find("Viking_LowPoly").GetComponent<Renderer>().material.EnableKeyword("_ALPHABLEND_ON");
                GameObject.Find("Viking_LowPoly").GetComponent<Renderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                GameObject.Find("Viking_LowPoly").GetComponent<Renderer>().material.renderQueue = 3000;
                GameObject.Find("Viking_LowPoly").GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
            }
        }
    }

    IEnumerator Vermelha() {
        rodando = true;
        yield return new WaitForSecondsRealtime(2);
        shake.enabled = true;
        yield return new WaitForSecondsRealtime(1);
        GetComponentInChildren<Animation>().Play();
        shake.enabled = false;
        caiu = true;
    }
    IEnumerator Cinza() {
        rodando = true;
        shake.enabled = true;
        yield return new WaitForSecondsRealtime(1);
        GetComponentInChildren<Animation>().Play();
        shake.enabled = false;
        caiu = true;
    }

}
