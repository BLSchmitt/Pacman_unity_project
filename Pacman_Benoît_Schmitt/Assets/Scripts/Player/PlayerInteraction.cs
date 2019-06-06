using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
// controle toute les interactions que le joueur a avec le reste du monde (objet a recuperer et monstre)
{

    public GameObject ennemis;
    // la class controllant les interactions ennemis
    private EnnemisInteraction ennemisInteraction;
    // text comptant le nombre restant de pickup à recolter
    public Text countPickupText;
    // text comptant les vies restantes
    public Text lifeText;

    // messages de fin
    public Text winningText;
    public Text loosingText;
    
    // les nombres de pickup récupéré  
    private int countPickup;
    // le nombre de vie restante
    public int life;
    // le nombre de pickup total
    public int countMax = 54;

    // si on a recuperer le powerUp qui permet de manger les fantomes
    private bool powerUp;
    // la duree du powerUp en seconde
    public float tempsDePowerUp = 2f;
    
    void Awake()
    {
        ennemisInteraction = ennemis.GetComponent<EnnemisInteraction>();
    }

    void Start()
    {
        // initialisation des variables
        countPickup = 0;
        powerUp = false;
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
       // si on récupère un objet pickup
       if(tag == "pickup"){
          PickupCollecting(coco);
       }
        else{
            // si on recupere un objet powerup
            if(tag == "powerup"){
                    PowerupCollecting(coco);
                }
                else
                {
                    // si on impact un ennemi
                    if(tag == "ennemis"){
                        EnnemisImpacting(coco);
                }
            }
        }
   }

    // appelle quand on touche un pickup
    private void PickupCollecting(Collider coco){
        // on fait disparaitre l'objet
        coco.gameObject.SetActive(false);
        // on augmente le compte des objets
        countPickup++;
        CountingMessage();
        // si on les a tous alors on fini la partie
        if(countPickup == countMax){
            winningText.text = "Bien joué tu as gagné !";
            StartCoroutine(theEnd());
        }
    }

    // appelle quand on touche un powerup
    private void PowerupCollecting(Collider coco)
    {
        // c'est aussi un pickup
        PickupCollecting(coco);
        // on peut manger les ennemis pendant un certain temps
        powerUp = true;
        ennemisInteraction.EnnemisAreKillable();
        // apres un certain temps on ne peut plus les manger
        StartCoroutine(PowerUpActif());
    }

    IEnumerator PowerUpActif()
    {
        // apres tempsDePowerUp secondes on ne peut plus manger les ennemis
        yield return new WaitForSeconds(tempsDePowerUp);
        powerUp = false;
        ennemisInteraction.EnnemisAreNotKillable();
    }

    // appelle lors d un contact entre le joueur et un ennemis
    public void EnnemisImpacting(Collider coco){
        // si on a le powerup actif alors on mange les fantomes
        if(powerUp){
            ennemisInteraction.EnnemisDestruction(coco);
        }
        //sinon on se fait manger
        else{
            PlayerDestruction();
        }
    }

    public void PlayerDestruction()
    {
        // on perd la vie
        life--;
        lifeText.text = life.ToString() + " vie";
        // si on a encore une vie on recommence
        if(life >0){
            // on recommence du début
            RestartLvl();
        }
        else{
            // si on a plus de vie en stock la partie se termine
            loosingText.text = "Dommage essay encore :D";
            // quitter la partie
            StartCoroutine(theEnd());
        }    
    }

    public void RestartLvl()
    {
        throw new NotImplementedException();
    }


    // on quitte la partie apres 2 secondes
    IEnumerator theEnd(){
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }

    // actualise le text
    // on peut ajouter le comptage de score dans cette methode
    public void CountingMessage()
    {
        countPickupText.text = "    restant : " +(countMax-countPickup).ToString();
    }



}
