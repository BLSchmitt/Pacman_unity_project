using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemisController : MonoBehaviour
// controle le deplacement des ennemis
{

    public NavMeshAgent navMeshAgent;
    // stock les destinations possibles des ennemis
    public Transform[] destinationToGo;

    void start()
    {
        // donne une destinaltion a l ennemis
        navMeshAgent.SetDestination(destinationToGo[0].position);
    }

    void Update()
    {
        // donne une destination a l ennemis
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance){
            int x = Random.Range(0,destinationToGo.Length);
            navMeshAgent.SetDestination(destinationToGo[x].position);
        }
    }
}
