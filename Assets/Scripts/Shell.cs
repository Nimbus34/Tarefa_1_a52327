using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    float force = 2;
    float mass = 2;
    float drag = 1;
    float yspeed = 0;
    float gravity = -9.8f;
    float graivtyAcceleration;
    float acceleration;
    float speed = 0;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = force / mass;
        speed = acceleration * 1;
        graivtyAcceleration = gravity / mass;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        speed *= (1 - Time.deltaTime * drag);
        yspeed += graivtyAcceleration * Time.deltaTime;
        this.transform.Translate(0, yspeed, speed);
    }
}
