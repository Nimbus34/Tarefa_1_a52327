using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{

    float speed;
    bool turning = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(FlockingManager.FM.minSpeed, FlockingManager.FM.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        Bounds b = new Bounds(FlockingManager.FM.transform.position, FlockingManager.FM.swimLimits * 2);

        if (!b.Contains(transform.position))
        {
            turning = true;
        }
        else
        {
            turning = false;
        }

        if(turning)
        {
            Vector3 direction = FlockingManager.FM.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), FlockingManager.FM.rotateSpeed * Time.deltaTime);
        }
        else
        {
            if (Random.Range(0, 100) < 10)
            {
                speed = Random.Range(FlockingManager.FM.minSpeed, FlockingManager.FM.maxSpeed);
            }

            if (Random.Range(10, 150) < 20)
            {
                ApplyRules();
            }
        }

            
        this.transform.Translate(0, 0, speed * Time.deltaTime);      
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = FlockingManager.FM.allFish;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;

        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach(GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if(nDistance <= FlockingManager.FM.neighDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if(nDistance < 1.0)
                    {
                        vavoid = vavoid + (this.transform.position + go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            vcentre = vcentre / groupSize + (FlockingManager.FM.goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            if(speed > FlockingManager.FM.maxSpeed)
            {
                speed = FlockingManager.FM.maxSpeed;
            }

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), FlockingManager.FM.rotateSpeed * Time.deltaTime);
            }
        }
    }
}
