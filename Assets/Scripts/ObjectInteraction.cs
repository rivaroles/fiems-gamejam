using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject Panel;

    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Player")
        {
            if(Panel != null) 
            {
                Panel.SetActive(true);
            }  
        }
    }

        private void OnTriggerExit(Collider collision) 
    {
        if (collision.tag == "Player") 
        {
            if(Panel != null) 
            {
                Panel.SetActive(false);
            }
        }
    }
}
