using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
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
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

}
