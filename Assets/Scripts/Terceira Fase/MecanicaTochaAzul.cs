using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MecanicaTochaAzul : MonoBehaviour {

    public GameObject[] toras;
    float dist = 100;
    public static bool tAzul = false;
    float tempo = 0.1f;
    Color original;
    Color azul =  new Color(0.03301889f, 0.2960934f, 1);
    Light[] luz;
    float c = 0;
    public float tempoDeTocha = 12;
    public static int nTochasAcesas = 0;

    // Use this for initialization
    void Start () {
		original = gameObject.GetComponentInChildren<Light>().GetComponent<LightBehaviourFire>().originalColor;
        luz = gameObject.GetComponentsInChildren<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Acender());
        StartCoroutine(Colocar());
        if(nTochasAcesas == 4) {
            GameObject.Find("PortasFase3").GetComponent<Animation>().Play();
        }
	}


    IEnumerator Acender() {
        if (Input.GetKeyDown(KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown("Jump") == true) {
            foreach(GameObject t in toras) {
                dist = Vector3.Distance(gameObject.transform.position, t.transform.position);
                // print(dist);
                if (dist < 8.8f) {
                    if(tAzul == false) {
                        if (t.GetComponentInChildren<Light>().enabled == true) {
                            tAzul = true;
                            gameObject.GetComponent<Animator>().speed = 1;
                            RotacaoPersonagem.naoMexer = true;
                            RotacaoPersonagem.x = 0;
                            RotacaoPersonagem.z = 0;
                            Movimento.rb.velocity = new Vector3(0, 0, 0);
                            gameObject.GetComponent<Animator>().speed = 1;
                            Vector3 alvo = new Vector3(t.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, t.transform.position.z);
                            gameObject.transform.LookAt(alvo, Vector3.up);
                            gameObject.GetComponent<Animator>().SetTrigger("UsarTocha");
                            yield return new WaitForSeconds(0.25f);
                            yield return new WaitForSeconds(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                            //yield return new WaitForSeconds(0.5f);
                            StartCoroutine(MudarCor(original, azul));
                            RotacaoPersonagem.naoMexer = false;
                            dist = 100;
                        }
                    }
                }
            }

        }

    }

    IEnumerator Colocar() {
        if (Input.GetKeyDown(KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown("Jump") == true) {
            foreach (GameObject t in toras) {
                dist = Vector3.Distance(gameObject.transform.position, t.transform.position);
                // print(dist);
                if (dist < 8.7f) {
                    if (tAzul == true) {
                        if (t.GetComponentInChildren<Light>().enabled == false) {
                            nTochasAcesas++;
                            Light[] luz = t.GetComponentsInChildren<Light>();
                            foreach(Light l in luz) {
                                l.enabled = true;
                            }
                            tAzul = true;
                            RotacaoPersonagem.naoMexer = true;
                            RotacaoPersonagem.x = 0;
                            RotacaoPersonagem.z = 0;
                            Movimento.rb.velocity = new Vector3(0, 0, 0);
                            RotacaoPersonagem.animator.speed = 1;
                            Vector3 alvo = new Vector3(t.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, t.transform.position.z);
                            GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
                            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("UsarTocha");
                            yield return new WaitForSeconds(0.25f);
                            yield return new WaitForSeconds(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                          //  yield return new WaitForSeconds(1f);
                            RotacaoPersonagem.naoMexer = false;
                            dist = 100;
                            c = 0;
                        }
                    }
                }
            }

        }

    }


    IEnumerator MudarCor(Color inicial,Color final) {
        Color color = Color.Lerp(inicial, final, tempo);
        tempo += 0.1f;
        foreach (Light l in luz) {
            l.GetComponent<LightBehaviourFire>().originalColor = color;
        }
        if (final == azul) {
            if (color.b < azul.b) {
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(MudarCor(inicial,final));
            } else {
                tempo = 0.1f;
                StartCoroutine(Contador());
            }
        } else {
            if (color.r<original.r) {
                yield return new WaitForSeconds(0.1f);
                StartCoroutine(MudarCor(inicial, final));
            } else {
                tempo = 0.1f;
            }
        }
    }

    IEnumerator Contador() {
        yield return new WaitForSeconds(1);
        c++;
        if (c < tempoDeTocha && tAzul == true) {
            StartCoroutine(Contador());
        } else if(c>=tempoDeTocha || tAzul == false){
            c = 0;
            tAzul = false;
            StartCoroutine(MudarCor(azul, original));
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "pedra") {
            tAzul = false;
        }
    }

}
