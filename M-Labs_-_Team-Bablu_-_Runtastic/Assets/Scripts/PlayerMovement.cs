using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private bool isGrounded;
    private Vector3 moveForward;
    private Vector3 jumpUp;
    private bool isColliding = false;
    private Rigidbody rigidBodyComponent;
    private Vector3 horizontalMovement = new Vector3(0f, 0f, -2.5f);
    //private float horizontalSpeed  = 9f;
    private float hInput;
    //private bool inAir;
    private bool jump;
    private GameObject stickObject;
    private Animator stickAnimator;
    private string animationName = "AnimateTheStick";

    private Touch touch;
    private Vector3 touchPosition;

    private float setPositionX = 0.05f;
    private float setPointY = 0.02f; 

    

    // Start is called before the first frame update
    void Start()
    {   
        jumpUp = new Vector3(0f, 9.5f, 0f);
        moveForward = new Vector3(10f, 0f , 0f);

        stickObject = GameObject.Find("Stick");
        stickAnimator = stickObject.GetComponent<Animator>();

        rigidBodyComponent = GetComponent<Rigidbody>();

        

    }//Start

    // Update is called once per frame
    void Update()
    {   
        hInput = 0;

        //Touch controls for horizontal movement
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.position.x > 199)
            {
                hInput = 9f;
               
            }
 
            else if(touch.position.x < 101)
            {
                hInput = -9f;
            }          
        }

        if(jump == true)
        {

        stickAnimator.SetBool(animationName,true); 
        jump = false;
        }  

        else
        {
        stickAnimator.SetBool(animationName,false);

        }   

    }//Update

    void FixedUpdate()
    {   
        //Moving forward
        if(isColliding == false)
        {
            rigidBodyComponent.MovePosition(transform.position + moveForward * Time.deltaTime);
        }    

        //Force added for horizontal movement
        rigidBodyComponent.AddForce(horizontalMovement * hInput, ForceMode.Acceleration);
        

        // Apply jump force if conditions are met.
        

    }//FixedUpdate

    void OnCollisionEnter(Collision collision)
    {

        
        //Layer mask to check for collision with certain GameObjects such as obstacles nad/or Ground
        if(collision.gameObject.layer == 8)
        {
            isColliding = true;
            
        }

        if(collision.gameObject.layer == 9)
        {
            isGrounded = true;

        }


        
    }//OnCollisionEnter


    void OnCollisionExit(Collision collision)
    {   
        isColliding =false;
        isGrounded = false;
       
    }//OnCollisionExit


    void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.layer == 7)
        {

        stickObject.transform.localScale =  new Vector3(3f ,
                                                        stickObject.transform.localScale.y , 
                                                        stickObject.transform.localScale.z );
        
        //Re-Adjust the positioning of the stick after increase in its length

        stickObject.transform.localPosition =  new Vector3(stickObject.transform.localPosition.x - setPositionX ,
                                                           stickObject.transform.localPosition.y - setPointY,
                                                           stickObject.transform.localPosition.z);
        
        

        //Increment Jump strength upon item collection
        jumpUp.y = 9.5f;
        
        }

    }


    public void PlayerJumpUp()
    {
         //Making the player jump via Impulse while also triggering animations for the Stick
        if(isGrounded == true)
        {
            rigidBodyComponent.AddForce(jumpUp , ForceMode.Impulse);
            jump = true;
        }
      
        
    }

   
    public void SetJumpStrength()
    {
        jumpUp.y += 2f;
    }

    

    
}//PlayerMovement

