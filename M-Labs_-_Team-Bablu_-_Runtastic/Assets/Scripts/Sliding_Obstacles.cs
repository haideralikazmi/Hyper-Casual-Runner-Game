using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding_Obstacles : MonoBehaviour
{
    private Rigidbody rigidBodyComponent;
    private Vector3 movementSpeed = new Vector3(0f ,0f ,10f);
    private float directionModifier = -1.0f;

    private GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
        playerBody = GameObject.Find("Player_Character");
        

    }//Start

    // FixedUpdate is called on every Physics update
    void FixedUpdate()
    {
        //Movement
        rigidBodyComponent.MovePosition(transform.position + movementSpeed * Time.deltaTime);
        
    }//FixedUpdate

    void OnCollisionEnter(Collision collision)
    {
        //Changing direction
        movementSpeed = movementSpeed * directionModifier;

        if(collision.gameObject.layer == 6)
        {
            Destroy(playerBody);
        }


    }

}
