using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;

    private string movementAxeHorizontal;
    private string movementAxeVertical;


    // Start is called before the first frame update
    void Start()
    {
        movementAxeHorizontal = "Horizontal";
        movementAxeVertical = "Vertical";
        speed = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis(movementAxeHorizontal);
        float movementVertical = Input.GetAxis(movementAxeVertical);
        Vector3 movement = new Vector3(movementHorizontal,0.0f,movementVertical);

        rb.MovePosition(transform.position + movement*speed);
    }


}
