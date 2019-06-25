using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuIniciarJogo : MonoBehaviour {

    public GameObject seleTela;
    public Sprite tut;
    public Sprite fas1;
    public Sprite fas2;
    public GameObject s;
    public GameObject prog;
    public GameObject fill;

    public void Jogar() {
        seleTela.SetActive(true);
    }

    public void Voltar() {
        seleTela.SetActive(false);
    }

    public void Tutoba() {
        prog.SetActive(true);
        fill.GetComponent<Image>().sprite = tut;
        StartCoroutine(Carregar("Tutorial"));
    }

    public void Fase1() {
        prog.SetActive(true);
        fill.GetComponent<Image>().sprite = fas1;
        StartCoroutine(Carregar("Fase1"));
    }

    public void Fase2() {
        prog.SetActive(true);
        fill.GetComponent<Image>().sprite = fas2;
        StartCoroutine(Carregar("Fase2"));
    }

    public void Fase3() {
        prog.SetActive(true);
        fill.GetComponent<Image>().sprite = fas2;
        StartCoroutine(Carregar("Fase3"));
    }

    IEnumerator Carregar(string fase) {
        AsyncOperation load = SceneManager.LoadSceneAsync(fase, LoadSceneMode.Single);
        s.GetComponent<Slider>().value = load.progress;
        while (!load.isDone) {
            s.GetComponent<Slider>().value = load.progress;
            yield return null;
        }

    }


}
