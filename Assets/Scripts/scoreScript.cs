using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{

    public static int scoreCount = 0;
    public static int livesCount = 3;
    public static int powerCount = 0;

    public Text text;
    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + scoreCount + "\nLives: " + livesCount + "\nPower: " + powerCount;  
        if (livesCount <= 0)
        {
            gameOverText.text = "Game over";
        } else
        {
            gameOverText.text = "";
        }
    }

    public static void ResetScore()
    {
        scoreCount = 0;
        livesCount = 3;
    }
}
