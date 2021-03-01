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
    public Text infoText;
    static public float powerRating;
    public Slider powerSlider;
    public Button throwButton;
    public Image reticle;
    public Image selectedBall;

    // true = up, false = down
    bool powerBarClimb = true;

    int lightBalls = 2;
    int midBalls = 2;
    int heavyBalls = 2;
    public Text lightBallsText;
    public Text midBallsText;
    public Text heavyBallsText;
    public Button lightButton;
    public Button midButton;
    public Button heavyButton;

    public GameObject lightBallObject;
    public GameObject midBallObject;
    public GameObject heavyBallObject;
    public GameObject[] ballsList;


    // camera angles
    float yaw = 0.0f;
    float pitch = 0.0f;

    // what ball is equipped
    static int whichBall = 0;

    // Start is called before the first frame update
    void Start()
    {
        sideCam.enabled = true;
        mainCam.enabled = false;
        sideWall.GetComponent<Renderer>().enabled = false;
        powerSlider.gameObject.SetActive(true);
        throwButton.interactable = false;
        infoText.text = "Sideview (change camera to throw)";
        reticle.enabled = false;
        ballsList = new GameObject[3];
        ballsList[0] = lightBallObject;
        ballsList[1] = midBallObject;
        ballsList[2] = heavyBallObject;
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

        // WASD to move camera

        if (Input.GetKey("w"))
        {
            pitch -= 1;
        }
        if (Input.GetKey("a"))
        {
            yaw -= 1;
        }
        if (Input.GetKey("s"))
        {
            pitch += 1;
        }
        if (Input.GetKey("d"))
        {
            yaw += 1;
        }
        yaw = Mathf.Clamp(yaw, -30f, 30f);
        pitch = Mathf.Clamp(pitch, -15f, 15f);
        mainCam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // enable or disable ball selection button based on if we have any
        
        if (lightBalls > 0)
        {
            lightButton.interactable = true;
        } else
        {
            lightButton.interactable = false;
        }
        if (midBalls > 0)
        {
            midButton.interactable = true;
        }
        else
        {
            midButton.interactable = false;
        }
        if (heavyBalls > 0)
        {
            heavyButton.interactable = true;
        }
        else
        {
            heavyButton.interactable = false;
        }

        // display which ball is selected

        switch (whichBall)
        {
            case 0:
                selectedBall.transform.position = new Vector3(Screen.width / 10, Screen.height / 10, 0);
                break;
            case 1:
                selectedBall.transform.position = new Vector3(Screen.width / 3.3f, Screen.height / 10, 0);
                break;
            case 2:
                selectedBall.transform.position = new Vector3(Screen.width / 2.05f, Screen.height / 10, 0);
                break;
        }
    }
    public void changeCamera()
    {
        if (sideCam.enabled == true)
        {
            sideCam.enabled = false;
            mainCam.enabled = true;
            sideWall.GetComponent<Renderer>().enabled = true;
            throwButton.interactable = true;
            infoText.text = "Use WASD to control Camera";
            reticle.enabled = true;

        }
        else if (sideCam.enabled == false)
        {
            sideCam.enabled = true;
            mainCam.enabled = false;
            sideWall.GetComponent<Renderer>().enabled = false;
            throwButton.interactable = false;
            infoText.text = "Sideview (change camera to throw)";
            reticle.enabled = false;
        }
    }
    public void chooseBall(int chosen)
    {
        whichBall = chosen;

    }
    public void throwBall()
    {
        // Instantiate
        Vector3 cameraPosition = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z);
        switch (whichBall)
        {
            case 0:
                if (lightBalls > 0)
                {
                    lightBalls--;
                    GameObject newBall = Instantiate(ballsList[whichBall], cameraPosition, Quaternion.identity);
                }
                break;
            case 1:
                if (midBalls > 0)
                {
                    midBalls--;
                    GameObject newBall = Instantiate(ballsList[whichBall], cameraPosition, Quaternion.identity);
                }
                break;
            case 2:
                if (heavyBalls > 0)
                {
                    heavyBalls--;
                    GameObject newBall = Instantiate(ballsList[whichBall], cameraPosition, Quaternion.identity);
                }
                break;
        }
    }
}
