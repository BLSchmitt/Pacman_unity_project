using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
   
   void OnTriggerEnter(Collider coco){

       string tag = coco.gameObject.tag;

       // si on récupère un objet 
       if(tag == "pickup"){
           // on fait disparaitre l'objet

           // on augmente le compte des objets


           // si on les a tous alors on fini la partie
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
