using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    public GameObject ui;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if escape, toggle menu
            Toggle();
        }
    }

    public void Toggle()
    {
        //enable or disable ui, opposite of whatever current state is
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
            //When timeScale is set to zero the game is basically paused 
            //if all your functions are frame rate independent.
            Time.timeScale = 0f;
        else
            //realtime
            Time.timeScale = 1f;
    }

    public void Retry()
    {
        //reload the current scene, same as retry on game end
        //Get current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Toggle();
    }

    public void Menu()
    {
        
        SceneManager.LoadScene("MainMenu");
        Toggle();
    }

}
