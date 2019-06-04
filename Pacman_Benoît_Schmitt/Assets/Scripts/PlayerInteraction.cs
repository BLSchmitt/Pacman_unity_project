using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
   
    public int count;
    private int countMax;

    void start(){
        count = 0;
        countMax = 5;
    }

   void OnTriggerEnter(Collider coco){

       string tag = coco.gameObject.tag;

       // si on récupère un objet 
       if(tag == "pickup"){
           // on fait disparaitre l'objet
           coco.gameObject.SetActive(false);

           // on augmente le compte des objets
           count++;

           // si on les a tous alors on fini la partie
           if(count == countMax){
               
           }

       }
        else{
            // si on impact un ennemi
            if(tag == "ennemis"){
                // si on a encore une vie on recommence

                // si on a plus de vie en stock la partie se termine

            }
        }


   }
}
