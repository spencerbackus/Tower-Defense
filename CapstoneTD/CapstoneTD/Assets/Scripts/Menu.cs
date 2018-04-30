using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public string level = "Main";

    public void Play()
    {
        SceneManager.LoadScene("Level");
        
    }

    public void Quit()
    {
        Application.Quit();
    }

   
}
