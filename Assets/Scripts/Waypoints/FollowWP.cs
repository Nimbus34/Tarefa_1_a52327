using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;
    float speed = 5f;
    float accuracy = 1f;
    float rotSpeed = 2f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoint;
        g = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    public void GoToHelicopter()
    {
        g.AStar(currentNode, wps[0]);
        currentWP = 0;
    }
    public void GoToThanks()
    {
        g.AStar(currentNode, wps[4]);
        currentWP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
