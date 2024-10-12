using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private Transform[] Waypoint;

    void Start()
    {
        Waypoint = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Waypoint[i] = transform.GetChild(i);
        }
    }

    public Transform[] waypoints
    {
        get { return Waypoint; }
        set { Waypoint = value; }
    }
}
