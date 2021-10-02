using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles_Behaviour : MonoBehaviour
{ 
    private GameObject stickObject;
    private GameObject playerObject;
    
    private float stickLength = 2f;
    private float setPositionX = 0.5f;
    private float setPointY = 0.20f; 

    // Start is called before the first frame update
    void Start()
    {
        stickObject = GameObject.Find("Stick");
        playerObject = GameObject.Find("Player_Character");
    
    }//Start

    // Update is called once per frame


    void OnTriggerEnter(Collider collision)
    {   
        
        //Upon collection increase size of stick in the players hand
        if(collision.gameObject.layer == 6)
        {

        
        stickObject.transform.localScale =  new Vector3(stickObject.transform.localScale.x + stickLength ,
                                                        stickObject.transform.localScale.y , 
                                                        stickObject.transform.localScale.z );
        
        //Re-Adjust the positioning of the stick after increase in its length

        stickObject.transform.localPosition =  new Vector3(stickObject.transform.localPosition.x + setPositionX ,
                                                           stickObject.transform.localPosition.y + setPointY,
                                                           stickObject.transform.localPosition.z);
        
        Destroy(this.gameObject);


        //Increment Jump strength upon item collection
        playerObject.GetComponent<PlayerMovement>().SetJumpStrength();
        }
        

    }//OnTriggerEnter

}
