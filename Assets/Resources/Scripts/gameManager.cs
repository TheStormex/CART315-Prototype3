using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    static public bool winGame = false;
    public Camera mainCam;
    public Camera sideCam;
    public GameObject sideWall;

    public int pinsLeft = 8;
    public Text pinsLeftText;

    // Start is called before the first frame update
    void Start()
    {
        sideCam.enabled = true;
        mainCam.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pinsLeftText.text = "Pins Left: " + pinsLeft;
    }
    public void changeCamera()
    {
        if (sideCam.enabled == true)
        {
            sideCam.enabled = false;
            mainCam.enabled = true;
            sideWall.GetComponent<Renderer>().enabled = true;
        }
        else if (sideCam.enabled == false)
        {
            sideCam.enabled = true;
            mainCam.enabled = false;
            sideWall.GetComponent<Renderer>().enabled = false;
        }
    }
}
