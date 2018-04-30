using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {


    public static int enemiesAlive = 0;
    public Wave[] waves;
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;
    private int waveIndex = 0;

    public GameManager tt;

    void Update ()
    {
        if(enemiesAlive > 0)
        {
            return; // dont want to do the rest if enemies are still alive.
        }

        if (waveIndex == waves.Length) //equal to total amount of waves created
        {
            tt.Win();
            this.enabled = false; //stop spawning waves when wave array is done
        }

        if (countdown <= 0f)
        {
            //when countdown is 0 spawn a new wave
            //countdown doesnt start until the wave before dies
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return; //dont pass below when spawning new wave
        }

        //reduce countdown by 1 second
        countdown -= Time.deltaTime;

        //Sets a timer from the countdown set in the inspector to 0 with infinity being the maximum
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //cut off decimal places (round down), format in 0:00.00 time.
        waveCountdownText.text = string.Format("{0:00.00}", countdown);

    }



    //pause this code. wait x seconds.
    IEnumerator SpawnWave()
    {
        Stats.rounds++;
        Wave wave = waves[waveIndex]; //first wave, take first index, etc.
        for (int i = 0; i < wave.amtEnemies; i++)
        {
            SpawnEnemy(wave.enemy);
            //wait .5 seconds before spawning an enemy and increasing the wave number
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

       
    }

    void SpawnEnemy(GameObject enemy)
    {
        //instantiate the enemy; spawn it
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++; 

    }
}
