using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PedraFinalFase1 : MonoBehaviour {

    public static bool pedraCColetada = false;
    public static bool pedraCColocada = false;
    float dist;
    public GameObject pedra;
    public GameObject pedraBase;
    public GameObject telaBranca;
    public Texture textura;
    public AudioClip pegouAudio;
    public AudioClip colocouAudio;
    public AudioClip passos;

    // Use this for initialization
    void Start () {
        SegundaFaseMecanica.gameOver = false;
        pedraCColocada = false;
        DefaultTrackableEventHandler.jaRodou = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = passos;
    }
	
	// Update is called once per frame
	void Update () {
        PickRock();
        PutRock();
    }

    void PickRock() {
        if (Input.GetKeyDown(KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown("Jump") == true) {
            if (pedraCColetada == false) {
                dist = Vector3.Distance(gameObject.transform.position, pedra.gameObject.transform.position);
                if (dist < 15) {
                    if (pedraCColetada == false) {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = pegouAudio;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
                        pedraCColetada = true;
                        StartCoroutine(ColetarPedra());
                    }
                }
            }
        }
    }

    void PutRock() {
        if (Input.GetKeyDown(KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown("Jump") == true) {
            if (pedraCColetada == true) {
                dist = Vector3.Distance(gameObject.transform.position, pedraBase.gameObject.transform.position);
                if (dist < 20) {
                    if (pedraCColocada == false) {
                        pedraCColocada = true;
                        StartCoroutine(ColocarPedra());
                    }
                }
            }
        }
    }

    IEnumerator ColetarPedra() {
        RotacaoPersonagem.naoMexer = true;
        RotacaoPersonagem.x = 0;
        RotacaoPersonagem.z = 0;
        Movimento.rb.velocity = new Vector3(0, 0, 0);
        Vector3 alvo = new Vector3(pedra.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, pedra.transform.position.z);
        GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("PegouChao");
        yield return new WaitForSecondsRealtime(1);
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = passos;
        RotacaoPersonagem.naoMexer = false;
        dist = 100;
        pedra.GetComponent<MeshRenderer>().enabled = false;
        pedra.transform.localPosition = new Vector3(pedra.transform.localPosition.x, pedra.transform.localPosition.y - 5, pedra.transform.localPosition.z);
        pedra.GetComponentInChildren<Light>().enabled = false;
    }


    IEnumerator ColocarPedra() {
        SegundaFaseMecanica.gameOver = true;
        RotacaoPersonagem.naoMexer = true;
        RotacaoPersonagem.x = 0;
        RotacaoPersonagem.z = 0;
        Movimento.rb.velocity = new Vector3(0, 0, 0);
        Vector3 alvo = new Vector3(pedraBase.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, pedraBase.transform.position.z);
        GameObject.FindGameObjectWithTag("Player").transform.LookAt(alvo, Vector3.up);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("TocouParede");
        yield return new WaitForSecondsRealtime(1);
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = colocouAudio;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
        pedra.GetComponent<MeshRenderer>().enabled = true;
        pedraBase.GetComponent<Renderer>().material.mainTexture = textura;
        pedra.GetComponentInChildren<Light>().enabled = true;
        pedra.GetComponent<Animation>().Play();
        RotacaoPersonagem.naoMexer = true;
        RotacaoPersonagem.x = 0;
        RotacaoPersonagem.z = 0;
        Movimento.rb.velocity = new Vector3(0, 0, 0);
        RotacaoPersonagem.animator.SetBool("Andando", false);
        GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("Botoes").GetComponent<Canvas>().sortingOrder = 60;
        yield return new WaitForSecondsRealtime(1);
        telaBranca.SetActive(true);
        telaBranca.GetComponent<Animator>().SetTrigger("gameOver");
    }

}
