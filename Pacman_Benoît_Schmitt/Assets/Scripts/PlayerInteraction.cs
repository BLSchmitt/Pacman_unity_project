using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    // text comptant le nombre restant de pickup à recolter
    public Text countPickupText;
    // text comptant les vies restantes
    public Text lifeText;

    // messages de fin
    public Text winningText;
    public Text loosingText;
    
    // les nombres de pickup récupéré  
    public int countPickup;
    // le nombre de vie restante
    public int life;
    // le nombre de pickup total
    private int countMax;
    
    // si on a recuperer le powerUp qui permet de manger les fantomes
    public Boolean powerUp;


    void Start()
    {
        // initialisation des variables
        countPickup = 0;
        powerUp = false;
        countMax = 5;
        life = 1;
        lifeText.text = life.ToString() + " vie";
        CountingMessage();
        // text en cas de fin de parti donc blanc au début
        winningText.text = " ";
        loosingText.text = " ";
    }

    // lorsque le player impact un objet "pickup" ou un ennemis "ennemis"
    // alors une action spécifique se lance
    void OnTriggerEnter(Collider coco)
    {
       string tag = coco.gameObject.tag;
       // si on récupère un objet 
       if(tag == "pickup"){
          Pickingup(coco);
       }
        else
        {
            // si on impact un ennemi
            if(tag == "ennemis"){
                EnnemisImpacting(coco);
            }
        }
   }

    private void Pickingup(Collider coco){
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

    private void EnnemisImpacting(Collider coco){
        // si on a le powerup actif alors on mange les fantomes
        if(powerUp){

        }
        //sinon on se fait manger
        else{
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

    // actualise le text 
    public void CountingMessage()
    {
        countPickupText.text = "    restant : " +(countMax-countPickup).ToString();
    }



}
