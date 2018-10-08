using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AndarSosinho : MonoBehaviour {

	public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
		GameObject personagem;


        void Start () {

			personagem = GameObject.FindGameObjectWithTag("Player");
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0 )
                return;

            // Set the agent to go to the currently selected destination.
			if(Sala3.colocoupedra == true){
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
			
			

			if(destPoint <= 1){
				personagem.GetComponent<Animator>().SetBool("AndarSosinho", true);
			}
			else{
				personagem.GetComponent<Animator>().SetBool("AndarSosinho", false);
			 }
			}
        }


        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f )
                GotoNextPoint();
        }
 
}
