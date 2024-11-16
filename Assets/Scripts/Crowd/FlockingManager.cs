using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    public static FlockingManager FM;
    public GameObject fish;
    public int numFish = 30;
    public GameObject[] allFish;
    public Vector3 swimLimits = new Vector3(5, 5, 5);

    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighDistance;
    [Range(1.0f, 5.0f)]
    public float rotateSpeed;

    public Vector3 goalPos = Vector3.zero;

    void Start()
    {
        allFish = new GameObject[numFish];
        for(int i = 0; i < numFish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x), Random.Range(-swimLimits.y, swimLimits.y), Random.Range(-swimLimits.z, swimLimits.z));

            allFish[i] = Instantiate(fish, pos, Quaternion.identity);
        }
        FM = this;
        goalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0, 100) < 10)
        {
            goalPos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x), Random.Range(-swimLimits.y, swimLimits.y), Random.Range(-swimLimits.z, swimLimits.z));
        }
    }
}
