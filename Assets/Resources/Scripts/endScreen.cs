using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endScreen : MonoBehaviour
{
    public Text endText;
    public Button replayButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.winGame == true)
        {
            endText.text = "All pins are down! You Win!";
        }
        else if (gameManager.winGame == false)
        {
            endText.text = "You did not knock down the pins! You Lose!";
        }
    }
    public void replayGame()
    {
        SceneManager.LoadSceneAsync("Resources/Scenes/Game", LoadSceneMode.Single);
    }
}
