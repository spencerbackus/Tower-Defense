using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public void MainLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
}
