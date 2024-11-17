using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct link
{
    public enum direction {UNI, BI}
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WaypointManager : MonoBehaviour
{

    public GameObject[] waypoint;
    public link[] links;
    public Graph graph = new Graph();
    // Start is called before the first frame update
    void Start()
    {
        if(waypoint.Length > 0)
        {
            foreach(GameObject wp in waypoint)
            {
                graph.AddNode(wp);
            }
            foreach(link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
                if(l.dir == link.direction.BI)
                {
                    graph.AddEdge(l.node2, l.node1);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
