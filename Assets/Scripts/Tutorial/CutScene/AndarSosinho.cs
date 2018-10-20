using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AndarSosinho : MonoBehaviour {

	public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
		GameObject personagem;
        GameObject bordabaixo;
	    GameObject bordacima;
        GameObject canvasBotoes;
        float speed = 13f;

        void Start () {

            canvasBotoes = GameObject.FindGameObjectWithTag("Finish");
            bordacima = GameObject.FindGameObjectWithTag("BordaCima");
		    bordabaixo = GameObject.FindGameObjectWithTag("BordaBaixo");
			personagem = GameObject.FindGameObjectWithTag("Player");
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;
            agent.speed = speed;
            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if(PararDeAndar.pare == true){
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            }

            if (points.Length == 0 )
                return;

            // Set the agent to go to the currently selected destination.
			if(Sala3.iniciarAndar == true){
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
			print("PONTINHO" + destPoint);
			

			if(Sala3.animacaoAndar == true){
				personagem.GetComponent<Animator>().SetBool("AndarSosinho", true);
			}
			if(Sala3.animacaoAndar == false){
				personagem.GetComponent<Animator>().SetBool("AndarSosinho", false);
			 }
			}
        }


        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f )               
                GotoNextPoint();

                if(Sala3.colocoupedra == true){
                    StartCoroutine(Bordas());
                    RotacaoPersonagem.x = 0;
                    RotacaoPersonagem.z = 0;
                    RotacaoPersonagem.naoMexer = true;
                }
        }

        IEnumerator Bordas(){
            yield return new WaitForSeconds(0.5f);
        SegundaFaseMecanica.gameOver = true;
            canvasBotoes.GetComponent<Canvas>().enabled = false;
            bordacima.GetComponent<Animator>().SetTrigger("Bordinha");
			bordabaixo.GetComponent<Animator>().SetTrigger("Bordinha");
        }


 
}
