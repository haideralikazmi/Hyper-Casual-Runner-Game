using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_Behaviour : MonoBehaviour
    {   
    private Vector3 tempPosition;
    private Vector3 newLookAt;
    private Vector3 offSetPosition = new Vector3(-13f , 15f , -3f);   
    private GameObject playerObject;
    private Transform playerTransform ;

    private Vector3 playerlookAtOffSet = new Vector3(10f , 3f , 0f);
 

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player_Character");
        playerTransform = GameObject.Find("Player_Character").transform;
        //playerTransformOffSet = playerTransform + ;
    
    }//Update

    // Called after Update
    void LateUpdate()
    {
        if(playerObject == null){

            return;
        }
        
        //Update the coordinates of camera when the x-coordinate of player changes
        tempPosition = transform.position;
        tempPosition = playerTransform.position + offSetPosition;
        transform.position = tempPosition;  

        
        //Adjust rotation of camera to always be looking at the given location
        newLookAt = playerTransform.position + playerlookAtOffSet;
        transform.LookAt(newLookAt);
    
    }//LateUpdate

     public void ReloadLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Nextlevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
