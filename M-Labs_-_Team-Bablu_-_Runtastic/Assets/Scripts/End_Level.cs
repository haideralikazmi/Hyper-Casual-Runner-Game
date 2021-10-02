using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Level : MonoBehaviour
{
 
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

        }
    }
}
