using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class MecanicaTochaAzul : MonoBehaviour {

    public GameObject[] toras;
    float dist = 100;
    public static bool tAzul = false;
    float tempo = 0.1f;
    Color original;
    Color azul =  new Color(0.03301889f, 0.2960934f, 1);
    Light[] luz;
    float c = 0;
    public Sprite Ifase3;
    public float tempoDeTocha = 15;
    public static int nTochasAcesas = 0;
    bool pedraFinal = false;
    public static bool pedraIColetada = false;
    public static bool pedraIColocada = false;
    float dist2;
    public GameObject pedra;
    public GameObject pedraBase;
    public GameObject telaBranca;
    public Texture textura;
    public AudioClip pegouAudio;
    public AudioClip colocouAudio;
    public AudioClip passos;

    // Use this for initialization
    void Start () {
        pedraIColocada = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = passos;
        GameObject.Find("TelaDoCapitulo").GetComponent<Image>().sprite = Ifase3;//TROCAR PRA FASE3
        GameObject.FindGameObjectWithTag("Botoes").GetComponent<Canvas>().enabled = true;
        GameObject.Find("ARCamera").GetComponent<ParedeTransparent>().enabled = false;
        GameObject.Find("ARCamera").GetComponent<ParedeTransparent>().enabled = true;
        GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
        original = gameObject.GetComponentInChildren<Light>().GetComponent<LightBehaviourFire>().originalColor;
        luz = gameObject.GetComponentsInChildren<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Acender());
        StartCoroutine(Colocar());
        if (nTochasAcesas == 4) {
            PickRock();
            PutRock();
            if (pedraFinal == false) {
                GameObject.FindGameObjectWithTag("Porta").GetComponent<Animator>().SetBool("Abrir", true);
                GameObject.FindGameObjectWithTag("Porta").GetComponent<BoxCollider>().enabled = false;
                GameObject.FindGameObjectWithTag("Porta").GetComponentInChildren<AudioSource>().Play();
                PedraFinalScript();
            }
        }
	}

    private void PedraFinalScript() {
        pedraFinal = true;
        GameObject.Find("Fase3ImageTarget").GetComponent<CameraShake>().shakeDuration = 1f;
        GameObject.Find("Fase3ImageTarget").GetComponent<CameraShake>().enabled = true;
        GameObject.FindGameObjectWithTag("Teto").GetComponent<Animation>().Play();
        GameObject.Find("intelligence_pedra").GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        GameObject.Find("intelligence_pedra").GetComponentInChildren<Light>().enabled = true;
        GameObject.Find("intelligence_pedra").AddComponent<LightBehaviourStone>();
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
                            t.GetComponent<AudioSource>().enabled = true;
                            yield return new WaitForSeconds(0.25f);
                            yield return new WaitForSeconds(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                            t.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
                            //  yield return new WaitForSeconds(1f);
                            RotacaoPersonagem.naoMexer = false;
                            dist = 100;
                            c = 0;
                            if(nTochasAcesas == 1) {
                                tempoDeTocha = 20;
                            }
                            if(nTochasAcesas == 2) {
                                tempoDeTocha = 10;
                            }
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

    void PickRock() {
        if (Input.GetKeyDown(KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown("Jump") == true) {
            if (pedraIColetada == false) {
                dist = Vector3.Distance(gameObject.transform.position, pedra.gameObject.transform.position);
                if (dist < 15) {
                    if (pedraIColetada == false) {
                        pedraIColetada = true;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = pegouAudio;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
                        StartCoroutine(ColetarPedra());
                    }
                }
            }
        }
    }

    void PutRock() {
        if (Input.GetKeyDown(KeyCode.Space) == true || CrossPlatformInputManager.GetButtonDown("Jump") == true) {
            if (pedraIColetada == true) {
                dist = Vector3.Distance(gameObject.transform.position, pedraBase.gameObject.transform.position);
                if (dist < 20) {
                    if (pedraIColocada == false) {
                        pedraIColocada = true;
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
        RotacaoPersonagem.naoMexer = false;
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
