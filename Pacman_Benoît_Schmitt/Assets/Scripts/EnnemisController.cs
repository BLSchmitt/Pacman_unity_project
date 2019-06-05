using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemisController : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;

    public Transform[] destinationToGo;


    // stock the spawn coordinate of the ennemis
    public Vector3 startCoordinateEnnemis1;

    void start()
    {
        navMeshAgent.SetDestination(destinationToGo[0].position);

    }

    void Update()
    {
        // give the ghost a destination
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance){
            int x = Random.Range(0,destinationToGo.Length);
            navMeshAgent.SetDestination(destinationToGo[x].position);
        }
    }
}
