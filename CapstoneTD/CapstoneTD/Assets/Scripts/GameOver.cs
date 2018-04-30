using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string scene = "MainMenu";

    public void Retry()
    {
        //restart the currently loaded scene. .name returns the name of the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
       SceneManager.LoadScene(scene);
    }
}
