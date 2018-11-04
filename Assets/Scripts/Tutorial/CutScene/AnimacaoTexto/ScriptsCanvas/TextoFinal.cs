using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoFinal : MonoBehaviour {

    public GameObject Texto9;
    public GameObject textoContinuar;
    bool podeavancar = false;
    Touch touch;
    static public bool tocou = false;

    // Use this for initialization
    void Start () {
        StartCoroutine(Trava());
        StartCoroutine(Continuar());
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetTouch(i).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)) && podeavancar == true)
            {
                Texto9.GetComponent<Animator>().SetBool("Proximo", true);
                textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
                tocou = true;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && podeavancar == true)
        {
            Texto9.GetComponent<Animator>().SetBool("Proximo", true);
            textoContinuar.GetComponent<Animator>().SetBool("Proximo", true);
            tocou = true;

        }

    }

    IEnumerator Trava()
    {
        yield return new WaitForSeconds(6f);
        podeavancar = true;

    }

    IEnumerator Continuar()
    {
        yield return new WaitForSeconds(5f);
        textoContinuar.SetActive(true);
    }


}
