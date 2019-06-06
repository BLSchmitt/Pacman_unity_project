using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnnemisController : MonoBehaviour
// Controle le deplacement des ennemis une fois mort
// le fantome de l ennemis est active et positionne lors de la mort de l ennemis (voir EnnemisInteraction)
{
    // Ou aller
    public Transform ennemisStrartingPosition;
    public float speed;
    public GameObject ennemis;

    void Update()
    {
        Vector3 pos = transform.position;
        // move the ghost to the spawn
        MoveTo(pos);
        // une fois arrive au spawn disparait pour laisser place a l ennemis
        if(Vector3.Distance(pos,ennemisStrartingPosition.position) <0.2f){
            gameObject.SetActive(false);
            ennemis.transform.position = ennemisStrartingPosition.position;
            ennemis.SetActive(true);
        }
    }

    // bouge le gameObject depuis pos jusqu au spawn
    private void MoveTo(Vector3 pos)
    {
        float step = speed * Time. deltaTime;
        transform.position = Vector3.MoveTowards(pos, ennemisStrartingPosition.position, step);
    }
}
