using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuartaFaseMecanica : MonoBehaviour {

    bool rodando = false;
    bool caiu = false;
    CameraShake shake;
    Renderer[] viking;
    Light[] luzes;
    Animator animator;
    Color corOriginal;
    float alpha =0;

	// Use this for initialization
	void Start () {
        shake = GetComponent<CameraShake>();
        viking = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Renderer>();
        luzes = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Light>();
        corOriginal = luzes[0].color;
        //TIRAR ISSO DAQUI QUANDO TIVER O QRCODE DA FASE 4
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        animator.speed = 1;
        StartCoroutine(Teste());
    }

    IEnumerator Teste() {
        yield return new WaitForSeconds(0.2f);
        RotacaoPersonagem.inicioAnim = false;
        RotacaoPersonagem.naoMexer = false;
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
                shake.shakeDuration = 1.2f;
                if (rodando == false) {
                    StartCoroutine(Vermelha());
                }
            } else if (gameObject.tag == "PlacaCinza") {
                print("PiSOU CINZA");
                shake.camTransform = gameObject.transform.GetChild(0);
                shake.shakeDuration = 1.2f;
                if (rodando == false) {
                    Cinza();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            if(caiu == true) {
                caiu = false;
                RotacaoPersonagem.naoMexer = true;
                RotacaoPersonagem.x = 0;
                RotacaoPersonagem.z = 0;
                Movimento.rb.velocity = new Vector3(0 , 0 , 0);
                SegundaFaseMecanica.gameOver = true;
                GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = false;
                animator.speed = 1;
                animator.SetTrigger("Caindo");
                StartCoroutine(FicarInvisivel());

            }

        }
    }

    IEnumerator FicarInvisivel() {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Caindo"));
        yield return new WaitForSeconds(0.3f);
        foreach (Renderer r in viking) {
            r.material.SetInt("_SrcBlend" , (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
            r.material.SetInt("_DstBlend" , (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            r.material.SetInt("_ZWrite" , 0);
            r.material.DisableKeyword("_ALPHATEST_ON");
            r.material.EnableKeyword("_ALPHABLEND_ON");
            r.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            r.material.renderQueue = 3000;
            r.material.color = new Color(1 , 1 , 1 , 0);
        }
        foreach (Light l in luzes) {
            l.gameObject.GetComponent<LightBehaviourFire>().originalColor = new Color(0,0,0,0);
        }
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Levantando"));
        RotacaoPersonagem.inicioAnim = true;
        animator.speed = 0;
        GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFase4").transform.localPosition;
        GameObject.FindGameObjectWithTag("Player").transform.localRotation = GameObject.Find("LugarFase4").transform.localRotation;
        alpha = 0;
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        rodando = false;
        gameObject.tag = "PlacaCinza";
        StartCoroutine(FicarVisivel());
    }

    IEnumerator FicarVisivel() {
        if (alpha < 0.9f) {
            foreach (Renderer r in viking) {
                r.material.color = new Color(1 , 1 , 1 , Mathf.Lerp(r.material.color.a,1,Time.deltaTime*10));
                alpha = r.material.color.a;
            }
            print(alpha);
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(FicarVisivel());
        }
        else {
            print("ASDASD");
            foreach (Renderer r in viking) {
                r.material.SetInt("_SrcBlend" , (int) UnityEngine.Rendering.BlendMode.One);
                r.material.SetInt("_DstBlend" , (int) UnityEngine.Rendering.BlendMode.Zero);
                r.material.SetInt("_ZWrite" , 1);
                r.material.DisableKeyword("_ALPHATEST_ON");
                r.material.DisableKeyword("_ALPHABLEND_ON");
                r.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                r.material.renderQueue = -1;
            }
            foreach (Light l in luzes) {
                l.gameObject.GetComponent<LightBehaviourFire>().originalColor = corOriginal;
            }
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
            RotacaoPersonagem.naoMexer = false;
            RotacaoPersonagem.inicioAnim = false;
        }
    }


    IEnumerator Vermelha() {
        rodando = true;
        yield return new WaitForSecondsRealtime(2);
        StartCoroutine(CairPlataforma());
    }
    void Cinza() {
        rodando = true;
        StartCoroutine(CairPlataforma());
    }

    IEnumerator CairPlataforma() {
        shake.enabled = true;
        yield return new WaitForSecondsRealtime(0.2f);
        caiu = true;
        yield return new WaitForSecondsRealtime(1f);
        GetComponentInChildren<Animation>().Play();
        shake.enabled = false;
    }

}
