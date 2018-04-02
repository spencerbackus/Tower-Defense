using UnityEngine;

public class Waypoints : MonoBehaviour {
    
    //transform for game objects
    public static Transform[] points;

    //Find all waypoints and load into points array.
    void Awake()
    {
        //number of waypoints
        points = new Transform[transform.childCount];
        for(int i = 0; i < points.Length; i++)
        {
           points[i] = transform.GetChild(i);
        }
    }
}
