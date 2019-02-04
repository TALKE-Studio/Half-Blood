using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarOuContinuar : MonoBehaviour {

	public void Reiniciar() {
        if(SegundaFaseMecanica.tutorial == true) {

        }
        if (SegundaFaseMecanica.fase1 == true) {
            SceneManager.LoadScene("Labirinto");
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("Fase1ImageTarget").transform);
            GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFase1").transform.localPosition;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
            RotacaoPersonagem.naoMexer = false;
        }
        if(SegundaFaseMecanica.fase2 == true) {
            GameObject.FindGameObjectWithTag("TelaBranca").GetComponent<Animator>().SetTrigger("gameOver2");
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("Fase2ImageTarget").transform);
            GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFase2").transform.localPosition;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
            RotacaoPersonagem.naoMexer = false;
        }
    }

    public void Continuar() {
        if (SegundaFaseMecanica.fase2 == true) {
            SceneManager.LoadScene("Menu");
        }
        if (SegundaFaseMecanica.fase1 == true) {
            SceneManager.LoadScene("Menu");
            /*GameObject.FindGameObjectWithTag("TelaBranca").GetComponent<Animator>().SetTrigger("gameOver2");
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("Fase2ImageTarget").transform);
            GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFase2").transform.localPosition;
            GameObject.FindGameObjectWithTag("Player").transform.localRotation = GameObject.Find("LugarFase1").transform.localRotation;
            SegundaFaseMecanica.gameOver = false;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
            RotacaoPersonagem.naoMexer = false;
            SegundaFaseMecanica.fase1 = false;
            SegundaFaseMecanica.fase2 = true;*/
        }
        if (SegundaFaseMecanica.tutorial == true) {
            GameObject.Find("FinalTutorial").SetActive(false);
            Sala3.colocoupedra = false;
            GameObject.FindGameObjectWithTag("BordaCima").SetActive(false);
            GameObject.FindGameObjectWithTag("BordaBaixo").SetActive(false);
            GameObject.FindGameObjectWithTag("Botoes").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
            RotacaoPersonagem.naoMexer = false;
            CutsScene.olharValk = false;
            SegundaFaseMecanica.gameOver = false;
            RotacaoPersonagem.naoMexer = false;
            SceneManager.LoadScene("Menu");
        }
    }
}
