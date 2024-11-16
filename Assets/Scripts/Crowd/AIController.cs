using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    GameObject[] goals;
    NavMeshAgent agent;
    Animator anim;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        goals = GameObject.FindGameObjectsWithTag("goals");
        int i = Random.RandomRange(0, goals.Length);
        agent.SetDestination(goals[i].transform.position);
        anim = this.GetComponent<Animator>();
        anim.SetTrigger("isWalking");
        anim.SetFloat("wOffset", Random.Range(0.0f, 1.0f));
        float sm = Random.Range(0.5f, 2.0f);
        anim.SetFloat("speed", sm);
        agent.speed *= sm;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 1)
        {
            int i = Random.RandomRange(0, goals.Length);
            agent.SetDestination(goals[i].transform.position);
        }
    }
}
