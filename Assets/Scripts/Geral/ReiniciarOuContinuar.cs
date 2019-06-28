using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarOuContinuar : MonoBehaviour {

	public void Reiniciar() {
        if(SceneManager.GetActiveScene().name == "Tutorial") {

        }
        if (SceneManager.GetActiveScene().name == "Fase1") {
            SceneManager.LoadScene("Fase1");
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("Fase1ImageTarget").transform);
            GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFase1").transform.localPosition;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
            RotacaoPersonagem.naoMexer = false;
        }
        if(SceneManager.GetActiveScene().name == "Fase2") {
            SceneManager.LoadScene("Fase2");
            GameObject.FindGameObjectWithTag("TelaBranca").GetComponent<Animator>().SetTrigger("gameOver2");
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(GameObject.Find("Fase2ImageTarget").transform);
            GameObject.FindGameObjectWithTag("Player").transform.localPosition = GameObject.Find("LugarFase2").transform.localPosition;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
            RotacaoPersonagem.naoMexer = false;
        }
    }

    public void Continuar() {
        if (SceneManager.GetActiveScene().name == "Tutorial") {
            /*            GameObject.Find("FinalTutorial").SetActive(false);
            Sala3.colocoupedra = false;
            GameObject.FindGameObjectWithTag("BordaCima").SetActive(false);
            GameObject.FindGameObjectWithTag("BordaBaixo").SetActive(false);
            GameObject.FindGameObjectWithTag("Botoes").GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<Canvas>().enabled = true;
            RotacaoPersonagem.naoMexer = false;
            CutsScene.olharValk = false;
            SegundaFaseMecanica.gameOver = false;
            RotacaoPersonagem.naoMexer = false;*/
            SceneManager.LoadScene("Menu");
        }
        if (SceneManager.GetActiveScene().name == "Fase1") {
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
        if (SceneManager.GetActiveScene().name == "Fase2") {
            SceneManager.LoadScene("Menu");
        }
        if (SceneManager.GetActiveScene().name == "Fase3") {
            SceneManager.LoadScene("Menu");
        }
    }
}
