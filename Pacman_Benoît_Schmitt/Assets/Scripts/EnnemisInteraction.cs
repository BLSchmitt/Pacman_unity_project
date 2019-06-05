using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisInteraction : MonoBehaviour
// ce script gere toutes les interactions avec les ennemis
{
    public GameObject[] ennemis; 
    public Renderer[] rend;
    public Color[] color;
    
    public int numberOfEnnemis;
    // initialisation
    void Awake(){
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
    public void ennemisDestruction(Collider coco){
        coco.gameObject.SetActive(false);
  }
    // appelle par PlayerInteraction quand on mange un powerup
    // le player peut alors manger ses ennemis pend un certain temps
    // les ennemis deviennent bleu
  public void ennemisAreKillable(){
    for(int i=0;i<numberOfEnnemis;i++){
          rend[i].material.color = Color.blue;
    }
  }

    // appelle par PlayerInteraction quand le powerup se finit 
    // le joueur ne peut plus manger ses ennemis
    // les ennemis reprennent leurs couleurs d'origine
    public void ennemisAreNotKillable(){
        for(int i=0; i<numberOfEnnemis;i++){
            rend[i].material.color = color[i];
        }
    }

}
