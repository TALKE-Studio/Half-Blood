using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIniciarJogo : MonoBehaviour {

    public GameObject seleTela;

	public void Jogar() {
        seleTela.SetActive(true);
    }

    public void Voltar() {
        seleTela.SetActive(false);
    }

    public void Tutoba() {
        SegundaFaseMecanica.tutorial = true;
        SceneManager.LoadScene("Labirinto");
    }

    public void Fase1() {
        SegundaFaseMecanica.fase1 = true;
        SceneManager.LoadScene("Labirinto");
    }

    public void Fase2() {
        SegundaFaseMecanica.fase2 = true;
        SceneManager.LoadScene("Labirinto");
    }
}
