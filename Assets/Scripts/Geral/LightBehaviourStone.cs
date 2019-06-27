using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviourStone : MonoBehaviour {

	Material mat;
	Color originalColor;
	float emission;
    Light luz;
    Color corLuzOriginal;

	// Use this for initialization
	void Start () {
		mat = gameObject.GetComponent<Renderer> ().material;
		originalColor = mat.GetColor ("_EmissionColor");
        if(gameObject.name == "courage_pedra"|| gameObject.name == "death_pedra" || gameObject.name == "intelligence_pedra") {
            luz = gameObject.GetComponentInChildren<Light>();
            corLuzOriginal = luz.color;
        }
	}

	// Update is called once per frame
	void Update () {
        if (gameObject.name == "courage_pedra"||gameObject.name == "death_pedra" || gameObject.name == "intelligence_pedra") {
            if (PedraFinalFase1.pedraCColocada == false|| SegundaFaseMecanica.pedraPColocada == false || MecanicaTochaAzul.pedraIColocada == false) {
                emission = Mathf.PingPong(Time.time * 0.75f, 1);
                Color finalColor = originalColor * Mathf.LinearToGammaSpace(emission);
                mat.SetColor("_EmissionColor", finalColor);
                float cor = Mathf.PingPong(Time.time * 0.75f, 1);
                Color corFinal = corLuzOriginal * Mathf.LinearToGammaSpace(cor);
                luz.color = corFinal;
            } else {
                mat.SetColor("_EmissionColor", originalColor);
                luz.color = corLuzOriginal;
            }
        }
		if ((SegundaFaseMecanica.pedraAColocada == false || SegundaFaseMecanica.pedraRColocada == false)&& gameObject.name !="death_pedra" ) {
			emission = Mathf.PingPong (Time.time * 0.75f, 1);
			Color finalColor = originalColor * Mathf.LinearToGammaSpace (emission);
			mat.SetColor ("_EmissionColor", finalColor);
		} else {
			mat.SetColor ("_EmissionColor", originalColor);
		}
	}



}
