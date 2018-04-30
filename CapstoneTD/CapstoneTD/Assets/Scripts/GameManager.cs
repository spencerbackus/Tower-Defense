using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static bool gameEnd = false;
    public GameObject gameOverUI;
    public GameObject levelUI;

    void Start()
    {
        //when the game starts, the gameEnd must be false for it to run
        gameEnd = false;
    }

    // Update is called once per frame
    void Update() {

        if (gameEnd)
            return;

        //out of lives
        if (Stats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {   //Display gameoverui
        gameEnd = true;
        gameOverUI.SetActive(true); //enables the game over overlay when the game ends.
    }

    public void Win()
    {
        //display win screen
        gameEnd = true;
        levelUI.SetActive(true);
    }
}
