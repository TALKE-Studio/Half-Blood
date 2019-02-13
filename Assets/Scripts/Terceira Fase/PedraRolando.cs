using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedraRolando : MonoBehaviour {


    public float velocidade = 35;
    float t = 0.2f;

	// Use this for initialization
	void Start () {
        StartCoroutine(Crescer());
	}
	
	// Update is called once per frame
	void Update () {
        Movimento();
        Rolar();
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

    void Movimento() {
        transform.Translate(Vector3.forward*velocidade*Time.deltaTime, Space.Self);
    }

    void Rolar() {
        gameObject.transform.GetChild(0).Rotate(Vector3.right, 10 * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if(other.name == "Cenario_04_paredes") {
            print("BATEU");
            Destroy(gameObject);
        }
        else if(other.tag == "Player") {
            print("ATROPELOU");
            RaycastHit hit;
            Physics.Raycast(transform.position, other.transform.position, out hit);
            Vector3 localPoint = hit.transform.InverseTransformPoint(hit.point);
            Vector3 localDir = localPoint.normalized;
            float fwdDot = Vector3.Dot(localDir, Vector3.forward);
            float rightDot = Vector3.Dot(localDir, Vector3.right);
            Debug.DrawLine(other.transform.position, transform.position, Color.green, 10);
            /* if (Mathf.Abs(fwdDot) > Mathf.Abs(rightDot)) {
                 if (fwdDot > 0) {
                     fwdDot = 1;
                 } else {
                     fwdDot = -1;
                 }
             } else {
                 if (rightDot > 0) {
                     rightDot = 1;
                 } else {
                     rightDot = -1;
                 }
             }*/
            print(fwdDot + " " + rightDot);
            RotacaoPersonagem.animator.SetFloat("Frente", fwdDot);
            RotacaoPersonagem.animator.SetFloat("Lados", rightDot);
            RotacaoPersonagem.animator.SetTrigger("Bateu");
        }
    }


}
