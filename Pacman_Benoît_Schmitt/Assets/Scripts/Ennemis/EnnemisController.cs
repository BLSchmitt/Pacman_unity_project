using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemisController : MonoBehaviour
// controle le deplacement des ennemis
{
    // si on est en train de chasser le joueur
    public bool inChasse = false;
    // si on est dispose a chasser le joueur (pour ne pas le chasser sans arret)
    public bool readyToChase = true;
    // le temps d une chasse
    public float chasingTime = 1f;
    // le temps entre les chasse
    public float timeBetweenChasse = 2f;

    public NavMeshAgent navMeshAgent;
    // stock les destinations possibles des ennemis
    public Transform[] destinationToGo;
    // stock la position du joueur pour les chasses
    public Transform playerTransform;

    void start()
    {
        // donne une destinaltion a l ennemis
        navMeshAgent.SetDestination(destinationToGo[0].position);
    }

    void Update()
    {
        // si on est disponible pour la chasse alors on prend le joueur en chasse si on le voit
        if (readyToChase){
            DetectTarget();
        }
        if (inChasse){
            Chasse();
        }
        else{
            // donne une destination a l ennemis
            setRandomDestination();
        }
    }

    // donne une destination aleatoire a l ennemis
    private void setRandomDestination()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance){
            int x = UnityEngine.Random.Range(0,destinationToGo.Length);
            navMeshAgent.SetDestination(destinationToGo[x].position);
        }
    }

    // on prend le joueur en chasse
    private void Chasse()
    {
        // on prend comme destination le joueur
        navMeshAgent.SetDestination(playerTransform.position);
        // apres un certain temps on est plus en chasse
        StartCoroutine(ChassingTime());
    }

    // on defenit la periode de chasse
    IEnumerator ChassingTime()
    {
        yield return new WaitForSeconds(chasingTime);
        inChasse = false;
        yield return new WaitForSeconds(timeBetweenChasse);
        readyToChase = true;
    }

    // on cherche si le joueur est devant l ennemis si oui on active la chasse
    private void DetectTarget()
    {
        RaycastHit hit;
            if (Physics.Raycast(transform.position,transform.forward, out hit,10f) & (hit.rigidbody != null)){
                if(hit.rigidbody.CompareTag("Player")){
                        inChasse = true;
                        readyToChase = false;
                }
            }
    }
}
