using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.AI;

public class SegundaFaseMecanica : MonoBehaviour {
	public GameObject[] pedras;
	float dist = 100;
    public static bool pedraAColetada = false;
    public static bool pedraRColetada = false;
    public static bool pedraPColetada = false;
    public static bool pedraIColetada = false;
    public GameObject[] garras;
	float dist2 = 100;
	public static bool pedraAColocada = false;
    public static bool pedraRColocada = false;
    public static bool pedraPColocada = false;
    public static bool pedraIColocada = false;
    bool pedraFinal = false;
    public static bool tutorial;
    public static bool fase1;
    public static bool fase2;
    public static bool fase3;
    public static bool gameOver = false;
    public Sprite Ituto;
    public Sprite Ifase2;
    public GameObject telaBranca;

    // Use this for initialization
    void Start () {
        /*  if(tutorial == true) {
              GameObject.Find("TelaDoCapitulo").GetComponent<Image>().sprite = Ituto;
              GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("FaseTutorialImageTarget").transform);
              GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFaseTutorial").transform.localPosition;
              GameObject.FindGameObjectWithTag("Player").transform.localRotation = GameObject.Find("LugarFaseTutorial").transform.localRotation;
              GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().enabled = true;
              GameObject.FindGameObjectWithTag("Player").GetComponent<AndarSosinho>().enabled = true;

          }*/
        GameObject.Find("TelaDoCapitulo").GetComponent<Image>().sprite = Ifase2;
        GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("Fase1ImageTarget").transform);
        GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFase1").transform.localPosition;
        GameObject.FindGameObjectWithTag("Player").transform.localRotation = GameObject.Find("LugarFase1").transform.localRotation;
        pedraAColocada = false;
        pedraRColocada = false;
        pedraPColocada = false;
        pedraIColocada = false;
        StartCoroutine(PosInicial());
    }
	
	// Update is called once per frame
	void Update () {
        PickRock();
        PutRock();

        if (pedraAColocada == true && pedraRColocada == true)
        {
            if (pedraFinal == false)
            {
                PedraFinalScript();
            }
        }

    }

    IEnumerator PosInicial() {
        yield return new WaitForSeconds(0.1f);
        if (tutorial == true) {
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("FaseTutorialImageTarget").transform);
            GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFaseTutorial").transform.localPosition;
            GameObject.FindGameObjectWithTag("Player").transform.localRotation = GameObject.Find("LugarFaseTutorial").transform.localRotation;
        } else if (fase2 == true) {
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("Fase2ImageTarget").transform);
            GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFase2").transform.localPosition;
            GameObject.FindGameObjectWithTag("Player").transform.localRotation = GameObject.Find("LugarFase2").transform.localRotation;
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

    void PickRock() {
        if (Input.GetKeyDown(KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown("Jump") == true) {
            foreach (GameObject p in pedras) {
                if (p != null) {
                    dist = Vector3.Distance(gameObject.transform.position, p.gameObject.transform.position);
                }
                if (dist < 15) {
                    if (p.name == "PedraRosa") {
                        if (pedraRColetada == false && pedraRColocada == false) {
                            pedraRColetada = true;
                            StartCoroutine(ColetarPedra(p));
                        }
                    } else if (p.name == "PedraAzul") {
                        if (pedraAColetada == false && pedraAColocada == false) {
                            pedraAColetada = true;
                            StartCoroutine(ColetarPedra(p));
                        }
                    } else if (p.name == "death_pedra") {
                        if (pedraPColetada == false && pedraPColocada == false) {
                            pedraPColetada = true;
                            StartCoroutine(ColetarPedra(p));
                        }
                    } else if (p.name == "intelligence_pedra") {
                        if (pedraIColetada == false && pedraIColocada == false) {
                            pedraIColetada = true;
                            StartCoroutine(ColetarPedra(p));
                        }
                    }
                }
            }
        }
    }

    void PutRock() {
        if (Input.GetKeyDown(KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown("Jump") == true) {
            foreach (GameObject g in garras) {
                dist2 = Vector3.Distance(gameObject.transform.position, g.gameObject.transform.position);
                if (dist2 < 20) {
                    if (g.name == "GarraAzul" && pedraAColetada == true && pedraAColocada == false) {
                        pedraAColocada = true;

                    } else if (g.name == "GarraRosa" && pedraRColetada == true && pedraRColocada == false) {
                        pedraRColocada = true;

                    } else if (g.name == "death_base" && pedraPColetada == true && pedraPColocada == false) {
                        pedraPColocada = true;

                    } else if (g.name == "intelligence_base" && pedraIColetada == true && pedraIColocada == false) {
                        pedraIColocada = true;

                    }
                }
            }
        }
    }

    IEnumerator ColetarPedra(GameObject pedra) {
        RotacaoPersonagem.naoMexer = true;
        RotacaoPersonagem.x = 0;
        RotacaoPersonagem.z = 0;
        Movimento.rb.velocity = new Vector3(0, 0, 0);
        Vector3 alvo = new Vector3(pedra.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, pedra.transform.position.z);
        GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("PegouChao");
        yield return new WaitForSecondsRealtime(1);
        RotacaoPersonagem.naoMexer = false;
        dist = 100;
        pedra.GetComponent<MeshRenderer>().enabled = false;
        pedra.transform.localPosition = new Vector3(pedra.transform.localPosition.x, pedra.transform.localPosition.y - 5, pedra.transform.localPosition.z);
        if (pedra.name != "PedraAzul" && pedra.name != "PedraRosa") {
            pedra.GetComponentInChildren<Light>().enabled = false;
        }
    }
                    

	IEnumerator ColocarPedra(GameObject pedra, GameObject g){
        if (g.name == "GarraAzul" && pedraAColetada == true && pedraAColocada == false) {
            RotacaoPersonagem.naoMexer = true;
            RotacaoPersonagem.x = 0;
            RotacaoPersonagem.z = 0;
            Movimento.rb.velocity = new Vector3(0, 0, 0);
            Vector3 alvo = new Vector3(g.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, g.transform.position.z);
            GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("TocouParede");
            yield return new WaitForSecondsRealtime(1);
            RotacaoPersonagem.naoMexer = false;
            GameObject.Find(pedra.name).GetComponent<MeshRenderer>().enabled = true;
            if (pedra.name != "PedraRosa" && pedra.name != "PedraAzul") {
                GameObject.Find(pedra.name).GetComponentInChildren<Light>().enabled = true;
                GameObject.Find(pedra.name).GetComponent<Animation>().Play();
                gameOver = true;
                RotacaoPersonagem.naoMexer = true;
                RotacaoPersonagem.x = 0;
                RotacaoPersonagem.z = 0;
                Movimento.rb.velocity = new Vector3(0, 0, 0);
                RotacaoPersonagem.animator.SetBool("Andando", false);
                GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = false;
                GameObject.FindGameObjectWithTag("Botoes").GetComponent<Canvas>().sortingOrder = 60;
                telaBranca.SetActive(true);
                telaBranca.GetComponent<Animator>().SetTrigger("gameOver");
            } else {
                GameObject.Find(pedra.name).gameObject.transform.SetParent(g.transform);
                GameObject.Find(pedra.name).gameObject.transform.localPosition = GameObject.Find("Pedra_Garras").transform.localPosition;
                GameObject.Find(pedra.name).gameObject.transform.localRotation = GameObject.Find("Pedra_Garras").transform.localRotation;
                GameObject.Find(pedra.name).AddComponent<LightBehaviourStone>();
            }
        }
	}

}
