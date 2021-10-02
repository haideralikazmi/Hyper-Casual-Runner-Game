using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy_Object : MonoBehaviour
{

    private GameObject playerBody;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.Find("Player_Character");
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Destroy(playerBody);
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }


    }
    
}
