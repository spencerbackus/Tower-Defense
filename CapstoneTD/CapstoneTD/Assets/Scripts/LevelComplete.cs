using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public string scene = "MainMenu";

    public void Menu()
    {
        SceneManager.LoadScene(scene);
       
    }
}
