using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinCode : MonoBehaviour
{
    
    float pinHealth = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 10)
        {

            pinHealth -= gameManager.powerRating * collision.relativeVelocity.magnitude;

        } 

        if (pinHealth <= 0)
        {

            Destroy(this.gameObject);

        }
    }
}
