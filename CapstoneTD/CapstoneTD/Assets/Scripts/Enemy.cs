using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public int health = 100;
    private Transform target;
    private int wavepointIndex = 0;
    public int value = 50;
    private bool isDead = false;

    void Start()
    {
        target = Waypoints.points[0];
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if(health <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        //get money for kills
        Stats.money += value;
        WaveSpawner.enemiesAlive--; 
        Destroy(gameObject);
    }

    //direction to point to get to waypoints
    void Update()
    {
        //x, y, z to point towards target
        Vector3 dir = target.position - transform.position;

        //always has same fixed speed
        //makes sure the speed we move at is not dependant on framerate
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            //enemy is dead
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        Stats.lives--;
        WaveSpawner.enemiesAlive--; // current amount of enemies in scene
        Destroy(gameObject);
    }
}
