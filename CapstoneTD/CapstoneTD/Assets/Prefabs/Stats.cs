using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public static int money;
    public static int lives;
    public int startMoney = 400;
    public int startLives = 20;

    void Start()
    {
        //static variables will carry on to a different scene
        money = startMoney;
        lives = startLives;
    }
}
