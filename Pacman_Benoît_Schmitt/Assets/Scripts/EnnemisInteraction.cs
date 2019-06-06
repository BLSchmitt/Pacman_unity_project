using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisInteraction : MonoBehaviour
// ce script gere toutes les interactions avec les ennemis
{
    public GameObject[] ennemis; 
    public GameObject[] deadEnnemis;
    private Renderer[] rend;
    private Color[] color;

    public GameObject player;
    private PlayerInteraction playerInteraction;

    public int numberOfEnnemis;
    // initialisation
    void Awake(){
        playerInteraction = player.GetComponent<PlayerInteraction>();
        numberOfEnnemis = ennemis.Length;
        rend = new Renderer[numberOfEnnemis];
        color = new Color[numberOfEnnemis];
        for (int i=0;i<numberOfEnnemis;i++){
            rend[i] = ennemis[i].GetComponent<Renderer>();
            color[i] = rend[i].material.color;
        }
    }



    // ennemis se fait manger, appelle par PlayerInteraction
    // quand powerUp est active et suite a une collision player / ennemis
    public void EnnemisDestruction(Collider coco){
        // on repere quel ennemis est coco
        int i = 0;
        while(ennemis[i].name != coco.name){
            i++;
        }
        // si on a deja mange cette ennemis i alors on peut plus
         if( rend[i].material.color == color[i]){
            playerInteraction.PlayerDestruction();
        }
        else{
            // destroy the ennemis and send his ghost to the spawn where it can resurect
            coco.gameObject.SetActive(false);
            // resurect the ennemis
            EnnemisResurection(i);
        }
  }

    private void EnnemisResurection(int i)
    {
        deadEnnemis[i].transform.position = ennemis[i].transform.position;
        deadEnnemis[i].SetActive(true);
        // il redevient intuable, on lui redonne alors sa couleur
        rend[i].material.color = color[i];
    }


    // appelle par PlayerInteraction quand on mange un powerup
    // le player peut alors manger ses ennemis pend un certain temps
    // les ennemis deviennent bleu
    public void EnnemisAreKillable(){
    for(int i=0;i<numberOfEnnemis;i++){
          rend[i].material.color = Color.blue;
    }
  }

    // appelle par PlayerInteraction quand le powerup se finit 
    // le joueur ne peut plus manger ses ennemis
    // les ennemis reprennent leurs couleurs d'origine
    public void EnnemisAreNotKillable(){
        for(int i=0; i<numberOfEnnemis;i++){
            rend[i].material.color = color[i];
        }
    }

}
