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
    public GameObject[] garras;
	float dist2 = 100;
	public static bool pedraAColocada = false;
    public static bool pedraRColocada = false;
    public static bool pedraPColocada = false;
    bool pedraFinal = false;
    public static bool fase2;
    public static bool gameOver = false;
    public Sprite Ifase2;
    public GameObject telaBranca;
    public Texture textura;
    WaitForSeconds esperar;
    public AudioClip pegouAudio;
    public AudioClip colocouAudio;
    public AudioClip passos;

    // Use this for initialization
    IEnumerator Start () {
        GameObject.Find("TelaDoCapitulo").GetComponent<Image>().sprite = Ifase2;
        pedraAColocada = false;
        pedraRColocada = false;
        pedraPColocada = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = passos;
        esperar = new WaitForSeconds(1);
        yield return new WaitForSeconds(0.1f);
        GameObject.Find("death_pedra").GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(PickRock());
        PutRock();

        if (pedraAColocada == true && pedraRColocada == true)
        {
            if (pedraFinal == false)
            {
                GameObject.FindGameObjectWithTag("Porta").GetComponentInChildren<AudioSource>().Play();
                PedraFinalScript();
            }
        }

    }

    private void PedraFinalScript()
    {
        pedraFinal = true;
        GameObject.FindGameObjectWithTag("Porta").GetComponent<Animator>().SetBool("Abrir", true);
        GameObject.FindGameObjectWithTag("Porta").GetComponent<BoxCollider>().enabled = false;
        GameObject.Find("Fase2ImageTarget").GetComponent<CameraShake>().shakeDuration = 1f;
        GameObject.Find("Fase2ImageTarget").GetComponent<CameraShake>().enabled = true;
        GameObject.FindGameObjectWithTag("Teto").GetComponent<Animation>().Play();
        GameObject.Find("death_pedra").GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        GameObject.Find("death_pedra").GetComponentInChildren<Light>().enabled = true;
        GameObject.Find("death_pedra").AddComponent<LightBehaviourStone>();
    }

    IEnumerator PickRock() {
        if (Input.GetKeyDown(KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown("Jump") == true) {
            foreach (GameObject p in pedras) {
                if (p != null) {
                    dist = Vector3.Distance(gameObject.transform.position, p.gameObject.transform.position);
                }
                if (dist < 15) {
                    if (p.name == "PedraRosa") {
                        if (pedraRColetada == false && pedraRColocada == false) {
                            pedraRColetada = true;
                            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = pegouAudio;
                            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
                            StartCoroutine(ColetarPedra(p));
                        }
                    } else if (p.name == "PedraAzul") {
                        if (pedraAColetada == false && pedraAColocada == false) {
                            pedraAColetada = true;
                            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = pegouAudio;
                            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
                            StartCoroutine(ColetarPedra(p));
                        }
                    } else if (p.name == "death_pedra") {
                        if (pedraPColetada == false && pedraPColocada == false) {
                            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = pegouAudio;
                            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
                            StartCoroutine(ColetarPedra(p));
                            yield return esperar;
                            pedraPColetada = true;
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
                        StartCoroutine(ColocarPedra("PedraAzul", g));
                    } else if (g.name == "GarraRosa" && pedraRColetada == true && pedraRColocada == false) {
                        pedraRColocada = true;
                        StartCoroutine(ColocarPedra("PedraRosa", g));
                    } else if (g.name == "death_base" && pedraPColetada == true && pedraPColocada == false) {
                        pedraPColocada = true;
                        StartCoroutine(ColocarPedra("death_pedra", g));
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
        yield return esperar;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = passos;
        RotacaoPersonagem.naoMexer = false;
        dist = 100;
        pedra.GetComponent<MeshRenderer>().enabled = false;
        pedra.transform.localPosition = new Vector3(pedra.transform.localPosition.x, pedra.transform.localPosition.y - 5, pedra.transform.localPosition.z);
        if (pedra.name != "PedraAzul" && pedra.name != "PedraRosa") {
            pedra.GetComponentInChildren<Light>().enabled = false;
        }
    }
                    

	IEnumerator ColocarPedra(string pedra, GameObject g){
        RotacaoPersonagem.naoMexer = true;
        RotacaoPersonagem.x = 0;
        RotacaoPersonagem.z = 0;
        Movimento.rb.velocity = new Vector3(0, 0, 0);
        Vector3 alvo = new Vector3(g.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, g.transform.position.z);
        GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("TocouParede");
        yield return esperar;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = colocouAudio;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
        GameObject.Find(pedra).GetComponent<MeshRenderer>().enabled = true;
        if (pedra != "PedraRosa" && pedra != "PedraAzul") {
            g.GetComponent<Renderer>().material.mainTexture = textura;
            GameObject.Find(pedra).GetComponentInChildren<Light>().enabled = true;
            GameObject.Find(pedra).GetComponent<Animation>().Play();
            gameOver = true;
            RotacaoPersonagem.naoMexer = true;
            RotacaoPersonagem.x = 0;
            RotacaoPersonagem.z = 0;
            Movimento.rb.velocity = new Vector3(0, 0, 0);
            RotacaoPersonagem.animator.SetBool("Andando", false);
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = false;
            GameObject.FindGameObjectWithTag("Botoes").GetComponent<Canvas>().sortingOrder = 60;
            yield return esperar;
            telaBranca.SetActive(true);
            telaBranca.GetComponent<Animator>().SetTrigger("gameOver");
        } else {
            GameObject.Find(pedra).gameObject.transform.SetParent(g.transform);
            GameObject.Find(pedra).gameObject.transform.localPosition = GameObject.Find("Pedra_Garras").transform.localPosition;
            GameObject.Find(pedra).gameObject.transform.localRotation = GameObject.Find("Pedra_Garras").transform.localRotation;
            GameObject.Find(pedra).AddComponent<LightBehaviourStone>();
            yield return new WaitForSeconds(0.5f);
            RotacaoPersonagem.naoMexer = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = passos;
        }
	}

}
