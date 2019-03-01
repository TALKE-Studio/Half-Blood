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
        SegundaFaseMecanica.tutorial = true;
        SegundaFaseMecanica.fase2 = false;
        SegundaFaseMecanica.fase1 = false;
        prog.SetActive(true);
        fill.GetComponent<Image>().sprite = tut;
        StartCoroutine(Carregar());
    }

    public void Fase1() {
        SegundaFaseMecanica.fase1 = true;
        SegundaFaseMecanica.tutorial = false;
        SegundaFaseMecanica.fase2 = false;
        SegundaFaseMecanica.fase3 = false;
        prog.SetActive(true);
        fill.GetComponent<Image>().sprite = fas1;
        StartCoroutine(Carregar());
    }

    public void Fase2() {
        SegundaFaseMecanica.fase2 = true;
        SegundaFaseMecanica.fase1 = false;
        SegundaFaseMecanica.tutorial = false;
        SegundaFaseMecanica.fase3 = false;
        prog.SetActive(true);
        fill.GetComponent<Image>().sprite = fas2;
        StartCoroutine(Carregar());
    }

    public void Fase3() {
        SegundaFaseMecanica.fase3 = true;
        SegundaFaseMecanica.fase1 = false;
        SegundaFaseMecanica.tutorial = false;
        SegundaFaseMecanica.fase2 = false;
        prog.SetActive(true);
        fill.GetComponent<Image>().sprite = fas2;
        StartCoroutine(Carregar());
    }

    IEnumerator Carregar() {
        AsyncOperation load = SceneManager.LoadSceneAsync("Labirinto", LoadSceneMode.Single);
        s.GetComponent<Slider>().value = load.progress;
        while (!load.isDone) {
            s.GetComponent<Slider>().value = load.progress;
            yield return null;
        }

    }


}
