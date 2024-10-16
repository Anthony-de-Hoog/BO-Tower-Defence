using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private Transform[] Waypoint;

    void Start()
    {
        // Places the children into an array
        Waypoint = new Transform[transform.childCount]; 
        for (int i = 0; i < transform.childCount; i++)
        {
            Waypoint[i] = transform.GetChild(i); // Transsfrom the children in the path game object into waypoints for the enemies to follow 
        }
    }
    // Makes the array accessable for other scripts but keeps it private for the users
    public Transform[] waypoints
    {
        get { return Waypoint; }
        set { Waypoint = value; }
    }
}
