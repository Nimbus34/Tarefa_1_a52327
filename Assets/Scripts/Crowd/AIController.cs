using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    GameObject[] goals;
    NavMeshAgent agent;
    Animator anim;
    float speedMult;
    float detectionRadius = 5;
    float fleeRadius = 10;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        goals = GameObject.FindGameObjectsWithTag("goals");
        int i = Random.RandomRange(0, goals.Length);
        agent.SetDestination(goals[i].transform.position);
        anim = this.GetComponent<Animator>();
        anim.SetFloat("wOffset", Random.Range(0.0f, 1.0f));

        ResetAgent();
    }

    void ResetAgent()
    {
        speedMult = Random.Range(0.5f, 2.0f);
        anim.SetFloat("speed", speedMult);
        agent.speed *= speedMult;
        anim.SetTrigger("isWalking");
        agent.angularSpeed = 120;
        agent.ResetPath();
    }

    public void DetectNewObstacle(Vector3 position)
    {
        if(Vector3.Distance(position, this.transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - position).normalized;
            Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if(path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                anim.SetTrigger("isRunning");
                agent.speed = 10;
                agent.angularSpeed = 500;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 1)
        {
            ResetAgent();
            int i = Random.Range(0, goals.Length);
            agent.SetDestination(goals[i].transform.position);
        }
    }
}
