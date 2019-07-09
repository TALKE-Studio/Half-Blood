using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedraRolando : MonoBehaviour {


    public float velocidade = 35;
    float t = 0.2f;
    bool rodar = true;
    float v = 35;
    public Transform filhoT;
    bool destruir = false;
    Color alphaColor;
    Color original;
    MeshRenderer[] cores;
    float tC = 0.2f;
    Vector3 localPoint;

    // Use this for initialization
    void Start () {
        StartCoroutine(Crescer());
        alphaColor = gameObject.transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material.color;
        original = alphaColor;
        alphaColor.a = 0;
        cores = gameObject.GetComponentsInChildren<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        if (rodar == true) {
            Rolar();
        }
        if(destruir == true) {
            foreach(MeshRenderer c in cores) {
                c.material.color = Color.Lerp(original, alphaColor, tC * Time.deltaTime);
                tC += 0.2f;
            }
        }
	}

    IEnumerator Crescer() {
        float lVal = Mathf.Lerp(0.8f, 1, t);
        t += 0.2f;
       // print(lVal);
        gameObject.transform.localScale = new Vector3(lVal,lVal,lVal);
        yield return new WaitForSeconds(0.2f);
        if(lVal < 0.9f) {
            StartCoroutine(Crescer());
        } else {
            gameObject.transform.localScale.Set(1, 1, 1);
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }

    void Move() {
        if (rodar == true) {
            transform.Translate(Vector3.forward * velocidade * Time.deltaTime, Space.Self);
        } else {
            transform.Translate(Vector3.back * v * Time.deltaTime, Space.Self);
            v *= 0.9f;
        }
    }

    void Rolar() {
            gameObject.transform.GetChild(0).Rotate(Vector3.right, 10 * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if(other.name == "Cenario_04_paredes") {
            //print("BATEU");
            rodar = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.transform.GetChild(0).eulerAngles = new Vector3(0, 0, 0);
            gameObject.GetComponentInChildren<Animator>().enabled = true;
            StartCoroutine(ComecarADestruir());
            //Destroy(gameObject);
        }
        else if(other.tag == "Player") {
           // print("ATROPELOU");
            Vector3 direction = other.transform.position - transform.position;
            float fwdDot = Vector3.Dot(other.transform.forward, direction.normalized);
            float rightDot = Vector3.Dot(other.transform.right, direction.normalized);
            print(fwdDot + " " + rightDot);
            RotacaoPersonagem.animator.SetFloat("Frente", fwdDot);
            RotacaoPersonagem.animator.SetFloat("Lados", -rightDot);
            RotacaoPersonagem.naoMexer = true;
            RotacaoPersonagem.x = 0;
            RotacaoPersonagem.z = 0;
            Movimento.rb.velocity = new Vector3(0, 0, 0);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>().enabled = false;
            RotacaoPersonagem.animator.speed = 1;
            RotacaoPersonagem.animator.SetTrigger("Bateu");
            RotacaoPersonagem.animator.speed = 1;
            StartCoroutine(EsperarAnim());
        }
    }

    private void OnDrawGizmos() {
        if(localPoint != null) {
            Gizmos.DrawWireSphere(localPoint, 5f);
        }
    }

    IEnumerator EsperarAnim() {
        yield return new WaitForSeconds(0.25f);
        yield return new WaitForSeconds(RotacaoPersonagem.animator.GetCurrentAnimatorStateInfo(0).length);
        RotacaoPersonagem.animator.speed = 1;
        RotacaoPersonagem.animator.SetTrigger("Levantar");
        yield return new WaitForSeconds(0.25f);
        yield return new WaitForSeconds(RotacaoPersonagem.animator.GetCurrentAnimatorStateInfo(0).length);
        RotacaoPersonagem.animator.speed = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>().enabled = true;
        RotacaoPersonagem.naoMexer = false;
        //gameObject.GetComponent<SphereCollider>().enabled = true;
    }

    IEnumerator ComecarADestruir() {
        yield return new WaitForSeconds(2);
        destruir = true;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
