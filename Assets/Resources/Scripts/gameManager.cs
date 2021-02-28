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
    static public float powerRating;
    public Slider powerSlider;
    bool canShoot = false;

    // true = up, false = down
    bool powerBarClimb = true;

    int lightBalls = 2;
    int midBalls = 2;
    int heavyBalls = 2;
    public Text lightBallsText;
    public Text midBallsText;
    public Text heavyBallsText;

    // Start is called before the first frame update
    void Start()
    {
        sideCam.enabled = true;
        mainCam.enabled = false;
        sideWall.GetComponent<Renderer>().enabled = false;
        powerSlider.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pinsLeftText.text = "Pins Left: " + pinsLeft;
        if (powerBarClimb)
        {
            powerRating = powerRating + 0.03f;
            if (powerRating >= 1)
            {
                powerBarClimb = false;
            }
        }
        if (powerBarClimb == false)
        {
            powerRating = powerRating - 0.03f;
            if (powerRating <= 0)
            {
                powerBarClimb = true;
            }
        }
        powerSlider.value = powerRating;
        // amount of balls
        lightBallsText.text = "Light x" + lightBalls.ToString();
        midBallsText.text = "Middle x" + midBalls.ToString();
        heavyBallsText.text = "Heavy x" + heavyBalls.ToString();
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
