using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwBall : MonoBehaviour
{
    GameObject mainCamera;
    bool throwDone = false;
    Vector3 throwDirection;
    float currentPower;
    float timeAlive = 0;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        throwDirection = mainCamera.transform.forward;
        currentPower = gameManager.powerRating;
        GetComponent<Rigidbody>().AddForce(currentPower * 1500 * mainCamera.transform.forward * GetComponent<Rigidbody>().mass);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if alive for 5 or more seconds and is no longer moving enough, destroy it
        timeAlive += Time.deltaTime;
        float speed = GetComponent<Rigidbody>().velocity.magnitude;
      if (speed <= 0.65f && timeAlive >= 5 || speed <= 0.8f && timeAlive >= 2)
        {
          Destroy(this.gameObject);
        }
    }
}
