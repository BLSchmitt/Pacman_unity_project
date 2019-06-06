using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnnemisController : MonoBehaviour
{
    // where to go
    public Transform ennemisStrartingPosition;
    public float speed;
    public GameObject ennemis;

    // Update is called once per frame
    void Update()
    {
        // move the ghost to the spawn
        MoveTo();
    }


    private void MoveTo()
    {
        Vector3 pos = transform.position;
        float step = speed * Time. deltaTime;
        transform.position = Vector3.MoveTowards(pos, ennemisStrartingPosition.position, step);
        // une fois arrive au spawn disparait pour laisser place a l ennemis
        if(Vector3.Distance(pos,ennemisStrartingPosition.position) <0.2f){
            gameObject.SetActive(false);
            ennemis.transform.position = ennemisStrartingPosition.position;
            ennemis.SetActive(true);
        }
    }
}
