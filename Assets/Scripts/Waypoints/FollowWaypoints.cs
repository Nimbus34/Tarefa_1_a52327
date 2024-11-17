using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentWaypoint = 0;
    public float speed = 15f;
    public float rotationSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) < 3)
        {
            currentWaypoint++;
        }
        if(currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }

        //this.transform.LookAt(waypoints[currentWaypoint].transform);

        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWaypoint].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP,rotationSpeed * Time.deltaTime);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
