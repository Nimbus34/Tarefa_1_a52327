using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCylidner : MonoBehaviour
{
    public GameObject cylinder;
    GameObject[] agents;

    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Instantiate(cylinder, hitInfo.point, cylinder.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIController>().DetectNewObstacle(hitInfo.point);
                }
            }
        }
    }
}
