using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Text countPickupText;
    public Text lifeText;
    public Text winningText;
    public Text loosingText;
    
    public int countPickup;
    public int life;
    private int countMax;




    void Start()
    {
        countPickup = 0;
        countMax = 5;
        life = 1;
        lifeText.text = life.ToString() + " vie";
        CountingMessage();

        // text en cas de fin de parti
        winningText.text = " ";
        loosingText.text = " ";


    }

    void OnTriggerEnter(Collider coco){
       string tag = coco.gameObject.tag;

       // si on récupère un objet 
       if(tag == "pickup"){
           // on fait disparaitre l'objet
           coco.gameObject.SetActive(false);
           // on augmente le compte des objets
           countPickup++;
           CountingMessage();
           // si on les a tous alors on fini la partie
           if(countPickup == countMax){
                winningText.text = "Bien joué tu as gagné !";
           }

       }
        else{
            // si on impact un ennemi
            if(tag == "ennemis"){
                // on perd la vie
                life--;
                lifeText.text = life.ToString() + " vie";
                // si on a encore une vie on recommence
                if(life >0){
                    // on recommence du début
                }
                else{
                // si on a plus de vie en stock la partie se termine
                loosingText.text = "Dommage essay encore :D";
                }
            }
        }

   }

    void CountingMessage()
    {
        countPickupText.text = "    restant : " +(countMax-countPickup).ToString();
    }



}
